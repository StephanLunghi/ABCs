using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ABCs.Models;

namespace ABCs.Controllers
{
    public class MenuController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            // Eventually:  Enumerable.Range('A', 26).Select(c => (char) c);
            var lettersWeKnow = new List<char>() {'A', 'C', 'F', 'H', 'I', 'O'};

            // Make this a random list with one known letter and 2 (?) unknown letters
            var answer = lettersWeKnow.Last();
            var lettersWePicked = lettersWeKnow.Take(2).Append(answer);

            return View(new LetterQuiz() { allLetters = lettersWePicked, quizAnswer = answer});
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}