using Business_Logic_Layer.ViewModel.Choice;

namespace Business_Logic_Layer.ViewModel.Question
{
	public class QuestionViewModel
	{
		public int Id { get; set; }

		public int Index { get; set; }

		public bool Required { get; set; }

		public string QuestionText { get; set; }

		public QuestionTypeEnum QuestionType { get; set; }

		public List<ChoiceViewModel> Choices { get; set; }
	}

	public class QuestionAddModel
	{
        public int Index { get; set; }
        
		public bool Required { get; set; }

		public string QuestionText { get; set; }

		public QuestionTypeEnum QuestionType { get; set; }

		public List<ChoiceUpdateModel> Choices { get; set; }
	}

	public class QuestionUpdateModel
	{
        public int Index { get; set; }

        public bool Required { get; set; }

		public string QuestionText { get; set; }

		public QuestionTypeEnum QuestionType { get; set; }

		public List<ChoiceUpdateModel> Choices { get; set; }
	}
}
