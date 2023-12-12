using Microsoft.AspNetCore.Http;

namespace FsmDemo.Member.Core;

public class MemberServiceMiddle
{
    private readonly RequestDelegate _next;

    public MemberServiceMiddle (RequestDelegate next)
    {
        _next = next;
    }

    private bool PreProcessMemberService (HttpContext context, MemberService service)
    {
        if (context.Request.RouteValues["controller"] as string != "Member")
            return true;

        int? id = null;

        if (context.Request.RouteValues.ContainsKey("id")) id = int.Parse(context.Request.RouteValues["id"] as string);

        string? actionName = null;

        var endpoint = context.GetEndpoint();

        if (endpoint != null)
        {
            var action = (from x in endpoint.Metadata
                where x is MemberServiceActionAttribute
                select x as MemberServiceActionAttribute).FirstOrDefault();

            Console.WriteLine($"Action: {action.ActionName}");
            actionName = action.ActionName;
        }

        if (!service.FsmRuleCheck(id, actionName))
            return false;

        return true;
    }

    public async Task Invoke (HttpContext context, MemberService service)
    {
        try
        {
            if (!PreProcessMemberService(context, service)) await _next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("MemberStateMachineException: " + e.Message);
        }
    }
}