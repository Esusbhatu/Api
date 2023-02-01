using Business_Logic_Layer.ViewModel.Survey;
using Business_Logic_Layer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class SurveyController : Controller
	{
		private Business_Logic_Layer.SurveyBLL _BLL;

		public SurveyController()
		{
			_BLL = new Business_Logic_Layer.SurveyBLL();
		}

		[HttpGet]
		public async Task<ActionResult<List<SurveyViewModel>>> GetSurveys()
		{
			List<SurveyViewModel> survey = await _BLL.GetSurveys();
			if (survey != null)
			{
				return Ok(survey);
			}

			return NotFound();
		}

		[HttpGet]
		[Route("{PublicIdentifier:guid}")]
		public async Task<ActionResult<SurveyViewModel>> GetSurvey([FromRoute] Guid PublicIdentifier)
		{
			SurveyViewModel survey = await _BLL.GetSurvey(PublicIdentifier);

			if (survey != null)
			{
				return Ok(survey);
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<ActionResult<SurveyViewModel>> AddSurvey(SurveyAddModel InComingData)
		{
			if (InComingData != null)
			{
				SurveyViewModel survey = await _BLL.AddSurvey(InComingData);

				if (survey != null)
				{
					return Ok(survey);
				}

				return StatusCode(StatusCodes.Status500InternalServerError);
			}

			return BadRequest();
		}

		[HttpPut]
		[Route("{PublicIdentifier:guid}")]
		public async Task<ActionResult<SurveyViewModel>> UpdateSurvey([FromRoute] Guid PublicIdentifier, SurveyUpdateModel InComingData)
		{
			if (PublicIdentifier != null && InComingData != null)
			{
				SurveyViewModel survey = await _BLL.UpdateSurvey(PublicIdentifier, InComingData);
				if (survey != null)
				{
					return Ok(survey);
				}
				return NotFound();
			}

			return BadRequest();
		}

		[HttpDelete]
		[Route("{PublicIdentifier:guid}")]
		public async Task<ActionResult<SurveyViewModel>> RemoveSurvey([FromRoute] Guid PublicIdentifier)
		{
			if (PublicIdentifier != null)
			{
				SurveyViewModel survey = await _BLL.RemoveSurvey(PublicIdentifier);
				if (survey != null)
				{
					return Ok(survey);
				}
				return BadRequest();
			}

			return BadRequest();
		}

		[HttpGet]
		[Route("search/{SearchType}/{SearchTerm}")]
		public async Task<ActionResult<List<SurveyViewModel>>> SearchSurveys(SearchType SearchType, string SearchTerm = null)
		{
			if (SearchTerm.Length >= 3)
			{
				List<SurveyViewModel> survey = await _BLL.SearchSurveys(SearchType, SearchTerm);

				return Ok(survey);
			}
			else
			{
				return NotFound();
			}
		}
	}
}