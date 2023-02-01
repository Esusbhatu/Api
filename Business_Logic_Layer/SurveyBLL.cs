using Business_Logic_Layer.Helper;
using Business_Logic_Layer.ViewModel;
using Business_Logic_Layer.ViewModel.Survey;
using Data_Access_Layer.Context.SurveyModels.EntityModel;
using System.ComponentModel.DataAnnotations;

namespace Business_Logic_Layer
{
	public class SurveyBLL
	{
		private Data_Access_Layer.SurveyDAL _DAL;
		public SurveyBLL()
		{
			_DAL = new Data_Access_Layer.SurveyDAL();
		}

		public async Task<List<SurveyViewModel>> GetSurveys()
		{
			List<SurveyEntityModel> SurveyList = await _DAL.GetSurveys();
			var currentDate = DateTime.Now.Date;
			foreach (SurveyEntityModel survey in SurveyList)
			{
				if (survey.StartDate <= currentDate && survey.Questions.Count != 0)
				{
					survey.Status = statusEnum.Published;
				}
				if (survey.EndDate < currentDate)
				{
					survey.Status = statusEnum.Closed;
				}
				if (survey.StartDate > currentDate)
				{
					survey.Status = statusEnum.Concept;
				}
				await _DAL.UpdateStatus();
			}

			return Formatter.formatSurvey(SurveyList);
		}

		public async Task<SurveyViewModel> GetSurvey(Guid PublicIdentifier)
		{
			SurveyEntityModel survey = await _DAL.GetSurvey(PublicIdentifier);

			return Formatter.formatSurvey(survey);
		}

		public async Task<SurveyViewModel> AddSurvey(SurveyAddModel InComingData)
		{
			SurveyEntityModel survey = new SurveyEntityModel()
			{
				PublicIdentifier = Guid.NewGuid(),
				Title = InComingData.Title,
				Description = InComingData.Description,
				Owner = InComingData.Owner,
				Status = statusEnum.Concept,
				StartDate = InComingData.StartDate,
				EndDate = InComingData.EndDate,
			};

			if (await _DAL.AddSurvey(survey))
			{
				return Formatter.formatSurvey(survey);
			}

			return null;
		}

		public async Task<SurveyViewModel> UpdateSurvey(Guid PublicIdentifier, SurveyUpdateModel InComingData)
		{
			SurveyEntityModel Survey = await _DAL.GetSurvey(PublicIdentifier);

			if (Survey != null)
			{
				Survey.Title = InComingData.Title;
				Survey.Description = InComingData.Description;
				Survey.Status = statusEnum.Concept;
				Survey.StartDate = InComingData.StartDate;
				Survey.EndDate = InComingData.EndDate;
				var currentDate = DateTime.Now.Date;

				if (Survey.StartDate <= currentDate && Survey.Questions.Count != 0)
				{
					Survey.Status = statusEnum.Published;
				}
				if (Survey.EndDate < currentDate)
				{
					Survey.Status = statusEnum.Closed;
				}

				await _DAL.UpdateSurvey();
				return Formatter.formatSurvey(Survey);
			}
			return null;
		}

		public async Task<SurveyViewModel> RemoveSurvey(Guid PublicIdentifier)
		{
			SurveyEntityModel survey = await _DAL.GetSurvey(PublicIdentifier);

			if (survey != null)
			{
				if (survey.Status != statusEnum.Published)
				{
					await _DAL.RemoveSurvey(PublicIdentifier, survey);
					return Formatter.formatSurvey(survey);
				}
				return null;
			}
			return null;
		}

		public async Task<List<SurveyViewModel>> SearchSurveys(SearchType SearchType, string SearchTerm)
		{
			List<SurveyEntityModel> survey = await _DAL.SearchSurveys(SearchType.ToString(), SearchTerm);

			return Formatter.formatSurvey(survey);
		}
	}
}