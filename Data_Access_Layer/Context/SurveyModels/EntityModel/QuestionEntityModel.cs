using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Context.SurveyModels.EntityModel
{
	[Index(nameof(Index))]
	public class QuestionEntityModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int Index { get; set; }

		[Required]
		public bool Required { get; set; }

		[Required]
		[MaxLength(128)]
		public string QuestionText { get; set; }

		[Required]
		public QuestionsTypeEnum QuestionType { get; set; }

		[Required]
		public List<ChoiceEntityModel> Choices { get; set; }

        public List<AnswerEntityModel>? Answers { get; set; }

        [Required]
		public int SurveyId { get; set; }
		[Required]
		public SurveyEntityModel Survey { get; set; }
	}
}
