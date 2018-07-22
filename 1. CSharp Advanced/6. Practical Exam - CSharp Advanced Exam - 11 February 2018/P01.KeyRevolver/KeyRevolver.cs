namespace P01.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(ReadCollection());
            var locks = new Queue<int>(ReadCollection());

            var intelValue = int.Parse(Console.ReadLine());

            var startingBullets = bullets.Count;

            var bulletsInBarrel = barrelSize;

            while (true)
            {
                if (locks.Count == 0)
                {
                    var earnedMoney = intelValue - bulletPrice * (startingBullets - bullets.Count);

                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
                    break;
                }

                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

                Shoot(bullets, locks);

                bulletsInBarrel--;

                if (bulletsInBarrel == 0 && bullets.Any())
                {
                    bulletsInBarrel = barrelSize;

                    Console.WriteLine("Reloading!");
                }
            }
        }

        private static IEnumerable<int> ReadCollection()
        {
            return Console.ReadLine().Split().Select(int.Parse);
        }

        private static void Shoot(Stack<int> bullets, Queue<int> locks)
        {
            var currentBullet = bullets.Pop();
            var currentLock = locks.Peek();

            if (currentBullet <= currentLock)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
                return;
            }

            Console.WriteLine("Ping!");
        }
    }
}