using System;
using System.Collections.Generic;
using System.Linq;
using P05.KingsGambitExtended.Contracts;

namespace P05.KingsGambitExtended.Models
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
            subordinate.Died += this.SubordinateDied;

            this.subordinates.Add(subordinate);
        }

        public ISubordinate GetSubordinate(string subordinateName)
        {
            ISubordinate subordinate = this.subordinates.First(s => s.Name == subordinateName);
            return subordinate;
        }

        public void GetAttacked()
        {
            this.OnBeingAttacked();
        }

        private void SubordinateDied(ISubordinate subordinate)
        {
            this.BeingAttacked -= subordinate.OnKingBeingAttacked;

            this.subordinates.Remove(subordinate);
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
