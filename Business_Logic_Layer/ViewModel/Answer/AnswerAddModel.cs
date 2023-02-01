
namespace Business_Logic_Layer.ViewModel.Answer
{
    public class AnswerViewModel
    {

        public List<AnswerAddModel> Answers { get; set; }
    }


    public class AnswerAddModel
    {
        public int QuestionId { get; set; }

        public string Answer { get; set; }
    }
}
