namespace P05.MordorCruelPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var foodNames = Console.ReadLine().Split();

            var foods = new List<Food>();

            foreach (var foodName in foodNames)
            {
                Food food = FoodFactory.CreateFood(foodName);

                foods.Add(food);
            }

            var happinessPoints = foods.Sum(f => f.HappinessPoints);

            Mood mood = MoodFactory.GetMood(foods);

            Console.WriteLine(happinessPoints);
            Console.WriteLine(mood);
        }
    }
}