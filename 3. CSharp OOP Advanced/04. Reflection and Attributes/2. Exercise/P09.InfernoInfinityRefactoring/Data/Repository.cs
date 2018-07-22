using System.Collections.Generic;
using P09.InfernoInfinityRefactoring.Contracts;
using P09.InfernoInfinityRefactoring.IO;

namespace P09.InfernoInfinityRefactoring.Data
{
    public class Repository : IRepository
    {
        private readonly IDictionary<string, IWeapon> weapons;
        private readonly IWriter writer;

        public Repository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
            this.writer = new Writer();
        }

        public void CreateWeapon(IWeapon weapon)
        {
            this.weapons[weapon.Name] = weapon;
        }

        public void Add(string weaponName, int socketIndex, IGem gem)
        {
            this.weapons[weaponName].AddGem(gem, socketIndex);
        }

        public void Remove(string weaponName, int socketIndex)
        {
            this.weapons[weaponName].RemoveGem(socketIndex);
        }

        public void Print(string weaponName)
        {
            this.writer.WriteLine(this.weapons[weaponName].ToString());
        }
    }
}
