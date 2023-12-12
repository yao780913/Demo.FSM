using FsmDemo.Contracts;

namespace FsmDemo.Member.Core;

public class MemberService
{
    private readonly MemberRepo _repo;
    private readonly MemberStateMachine _fcm;

    public MemberService (MemberRepo repo, MemberStateMachine fcm)
    {
        _repo = repo;
        _fcm = fcm;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public MemberModel? Register (string name, string password, string email)
    {
        if (!FsmRuleCheck(null, "register"))
            return null;
        
        return new MemberModel
        {
            Id = GetNewId(),
            Name = name,
            Email = email,
            PasswordHash = password,
            State = MemberState.START
        };
    }

    private bool FsmRuleCheck (int? id, string actionName)
    {
        if (id is not null)
        {
            if (!MemberRepo.Members.ContainsKey(id.Value))
                return false;
            
            if (!_fcm.CanExecute(
                    MemberRepo.Members[id.Value].State,
                    actionName).result)
            {
                return false;
            }
        }
        else
        {
            if (!_fcm.CanExecute(actionName))
            {
                return false;
            }
        }
        return true;
    }

    private int GetNewId ()
    {
        return new Random().Next(1, 99999);
    }
}