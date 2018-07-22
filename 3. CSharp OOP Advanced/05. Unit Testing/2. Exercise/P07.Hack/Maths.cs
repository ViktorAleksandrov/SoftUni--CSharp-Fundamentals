namespace P07.Hack
{
    public class Maths
    {
        public double Abs(double value)
        {
            return value < 0 ? value * -1 : value;
        }

        public double Floor(double value)
        {
            return value < 0 ? (int)value - 1 : (int)value;
        }
    }
}
