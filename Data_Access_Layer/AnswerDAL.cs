using Data_Access_Layer.Context;
using Data_Access_Layer.Context.SurveyModels.EntityModel;
using Microsoft.EntityFrameworkCore;


namespace Data_Access_Layer
{
    public class AnswerDAL
    {
        private readonly DBContext dbContext;

        public AnswerDAL()
        {
            this.dbContext = new DBContext();
        }
        public async Task<SurveyEntityModel> GetSurvey(Guid PublicIdentifier)
        {
            var survey = await dbContext.Survey.Where(s => s.PublicIdentifier == PublicIdentifier).Include(s => s.Questions).ThenInclude(a => a.Answers).FirstOrDefaultAsync();

            return survey;
        }

        public void AddAnswer()
        {
            dbContext.SaveChangesAsync();
        }


        public Task<AnswerEntityModel> GetAnswerBYId(int id)
        {
            var answer = dbContext.Answer.Where(a => a.QuestionId == id).FirstOrDefaultAsync();

            return answer;
        }
    }

}
