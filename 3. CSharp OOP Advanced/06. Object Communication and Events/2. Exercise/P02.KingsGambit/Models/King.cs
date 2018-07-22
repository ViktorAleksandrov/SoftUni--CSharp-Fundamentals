using System;
using System.Collections.Generic;
using System.Linq;
using P02.KingsGambit.Contracts;

namespace P02.KingsGambit.Models
{
    public class King : IKing
    {
        public event BeingAttackedEventHandler BeingAttacked;

        private List<ISubordinate> subordinates;

        public King(string name)
        {
            this.Name = name;
            this.subordinates = new List<ISubordinate>();
        }

        public string Name { get; }

        public void AddSubordinate(ISubordinate subordinate)
        {
            this.BeingAttacked += subordinate.OnKingBeingAttacked;

            this.subordinates.Add(subordinate);
        }

        public void SubordinateDies(string subordinateName)
        {
            ISubordinate subordinate = this.subordinates.First(s => s.Name == subordinateName);

            this.BeingAttacked -= subordinate.OnKingBeingAttacked;

            this.subordinates.Remove(subordinate);
        }

        public void GetAttacked()
        {
            this.OnBeingAttacked();
        }

        private void OnBeingAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            if (this.BeingAttacked != null)
            {
                this.BeingAttacked.Invoke();
            }
        }
    }
}
