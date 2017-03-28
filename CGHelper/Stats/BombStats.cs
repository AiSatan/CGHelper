using System.Drawing;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Dota2AdInfo.Helpers;

namespace CGHelper.Stats
{
    internal class BombStats
    {
        private static int _seconds = 0;

        internal static void OnUpdate(Graphics g)
        {
            var bmpSource = Helper.GetBitmap(703, 3, 30, 10);

            const int defBombTime = 70; //35*2

            ImageStatistics stat = new ImageStatistics(bmpSource);

            var red = stat.Red.Mean;
            var green = stat.Green.Mean;
            var blue = stat.Blue.Mean;
            if (red > 30 && green < 76 && blue < 76)
            {
                _seconds--;
            }
            else
            {
                _seconds = defBombTime;
            }

            var bombStr = $"{_seconds / 2}";

            if (_seconds == defBombTime)
            {
                bombStr = "-";
            }

            var brush = Brushes.White;
            if (_seconds < 10)
            {
                brush = Brushes.Red;
            }
            g.DrawString($"{bombStr}", new Font("Console", 10), brush, 660, 460);
        }
    }
}
