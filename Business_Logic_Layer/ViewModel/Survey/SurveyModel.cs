using Business_Logic_Layer.ViewModel.Question;
using Data_Access_Layer.Context.SurveyModels.EntityModel;

namespace Business_Logic_Layer.ViewModel.Survey
{
	public class SurveyViewModel
	{
		public Guid PublicIdentifier { get; set; }

		public string Title { get; set; }

		public string? Description { get; set; }

		public List<QuestionViewModel>? Questions { get; set; }

		public string Owner { get; set; }

		public statusEnum Status { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime EndDate { get; set; }
	}

	public class SurveyAddModel
	{
		public string Title { get; set; }

		public string? Description { get; set; }

		public string Owner { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime EndDate { get; set; }
	}

	public class SurveyUpdateModel
	{
		public string Title { get; set; }

		public string? Description { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime EndDate { get; set; }
	}
}