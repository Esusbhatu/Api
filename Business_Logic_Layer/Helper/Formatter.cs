using Business_Logic_Layer.ViewModel.Choice;
using Business_Logic_Layer.ViewModel.Question;
using Business_Logic_Layer.ViewModel.Survey;
using Data_Access_Layer.Context.SurveyModels.EntityModel;

namespace Business_Logic_Layer.Helper
{
	internal class Formatter
	{
		public static SurveyViewModel formatSurvey(SurveyEntityModel survey)
		{
			if (survey != null)
			{
				SurveyViewModel formattedSurvey = new SurveyViewModel()
				{
					PublicIdentifier = survey.PublicIdentifier,
					Title = survey.Title,
					Description = survey.Description,
					Questions = new List<QuestionViewModel>(),
					Owner = survey.Owner,
					Status = survey.Status,
					StartDate = survey.StartDate,
					EndDate = survey.EndDate,
				};

				if (survey.Questions != null)
				{
					foreach (QuestionEntityModel question in survey.Questions)
					{
						formattedSurvey.Questions.Add(new QuestionViewModel()
						{
							Id = question.Id,
							Index = question.Index,
							QuestionText = question.QuestionText,
							QuestionType = (ViewModel.Question.QuestionTypeEnum)question.QuestionType,
							Choices = new List<ChoiceViewModel>(),
							Required = question.Required
						});

						foreach (ChoiceEntityModel choice in question.Choices)
						{
							formattedSurvey.Questions.Last().Choices.Add(new ChoiceViewModel()
							{
								Id = choice.Id,
								Index = choice.Index,
								Choice = choice.Choice
							});
						}
					}
				}
				return formattedSurvey;
			}
			return null;
		}

		public static List<SurveyViewModel> formatSurvey(List<SurveyEntityModel> surveyList)
		{
			if (surveyList != null)
			{
				List<SurveyViewModel> formattedSurveyList = new List<SurveyViewModel>();
				foreach (SurveyEntityModel survey in surveyList)
				{
					SurveyViewModel formattedSurvey = new SurveyViewModel()
					{
						PublicIdentifier = survey.PublicIdentifier,
						Title = survey.Title,
						Description = survey.Description,
						Questions = new List<QuestionViewModel>(),
						Owner = survey.Owner,
						Status = survey.Status,
						StartDate = survey.StartDate,
						EndDate = survey.EndDate,
					};

					if (survey.Questions != null)
					{
						foreach (QuestionEntityModel question in survey.Questions)
						{
							formattedSurvey.Questions.Add(new QuestionViewModel()
							{
								Id = question.Id,
								Index = question.Index,
								QuestionText = question.QuestionText,
								QuestionType = (ViewModel.Question.QuestionTypeEnum)question.QuestionType,
								Choices = new List<ChoiceViewModel>(),
								Required = question.Required
							});

							foreach (ChoiceEntityModel choice in question.Choices)
							{
								formattedSurvey.Questions.Last().Choices.Add(new ChoiceViewModel()
								{
									Id = choice.Id,
									Index = choice.Index,
									Choice = choice.Choice
								});
							}
						}
					}
					formattedSurveyList.Add(formattedSurvey);
				}
				return formattedSurveyList;
			}
			return null;
		}

		public static QuestionViewModel formatQuestion(QuestionEntityModel question)
		{
			if (question != null)
			{
				var getQuestion = new QuestionViewModel()
				{
					Id = question.Id,
					Index = question.Index,
					QuestionText = question.QuestionText,
					QuestionType = (Business_Logic_Layer.ViewModel.Question.QuestionTypeEnum)question.QuestionType,
					Choices = new List<ChoiceViewModel>(),
					Required = question.Required
				};

				foreach (ChoiceEntityModel choice in question.Choices)
				{
					getQuestion.Choices.Add(new ChoiceViewModel()
					{
						Id = choice.Id,
						Index = choice.Index,
						Choice = choice.Choice
					});
				}
				return getQuestion;
			}
			return new QuestionViewModel();
		}
	}
}