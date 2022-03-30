using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.ItAcademy.MVC.Controllers
{
    public class IdentityController : Controller
    {
        public async Task<IActionResult> Login()
        {

            return View();
        }

    }
}
