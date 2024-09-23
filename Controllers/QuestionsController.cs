using Microsoft.AspNetCore.Mvc;
using TheMutants.Data;
using TheMutants.Models;
using TheMutants.ViewModels;

namespace TheMutants.Controllers
{
    public class QuestionsController : Controller


    {

        private static List<Question> Questions = new List<Question>();

        public IActionResult Index()
        {

            List<Question> questions = new List<Question>(QuestionData.GetAll());
            return View(questions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddQuestionViewModel addQuestionViewModel = new AddQuestionViewModel();
            return View(addQuestionViewModel);
        }

        [HttpPost]

        public IActionResult Add(AddQuestionViewModel addQuestionViewModel)
        {
            Question newQuestion = new Question 
            {
                Name = addQuestionViewModel.Name,
                Answer = addQuestionViewModel.Answer,
            };

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
        [HttpPost]
        [Route("Questions/Edit/{questionId}")]
        public IActionResult Edit(int questionId)
        {
            Question editingQuestion = QuestionData.GetById(questionId);
            ViewBag.questionToEdit = editingQuestion;
            ViewBag.title = "Edit Question " + editingQuestion.Name + "(id = " + editingQuestion.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("Questions/Edit")]
        public IActionResult SubmitEditQuestionForm(int questionId, string name, string answer)
        {
            Question editingQuestion = QuestionData.GetById(questionId);
            editingQuestion.Name = name;
            editingQuestion.Answer = answer;
            return Redirect("/Questions");
        }
    }
}
