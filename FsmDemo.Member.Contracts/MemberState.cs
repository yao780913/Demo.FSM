namespace FsmDemo.Contracts;

public enum MemberState : int
{
    UNDEFINED = 0,

    START,
    CREATED,
    ACTIVATED,
    DEACTIVED,
    ARCHIVED,
    END
}