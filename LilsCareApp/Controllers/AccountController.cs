﻿using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult MyAddresses()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            return View();
        }

        public IActionResult MyWishes()
        {
            return View();
        }
    }
}
