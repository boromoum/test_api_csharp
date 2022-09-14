using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers;

[ApiController]
[Route("api/Team/GetTeamMembers")]
[Produces("application/json")]
public class TeamMemberController : ControllerBase
{
    private readonly ILogger<TeamMemberController> _logger;

    public TeamMemberController(ILogger<TeamMemberController> logger)
    {
        _logger = logger;
    }

    List<TeamMember> teamMembers = new List<TeamMember>()
{
    new TeamMember{ Name="Ball", Address="phnom penh", Age=12 , Email="oumborom@gmail1.com", Gender="male"},
     new TeamMember{ Name="Jannie", Address="phnom penh", Age=13 , Email="oumborom@gmail2.com", Gender="female"},
};


    // GET: api/values
    [HttpGet]
    public IEnumerable<TeamMember> Get()
    {
        return teamMembers;
    }
}



