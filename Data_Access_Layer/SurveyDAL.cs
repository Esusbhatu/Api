using Data_Access_Layer.Context;
using Data_Access_Layer.Context.SurveyModels.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
	public class SurveyDAL
	{
		private readonly DBContext dbContext;

		public SurveyDAL()
		{
			this.dbContext = new DBContext();
		}

		public async Task<List<SurveyEntityModel>> GetSurveys()
		{
			List<SurveyEntityModel> survey = await dbContext.Survey.Include(s => s.Questions).ThenInclude(s => s.Choices).ToListAsync();

			return survey;
		}

		public async Task<bool> UpdateStatus()
		{
			return await dbContext.SaveChangesAsync() > 0;
		}

		public async Task<SurveyEntityModel> GetSurvey(Guid PublicIdentifier)
		{
			SurveyEntityModel survey = await dbContext.Survey.Where(s => s.PublicIdentifier == PublicIdentifier).Include(s => s.Questions).ThenInclude(s => s.Choices).FirstOrDefaultAsync();

			return survey;
		}

		public async Task<bool> AddSurvey(SurveyEntityModel InComingData)
		{
			await dbContext.Survey.AddAsync(InComingData);

			return await dbContext.SaveChangesAsync() > 0;
		}

		public async Task<bool> UpdateSurvey()
		{
			return await dbContext.SaveChangesAsync() > 0;
		}

		public async Task<SurveyEntityModel> RemoveSurvey(Guid PublicIdentifier, SurveyEntityModel survey)
		{
			if (survey != null)
			{
				dbContext.Remove(survey);
				await dbContext.SaveChangesAsync();

				return survey;
			}
			else
			{
				return null;
			}
		}

		public async Task<List<SurveyEntityModel>> SearchSurveys(string SearchType, string SearchTerm)
		{
			List<SurveyEntityModel> survey = new List<SurveyEntityModel>();
			switch (SearchType)
			{
				case "title":
					{
						survey = await dbContext.Survey.Where(S => S.Title.Contains(SearchTerm)).ToListAsync();
						break;
					}
				case "owner":
					{
						survey = await dbContext.Survey.Where(S => S.Owner.Contains(SearchTerm)).ToListAsync();
						break;
					}
				case "status":
					{
						survey = await dbContext.Survey.Where(S => S.Status == Enum.Parse<statusEnum>(SearchTerm, true)).ToListAsync();
						break;
					}
				case "startdate":
					{
						DateTime date = DateTime.Parse(SearchTerm);
						survey = await dbContext.Survey.Where(S => S.StartDate == date).ToListAsync();
						break;
					}
				case "enddate":
					{
						DateTime date = DateTime.Parse(SearchTerm);
						survey = await dbContext.Survey.Where(S => S.EndDate == date).ToListAsync();
						break;
					}
				default:
					{
						survey = new List<SurveyEntityModel>();
						break;
					}
			}

			return survey;
		}
	}
}