using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectN.Application.Features.Colleges.Queries.GetCollegeDetail;
using ProjectN.Application.Features.Colleges.Queries.GetCollegesList;
using ProjectN.Application.Features.Colleges.Commands.CreateCollege;


namespace ProjectN.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController : Controller
    {
        private readonly IMediator _mediator;
        
        public CollegeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllColleges")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CollegeListVm>>> GetAllColleges()
        {
            var dtos = await _mediator.Send(new GetCollegesListQuery());
            return Ok(dtos);
        }

    }
}
