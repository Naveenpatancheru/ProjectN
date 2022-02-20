using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectN.Application.Features.Colleges.Queries.GetCollegeDetail;
using ProjectN.Application.Features.Colleges.Queries.GetCollegesList;
using ProjectN.Application.Features.Colleges.Commands.CreateCollege;
using Microsoft.AspNetCore.Authentication.JwtBearer;


using ProjectN.Application.Contracts.Identity;
using ProjectN.Application.Models.Authentication;
using ProjectN.Identity.Models;
using ProjectN.Identity.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;
using ProjectN.Identity;


namespace ProjectN.Api.Controllers
{
    //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController : Controller
    {
        private readonly IMediator _mediator;
        
        public CollegeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("all", Name = "GetAllColleges")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CollegeListVm>>> GetAllColleges()
        {
            var dtos = await _mediator.Send(new GetCollegesListQuery());
            return Ok(dtos);
        }

    }
}
