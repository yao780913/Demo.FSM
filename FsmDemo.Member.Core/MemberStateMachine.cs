using FsmDemo.Contracts;

namespace FsmDemo.Member.Core;

public class MemberStateMachine
{
    private List<(string actionName, MemberState? initialState, MemberState? finalState, string[] allowIdnetityTypes)> _fsmList = new();

    public MemberStateMachine ()
    {
        this._fsmList.Add(("register", MemberState.START, MemberState.CREATED, new string[] { "USER" }));
        this._fsmList.Add(("activate", MemberState.CREATED, MemberState.ACTIVATED, new string[] { "USER" }));
        this._fsmList.Add(("soft-delete", MemberState.ACTIVATED, MemberState.ARCHIVED, new string[] { "USER", "STAFF" }));
        this._fsmList.Add(("soft-delete", MemberState.DEACTIVED, MemberState.ARCHIVED, new string[] { "USER", "STAFF" }));
        
        // ...
    }

    /// <summary>
    /// only for major API, major API without state change
    /// </summary>
    /// <param name="currentState"></param>
    /// <param name="actionName"></param>
    /// <param name="identityType"></param>
    /// <returns></returns>
    public (bool result, MemberState? initState, MemberState? finalState) CanExecute (
        MemberState currentState,
        string actionName,
        string identityType)
    {
        foreach (var (_, _, finalState, _) in from r in this._fsmList
                 where r.actionName == actionName
                       && (r.initialState == null || r.initialState == currentState)
                       && r.allowIdnetityTypes.Contains(identityType)
                 select r)
        {
            Console.WriteLine($"* FSM: can not execute action({actionName}) in current member state({currentState}) with token identity type({identityType}) and specified init state({currentState})");
            return (true, currentState, finalState: finalState);
        }
        
        return (false, null, null);
    }
    
    /// <summary>
    /// only for non specified member API
    /// </summary>
    /// <param name="actionName"></param>
    /// <param name="identityType"></param>
    /// <returns></returns>
    public bool CanExecute (string actionName, string identityType)
    {
        if ((from r in this._fsmList
                where r.actionName == actionName
                      && r.allowIdnetityTypes.Contains(identityType)
                select r).Any())
        {
            return true;
        }
        Console.WriteLine($"* FSM: can not execute action({actionName}) in current token identity type({identityType})");
        return false;
    }
}