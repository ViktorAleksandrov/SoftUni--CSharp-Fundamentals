using System;
using System.Linq;
using System.Reflection;
using P09.InfernoInfinityRefactoring.Contracts;
using P09.InfernoInfinityRefactoring.Enums;

namespace P09.InfernoInfinityRefactoring.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string weaponName, string rarityType)
        {
            WeaponRarity rarity = Enum.Parse<WeaponRarity>(rarityType);

            var assembly = Assembly.GetCallingAssembly();

            Type classType = assembly.GetTypes().First(t => t.Name == weaponType);

            var classInstance = (IWeapon)Activator.CreateInstance(classType, weaponName, rarity);

            return classInstance;
        }
    }
}
