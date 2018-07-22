namespace P02.Cars
{
    using System;

    class StartUp
    {
        static void Main()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
        }
    }
}