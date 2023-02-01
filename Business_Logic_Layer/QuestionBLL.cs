using Business_Logic_Layer.Helper;
using Business_Logic_Layer.ViewModel.Question;
using Data_Access_Layer;
using Data_Access_Layer.Context.SurveyModels.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace Business_Logic_Layer
{
    public class QuestionBLL
    {
        private readonly Data_Access_Layer.QuestionDAL? questionDal;

        public QuestionBLL()
        {
            this.questionDal = new QuestionDAL();
        }
        public async void AddQuestion(Guid PublicIdentifier, QuestionAddModel InComingQuestion)
        {
            var survey = await questionDal.GetSurvey(PublicIdentifier);

            survey.Questions.Add(new QuestionEntityModel
            {
                Required = InComingQuestion.Required,
                QuestionText = InComingQuestion.QuestionText,
                QuestionType = (QuestionsTypeEnum)InComingQuestion.QuestionType,
                Choices = InComingQuestion.Choices.Select((c,i) => new ChoiceEntityModel()
                {
                    Choice = c.Choice,
                    Index = i,
                }).ToList(),

            });
            questionDal.AddQuestion();
        }

        public async Task<QuestionViewModel> GetQuestionById(int id)
        {
            var question = await questionDal.GetQuestionById(id);

            return Formatter.formatQuestion(question);
        }
        public async Task<QuestionViewModel> RemoveQuestion(int id)
        {
            var question = await questionDal.RemoveQuestion(id);

            return Formatter.formatQuestion(question);
        }

        public async Task<QuestionViewModel> UpdateQuestion([FromRoute] int id, QuestionUpdateModel UpdatedQuestion)
        {
            var questionDb = await questionDal.GetQuestionById(id);

            questionDb.Index = UpdatedQuestion.Index;
            questionDb.QuestionText = UpdatedQuestion.QuestionText;
            questionDb.Required= UpdatedQuestion.Required;
            questionDb.QuestionType = (QuestionsTypeEnum)UpdatedQuestion.QuestionType;

            for (var i = 0; i < UpdatedQuestion.Choices.Count; i++)
            {
                if (questionDb.Choices.Count > i)
                {
                    questionDb.Choices[i].Index = i;
                    questionDb.Choices[i].Choice = UpdatedQuestion.Choices[i].Choice;
                }
                else
                {
                    questionDb.Choices.Add(new ChoiceEntityModel
                    {
                        Index =i,
                        Choice = UpdatedQuestion.Choices[i].Choice,
                    });
                }
            }
            questionDal.AddQuestion();
            return Formatter.formatQuestion(questionDb);

        }

    }

 }

