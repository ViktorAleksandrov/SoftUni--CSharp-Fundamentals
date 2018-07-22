using System;
using P02.KingsGambit.Contracts;

namespace P02.KingsGambit.Models
{
    public abstract class Subordinate : ISubordinate
    {
        protected Subordinate(string name, string action)
        {
            this.Name = name;
            this.Action = action;
        }

        public string Name { get; }

        public string Action { get; }

        public virtual void OnKingBeingAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }
    }
}
