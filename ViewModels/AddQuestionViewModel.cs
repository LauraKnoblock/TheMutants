using System.ComponentModel.DataAnnotations;

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
    }
}
