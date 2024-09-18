using Microsoft.AspNetCore.Mvc;

namespace TheMutants.Controllers
{
    public class QuestionsController : Controller


    {

        private static Dictionary<string, string> Questions = new Dictionary<string, string>();

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
            Questions.Add(name, answer);

            return Redirect("/Questions");
        }
    }
}
