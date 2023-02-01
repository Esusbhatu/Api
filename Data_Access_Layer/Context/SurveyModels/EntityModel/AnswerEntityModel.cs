using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Context.SurveyModels.EntityModel
{
    public class AnswerEntityModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Answer { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public QuestionEntityModel Question { get; set; }
    }
}
