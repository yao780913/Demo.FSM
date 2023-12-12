using Microsoft.AspNetCore.Mvc;
using FsmDemo.Member.Core;

namespace FsmDemo.Member.Api.Controllers;

public class MemberController : ControllerBase
{
    private readonly ILogger<MemberController> _logger;
    private readonly MemberService _service;

    public MemberController (ILogger<MemberController> logger, MemberService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register ([FromForm] string name, [FromForm] string password, [FromForm] string email)
    {
        return Ok(_service.Register(name, password, email));
    }
}