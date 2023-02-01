using Data_Access_Layer.Context;
using Data_Access_Layer.Context.SurveyModels.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class QuestionDAL
    {
        private readonly DBContext dbContext;

        public QuestionDAL()
        {
            this.dbContext = new DBContext();
        }
        public async Task<SurveyEntityModel> GetSurvey(Guid PublicIdentifier)
        {
            var survey = await dbContext.Survey.Where(s => s.PublicIdentifier == PublicIdentifier).Include(s => s.Questions).ThenInclude(a => a.Answers).FirstOrDefaultAsync();

            return survey;
        }
        public void  AddQuestion()
        {
             dbContext.SaveChangesAsync();

        }

        public async Task<QuestionEntityModel> GetQuestionById(int id)
        {
            var question = await dbContext.Question.Where(q => q.Id == id).Include(c => c.Choices).FirstOrDefaultAsync();

            return question;
        }

        public async Task<QuestionEntityModel> RemoveQuestion(int id)
        {
            var question = await GetQuestionById(id);

            if (question != null)
            {
                dbContext.Remove(question);
                await dbContext.SaveChangesAsync();

                return question;
            }

            else
            {
                return null;
            }


        }

    }
}
