﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Review;

namespace LilsCareApp.Controllers
{

    public class DetailsController : BaseController
    {
        private readonly IDetailsService _service;
        public DetailsController(IDetailsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            string userId = User.GetUserId();
            DetailsDTO details = await _service.GetDetailsByIdAsync(id, userId);
            if (details == null)
            {
                return NotFound();
            }

            ViewBag.UserId = userId;

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> AddReview(int productId)
        {
            string userId = User.GetUserId();

            AddReviewDTO? review = await _service.GetReviewAsync(productId, userId);
            if (review == null)
            {
                return BadRequest();
            }

            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewDTO review)
        {
            review.Rating = review.Stars.Count(s => s);

            if (review.Rating < RatingMinValue || review.Rating > RatingMaxValue)
            {
                ModelState.AddModelError(nameof(review.Rating), RequireRating);
                return View(review);
            }

            ModelState.Remove(nameof(review.Rating));

            if (!ModelState.IsValid)
            {
                return View(review);
            }

            long size = 0;
            var files = Request.Form.Files;
            review.Images = new List<string>();  // Create a list of ImageDTO objects

            foreach (var formFile in files)
            {

                if (formFile.Length > 0)
                {
                    // Generate a unique filename using the current date and time
                    string fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Path.GetFileName(formFile.FileName)}";
                    var filePath = Path.Combine("files", "reviews", fileName);
                    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

                    using (var stream = new FileStream(uploadDirectory, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    size += formFile.Length;
                    review.Images.Add("\\" + filePath);
                }
            }
            review.AuthorId = User.GetUserId();
            await _service.SaveReviewAsync(review);

            return RedirectToAction(nameof(Index), "Details", new { id = review.ProductId });
        }

    }
}