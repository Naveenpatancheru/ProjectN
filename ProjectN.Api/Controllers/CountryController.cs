using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        //[HttpGet("all", Name = "GetAllCountries")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        //{
        //    var dtos = await _mediator.Send(new GetCategoriesListQuery());
        //    return Ok(dtos);
        //}
    }
}
