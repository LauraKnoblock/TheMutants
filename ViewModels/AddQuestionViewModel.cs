using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TheMutants.Models;

namespace TheMutants.ViewModels
{
    public class AddQuestionViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Answer is required")]
        [StringLength(500, ErrorMessage = "Answer too long!")]
        public string? Answer { get; set; }

        public QuestionCategory Category { get; set; }

        public List<SelectListItem> QuestionCategories { get; set; } = new List<SelectListItem>
   {
      new SelectListItem(QuestionCategory.History.ToString(), ((int)QuestionCategory.History).ToString()),
      new SelectListItem(QuestionCategory.Geography.ToString(), ((int)QuestionCategory.Geography).ToString()),
      new SelectListItem(QuestionCategory.Art.ToString(), ((int)QuestionCategory.Art).ToString()),
      new SelectListItem(QuestionCategory.Science.ToString(), ((int)QuestionCategory.Science).ToString())
   };
    }
}
