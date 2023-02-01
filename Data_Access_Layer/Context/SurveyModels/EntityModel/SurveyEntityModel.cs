using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Context.SurveyModels.EntityModel
{
	public class SurveyEntityModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public Guid PublicIdentifier { get; set; }

		[Required]
		[MaxLength(128)]
		public string Title { get; set; }

		[MaxLength(512)]
		public string? Description { get; set; }

		public List<QuestionEntityModel>? Questions { get; set; }

		[Required]
		[MaxLength(64)]
		public string Owner { get; set; }

		[Required]
		public statusEnum Status { get; set; }

		[Required]
		public DateTime? StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }
	}
}
