
using Business_Logic_Layer.ViewModel.Answer;
using Data_Access_Layer;
using Data_Access_Layer.Context.SurveyModels.EntityModel;

namespace Business_Logic_Layer
{
    public class AnswerBLL
    {
        private readonly Data_Access_Layer.AnswerDAL? answerDal;

        public AnswerBLL()
        {
            this.answerDal = new AnswerDAL();
        }
        public async void AddAnswer(Guid PublicIdentifier, AnswerViewModel InComingData)
        {
            var survey = await answerDal.GetSurvey(PublicIdentifier);
            if (survey != null)
            {
                foreach (var ans in InComingData.Answers)
                {
                    var question = survey.Questions.Find(q => q.Id == ans.QuestionId);

                    question.Answers.Add(new AnswerEntityModel
                    {
                        Answer = ans.Answer,
                    });
                }

                answerDal.AddAnswer();

            }

        }
        public Task<AnswerEntityModel> GetAnswerBYId(int id)
        {
            var answer = answerDal.GetAnswerBYId(id);

            return answer;
        }
    }
}
