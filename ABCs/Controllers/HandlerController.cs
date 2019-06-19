using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ABCs.Controllers
{
    public class HandlerController : Controller
    {
        [HttpPost]
        public IActionResult Index(string answer, string option)
        {
            if (answer == option)
            {

                return View("Correct");
            }


            return View("Wrong");
        }
    }
}