namespace Business_Logic_Layer.ViewModel.Choice
{
	public class ChoiceViewModel
	{
		public int Id { get; set; }

		public int Index { get; set; }

		public string Choice { get; set; }
	}

	public class ChoiceAddModel
	{
		public int Index { get; set; }

		public string Choice { get; set; }
	}

	public class ChoiceUpdateModel
	{
		public int Index { get; set; }

		public string Choice { get; set; }
	}
}
