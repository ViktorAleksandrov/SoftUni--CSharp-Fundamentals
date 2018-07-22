namespace DungeonsAndCodeWizards.Contracts
{
    using Models.Characters;

    public interface IHealable
    {
        void Heal(Character character);
    }
}