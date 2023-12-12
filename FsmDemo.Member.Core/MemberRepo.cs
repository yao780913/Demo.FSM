using FsmDemo.Contracts;

namespace FsmDemo.Member.Core;

public class MemberRepo
{
    protected internal static Dictionary<int, MemberModel> Members = new ()
    {
        {
            1,
            new MemberModel
            {
                Id = 1,
                Name = "Activated user",
                Email = "Bill@xxx.xxx",
                State = MemberState.ACTIVATED
            }
        },
        {
            2,
            new MemberModel
            {
                Id = 2,
                Name = "Start user",
                Email = "Fanisa@xxx.xxx",
                State = MemberState.START
            }
        },
    };
}