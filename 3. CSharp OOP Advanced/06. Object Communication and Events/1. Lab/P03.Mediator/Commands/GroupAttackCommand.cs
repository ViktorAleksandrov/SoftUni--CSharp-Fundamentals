public class GroupAttackCommand : ICommand
{
    private IAttackGroup group;

    public GroupAttackCommand(IAttackGroup group)
    {
        this.group = group;
    }

    public void Execute()
    {
        this.group.GroupAttack();
    }
}
