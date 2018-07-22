namespace P6.TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class TrafficJam
    {
        public static void Main()
        {
            var carsLimit = int.Parse(Console.ReadLine());

            var carsQueue = new Queue<string>();

            var carCounter = 0;

            while (true)
            {
                var car = Console.ReadLine();

                if (car == "end")
                {
                    break;
                }

                if (car != "green")
                {
                    carsQueue.Enqueue(car);
                }
                else
                {
                    var length = Math.Min(carsLimit, carsQueue.Count);

                    for (int i = 0; i < length; i++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");

                        carCounter++;
                    }
                }
            }

            Console.WriteLine($"{carCounter} cars passed the crossroads.");
        }
    }
}