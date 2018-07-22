using System;
using P05.KingsGambitExtended.Contracts;

namespace P05.KingsGambitExtended.Models
{
    public abstract class Subordinate : ISubordinate
    {
        public event DiedEventHandler Died;

        protected Subordinate(string name, string action, int health)
        {
            this.Name = name;
            this.Action = action;
            this.Health = health;
        }

        public string Name { get; }

        public string Action { get; }

        public int Health { get; private set; }

        public void TakeHit()
        {
            this.Health--;

            if (this.Health <= 0 && this.Died != null)
            {
                this.Died.Invoke(this);
            }
        }

        public virtual void OnKingBeingAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }
    }
}
