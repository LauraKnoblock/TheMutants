using Microsoft.AspNetCore.Mvc;
using TheMutants.Models;

namespace TheMutants.Controllers
{
    public class QuestionsController : Controller


    {

        private static List<Question> Questions = new List<Question>();

        public IActionResult Index()
        {

            ViewBag.questions = Questions;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Questions/Add")]

        public IActionResult NewQuestion(string name, string answer)
        {
            Questions.Add(new Question(name, answer));

            return Redirect("/Questions");
        }
    }
}
