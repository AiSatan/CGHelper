using System;
using System.Threading;
using CGHelper.Stats;
using RedOverUI;
using Timer = System.Timers.Timer;

namespace CGHelper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("CS:GO Helper running..");
            var timer = new Timer(500);
            timer.Elapsed += (sender, e) => RedOverlay.Refresh();
            
            RedOverlay.OnShown += () =>
            {
                // ReSharper disable once AccessToDisposedClosure
                timer?.Start();
                Console.Write("..done");
            };

            RedOverlay.OnUpdate += AmmoStats.OnUpdate;
            RedOverlay.OnUpdate += BombStats.OnUpdate;
            RedOverlay.OnUpdate += HealthStats.OnUpdate;

            //quit if we click Q
            while (Console.ReadKey().Key == ConsoleKey.Q)
            {
                
            }

            RedOverlay.OnUpdate -= AmmoStats.OnUpdate;
            RedOverlay.OnUpdate -= BombStats.OnUpdate;
            RedOverlay.OnUpdate -= HealthStats.OnUpdate;
            timer.Dispose();
            RedOverlay.Shutdown();
        }
    }
}
