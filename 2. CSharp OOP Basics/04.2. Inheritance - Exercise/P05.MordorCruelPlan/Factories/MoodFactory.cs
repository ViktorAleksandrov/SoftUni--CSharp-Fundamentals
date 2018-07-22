using System.Collections.Generic;
using System.Linq;

public class MoodFactory
{
    public static Mood GetMood(List<Food> foods)
    {
        var totalHappiness = foods.Sum(f => f.HappinessPoints);

        if (totalHappiness < -5)
        {
            return new Angry();
        }
        else if (totalHappiness >= -5 && totalHappiness <= 0)
        {
            return new Sad();
        }
        else if (totalHappiness >= 1 && totalHappiness <= 15)
        {
            return new Happy();
        }
        else
        {
            return new JavaScript();
        }
    }
}