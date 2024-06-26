﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LilsCareApp.Infrastructure.DataConstants.AdminConstants;

namespace LilsCareApp.Areas.Admin.Controllers
{
    [Area(areaName: AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
    }
}
