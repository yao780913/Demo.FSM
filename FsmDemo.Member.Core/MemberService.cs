using FsmDemo.Contracts;

namespace FsmDemo.Member.Core;

public class MemberService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <param name="email"></param>
    /// <returns></returns>
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