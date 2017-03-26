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

//            var grayscaleFilter = new Grayscale(0.0125, 0.0154, 0.0021);
//            var bmp = grayscaleFilter.Apply(bmpSource);
//
//            var grayRemover = new SISThreshold();
//            grayRemover.ApplyInPlace(bmp);
//
//            var resizer = new ResizeBicubic(20, 20);
//            bmp = resizer.Apply(bmp);


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
                _seconds = 400;
            }
            //g.DrawString($"{(int)red}:{(int)green}:{(int)blue}", new Font("Console", 10), Brushes.Red, 660, 760);

            //            }



            //            g.DrawString($"{Skills.TheSwarm.ToString()}: {data[(int)Skills.TheSwarm]}", new Font("Console", 10), Brushes.Red, 660, 660);
            //            g.DrawString($"{Skills.Shukuchi.ToString()}: {data[(int)Skills.Shukuchi]}", new Font("Console", 10), Brushes.Red, 660, 680);
            //            g.DrawString($"{Skills.Geminate.ToString()}: {data[(int)Skills.Geminate]}", new Font("Console", 10), Brushes.Red, 660, 700);
            //            g.DrawString($"{Skills.TimeLapse.ToString()}: {data[(int)Skills.TimeLapse]}", new Font("Console", 10), Brushes.Red, 660, 720);
            //g.DrawImage(bmpSource, 470, 400);
            if (_seconds == 400)
            {
                return;
            }
            g.DrawString($"{_seconds}", new Font("Console", 10), Brushes.Red, 660, 460);
        }
    }
}
