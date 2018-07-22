namespace DungeonsAndCodeWizards.Contracts
{
    using Models.Characters;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}