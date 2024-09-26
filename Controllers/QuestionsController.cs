using Microsoft.AspNetCore.Mvc;
using TheMutants.Data;
using TheMutants.Models;
using TheMutants.ViewModels;

namespace TheMutants.Controllers
{
    public class QuestionsController : Controller


    {
        private QuestionDbContext context;

        public QuestionsController(QuestionDbContext dbContext)
        {
            context = dbContext;
        }

        private static List<Question> Questions = new List<Question>();

        public IActionResult Index()
        {

            List<Question> questions = context.Questions.ToList();
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
            if (ModelState.IsValid)
            {
                Question newQuestion = new Question
                {
                    Name = addQuestionViewModel.Name,
                    Answer = addQuestionViewModel.Answer,
                    Category = addQuestionViewModel.Category
                };

                context.Questions.Add(newQuestion);
                context.SaveChanges();

                return Redirect("/Questions");
            }
            return View(addQuestionViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.questions = context.Questions.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] questionIds)
        {
            foreach (int questionId in questionIds)
            {
                Question? theQuestion = context.Questions.Find(questionId);
                context.Questions.Remove(theQuestion);
            }

            context.SaveChanges();

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
