namespace FsmDemo.Contracts;

public class MemberModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public MemberState State { get; set; }
}