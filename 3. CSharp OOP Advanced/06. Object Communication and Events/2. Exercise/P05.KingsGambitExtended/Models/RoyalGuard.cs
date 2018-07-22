using System;

namespace P05.KingsGambitExtended.Models
{
    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name) :
            base(name: name, action: "defending", health: 3)
        {
        }

        public override void OnKingBeingAttacked()
        {
            Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }
    }
}
