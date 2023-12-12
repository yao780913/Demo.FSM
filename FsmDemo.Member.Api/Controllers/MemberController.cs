using FsmDemo.Contracts;
using FsmDemo.Member.Core;
using Microsoft.AspNetCore.Mvc;

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
    [MemberServiceAction(ActionName = "register")]
    public IActionResult Register ([FromBody] MemberRegisterRequest request) =>
        Ok(_service.Register(request.Name, request.Password, request.Email));
}