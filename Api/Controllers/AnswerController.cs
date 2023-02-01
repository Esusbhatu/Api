using Business_Logic_Layer;
using Business_Logic_Layer.ViewModel.Answer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly Business_Logic_Layer.AnswerBLL answerBLL;
        public AnswerController()
        {
            this.answerBLL = new AnswerBLL();
        }

        [HttpPost]
        [Route("{PublicIdentifier:guid}")]
        public void AddAnswer([FromRoute] Guid PublicIdentifier, AnswerViewModel InComingData)
        {
            answerBLL.AddAnswer(PublicIdentifier, InComingData);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<AnswerAddModel>> GetAnswerBYId([FromRoute] int id)
        {
            var answer = await answerBLL.GetAnswerBYId(id);
            return Ok(answer);

        }
    }
}



