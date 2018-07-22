namespace P05.KingsGambitExtended.Models
{
    public class Footman : Subordinate
    {
        public Footman(string name) :
            base(name: name, action: "panicking", health: 2)
        {
        }
    }
}
