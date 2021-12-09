using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    public class DashboardController : Controller
    {
        [Area("manage")]
        [Authorize(Roles ="Admin , SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
