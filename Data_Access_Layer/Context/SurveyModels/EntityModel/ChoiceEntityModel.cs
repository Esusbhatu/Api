using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Context.SurveyModels.EntityModel
{
	[Index(nameof(Index))]
	public class ChoiceEntityModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int Index { get; set; }

		[Required]
		[MaxLength(128)]
		public string Choice { get; set; }

		[Required]
		public int QuestionId { get; set; }
		[Required]
		public QuestionEntityModel Question { get; set; }
	}
}
