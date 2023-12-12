using FsmDemo.Contracts;

namespace FsmDemo.Member.Core;

public class MemberService
{
    public MemberModel Register (string name, string password, string email)
    {
        return new MemberModel
        {
            Id = GetNewId(),
            Name = name,
            Email = email,
            PasswordHash = password,
            State = MemberState.START
        };
    }

    private int GetNewId ()
    {
        return new Random().Next(1, 99999);
    }
}