using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class GuessingGameController : Controller
    {
        GuessingGameModel GGModel = new GuessingGameModel();
        public IActionResult GuessingGame()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("numberSession")))
            {
                int generatedNumber = GGModel.SetSecretNumber();
                HttpContext.Session.SetInt32("session", generatedNumber);
            }

            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int number)
        {
            ViewBag.Message = GGModel.UserGuessResult(number, HttpContext.Session.GetInt32("session"));

            if(GGModel.CorrectGuess == true)
            {
                int generatedNumber = GGModel.SetSecretNumber();
                HttpContext.Session.SetInt32("session", generatedNumber);
            }

            return View(GGModel);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            int generatedNumber = GGModel.SetSecretNumber();
            HttpContext.Session.SetInt32("session", generatedNumber);

            ViewBag.Message = string.Empty;

            return View("GuessingGame", GGModel);
        }
    }
}
