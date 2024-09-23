using Microsoft.AspNetCore.Mvc;
using TheMutants.Data;
using TheMutants.Models;

namespace TheMutants.Controllers
{
    public class QuestionsController : Controller


    {

        private static List<Question> Questions = new List<Question>();

        public IActionResult Index()
        {

            ViewBag.questions = QuestionData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Questions/Add")]

        public IActionResult NewQuestion(Question newQuestion)
        {
            QuestionData.Add(newQuestion);

            return Redirect("/Questions");
        }

        public IActionResult Delete()
        {
            ViewBag.questions = QuestionData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] questionIds)
        {
            foreach (int questionId in questionIds)
            {
                QuestionData.Remove(questionId);
            }

            return Redirect("/Questions");

        }
    }
}
