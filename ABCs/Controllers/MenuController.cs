using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ABCs.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCs.Controllers
{
    public class MenuController : Controller
    {
        private LetterQuiz _currentQuiz;

        public IActionResult Index()
        {
            
            _currentQuiz = new LetterQuiz();
            return View(_currentQuiz);
        }

        //public IActionResult Quiz(char id)
        //{
            //if (id == _currentQuiz.Answer)
            //{
            //    return View("Correct");

            //}
        //        return View("Wrong");
        //}

        [HttpPost]
        public IActionResult Quiz(string answer, string option)
        {
            if (answer == option)
            {

                return PartialView("Correct");
            }


            return PartialView("Wrong");
        }


        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}