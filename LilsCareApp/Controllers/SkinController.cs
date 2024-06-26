﻿using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class SkinController : BaseController
    {
        private readonly ILogger<SkinController> _logger;
        private readonly IHomeService _service;

        public SkinController(ILogger<SkinController> logger, IHomeService service)
        {
            _logger = logger;
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ContactUs()
        {
            var model = new ContactUsDTO();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsDTO model)
        {
            if (!ModelState.IsValid)
            {
                TempData["scrollToElementId"] = "contact-as";
                return View("Index", model);
            }

            model.AppUserId = User.GetUserId() ?? "guestUser";

            await _service.MessageFromClientAsync(model);

            TempData["scrollToElementId"] = "contact-as";

            return RedirectToAction("Index");
        }
    }
}
