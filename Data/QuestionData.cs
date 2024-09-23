using TheMutants.Controllers;
using TheMutants.Models;

namespace TheMutants.Data
{
    public class QuestionData
    {
        static private Dictionary<int, Question> Questions = new Dictionary<int, Question>();


        public static IEnumerable<Question> GetAll()
        {
            return Questions.Values;
        }

        public static void Add(Question newQuestion)
        {
            Questions.Add(newQuestion.Id, newQuestion);
        }

        public static void Remove(int id)
        {
            Questions.Remove(id);
        }

        public static Question GetById(int id)
        {
            return Questions[id];
        }
    }
}