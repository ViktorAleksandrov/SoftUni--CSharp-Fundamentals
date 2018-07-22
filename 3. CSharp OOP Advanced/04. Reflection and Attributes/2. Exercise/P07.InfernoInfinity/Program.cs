using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity
{
    class Program
    {
        static void Main(string[] args)
        {
            var weapons = new Dictionary<string, IWeapon>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(';');

                string commandName = inputArgs[0];

                inputArgs = inputArgs.Skip(1).ToArray();

                switch (commandName)
                {
                    case "Create":
                        IWeapon weapon = CreateWeapon(inputArgs, weapons);
                        weapons[weapon.Name] = weapon;
                        break;
                    case "Add":
                        AddGem(inputArgs, weapons);
                        break;
                    case "Remove":
                        RemoveGem(inputArgs, weapons);
                        break;
                    case "Print":
                        PrintWeapon(inputArgs, weapons);
                        break;
                }
            }
        }

        private static IWeapon CreateWeapon(string[] inputArgs, Dictionary<string, IWeapon> weapons)
        {
            string[] weaponArgs = inputArgs[0].Split();

            string rarityType = weaponArgs[0];
            string weaponType = weaponArgs[1];

            Type classType = GetType(weaponType);

            string weaponName = inputArgs[1];

            WeaponRarity rarity = Enum.Parse<WeaponRarity>(rarityType);

            var weapon = (IWeapon)Activator.CreateInstance(classType, weaponName, rarity);

            return weapon;
        }

        private static void AddGem(string[] inputArgs, Dictionary<string, IWeapon> weapons)
        {
            string[] gemArgs = inputArgs[2].Split();

            string clarityType = gemArgs[0];
            string gemType = gemArgs[1];
            Type classType = GetType(gemType);

            GemClarity clarity = Enum.Parse<GemClarity>(clarityType);

            var gem = (IGem)Activator.CreateInstance(classType, clarity);

            string weaponName = inputArgs[0];
            int socketIndex = int.Parse(inputArgs[1]);

            weapons[weaponName].AddGem(gem, socketIndex);
        }

        private static void RemoveGem(string[] inputArgs, Dictionary<string, IWeapon> weapons)
        {
            string weaponName = inputArgs[0];
            int socketIndex = int.Parse(inputArgs[1]);

            weapons[weaponName].RemoveGem(socketIndex);
        }

        private static void PrintWeapon(string[] inputArgs, Dictionary<string, IWeapon> weapons)
        {
            string weaponName = inputArgs[0];

            IWeapon weapon = weapons[weaponName];

            Console.WriteLine(weapon);
        }

        private static Type GetType(string classType)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .First(t => t.Name == classType);

            return type;
        }
    }
}
