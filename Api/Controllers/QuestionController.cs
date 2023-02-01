using Business_Logic_Layer.ViewModel.Question;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly Business_Logic_Layer.QuestionBLL _question;
        public QuestionController()
        {
            this._question = new Business_Logic_Layer.QuestionBLL();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<QuestionViewModel>> GetQuestionById([FromRoute] int id)
        {
            var question = await _question.GetQuestionById(id);

            if(question != null) {
            
                 return Ok(question);
            }
            else
            {
                return NotFound();
            }

            
        }

        [HttpPost]
        [Route("{PublicIdentifier:guid}")]

        public void AddQuestion([FromRoute] Guid PublicIdentifier, QuestionAddModel InComingQuestion)
        {
           _question.AddQuestion(PublicIdentifier, InComingQuestion);

  
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<QuestionViewModel>> RemoveQuestion([FromRoute] int id)
        {
            var question = await _question.RemoveQuestion(id);

            if (question != null)
            {

                return Ok(question);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<QuestionViewModel>> UpdateQuestion([FromRoute] int id, QuestionUpdateModel UpdatedQuestion)
        {

            var question = await _question.UpdateQuestion(id, UpdatedQuestion);

            if (question != null)
            {

                return Ok(question);
            }
            else
            {
                return NotFound();
            }


        }


    }
}

