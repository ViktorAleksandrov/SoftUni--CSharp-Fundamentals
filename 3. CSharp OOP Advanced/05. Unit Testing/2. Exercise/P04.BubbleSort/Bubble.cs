using System.Collections.Generic;

namespace P04.BubbleSort
{
    public class Bubble
    {
        public void Sort(IList<int> numbers)
        {
            if (numbers != null)
            {
                int length = numbers.Count;

                for (int i = 0; i < length - 1; i++)
                {
                    bool hasSwap = false;

                    for (int j = 0; j < length - i - 1; j++)
                    {
                        if (numbers[j] > numbers[j + 1])
                        {
                            int temp = numbers[j];
                            numbers[j] = numbers[j + 1];
                            numbers[j + 1] = temp;

                            hasSwap = true;
                        }
                    }

                    if (!hasSwap)
                    {
                        break;
                    }
                }
            }
        }
    }
}
