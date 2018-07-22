namespace P02.ClassBoxDataValidation
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine(box);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}