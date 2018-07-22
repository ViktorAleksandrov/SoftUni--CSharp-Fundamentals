using System;

namespace P02.KingsGambit.Models
{
    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name) :
            base(name, "defending")
        {
        }

        public override void OnKingBeingAttacked()
        {
            Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }
    }
}
