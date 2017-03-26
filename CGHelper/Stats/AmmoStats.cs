using System.Drawing;
using Accord.Imaging.Filters;
using Dota2AdInfo.Helpers;

namespace CGHelper.Stats
{
    internal class AmmoStats
    {
        internal static void OnUpdate(Graphics g)
        {
            var bmpSource = Helper.GetBitmap(1268, 855, 40, 40);

            var grayscaleFilter = new Grayscale(0.0125, 0.0154, 0.0021);
            var bmp = grayscaleFilter.Apply(bmpSource);

            var grayRemover = new SISThreshold();
            grayRemover.ApplyInPlace(bmp);

            var resizer = new ResizeBicubic(20, 20);
            bmp = resizer.Apply(bmp);

            //            bool[] data = new bool[4];
            //            for (var i = 0; i < 4; i++)
            //            {
            //                Crop cropFilter = new Crop(new Rectangle(i * 92 + 20, 10, 92 - 27, bmp.Height - 50));
            //                var cropImage = cropFilter.Apply(bmp);
            //
            //                ImageStatistics stat = new ImageStatistics(cropImage);
            //
            //                var red = stat.Gray;
            //                data[i] = red.Mean > 50;
            //            }



            //            g.DrawString($"{Skills.TheSwarm.ToString()}: {data[(int)Skills.TheSwarm]}", new Font("Console", 10), Brushes.Red, 660, 660);
            //            g.DrawString($"{Skills.Shukuchi.ToString()}: {data[(int)Skills.Shukuchi]}", new Font("Console", 10), Brushes.Red, 660, 680);
            //            g.DrawString($"{Skills.Geminate.ToString()}: {data[(int)Skills.Geminate]}", new Font("Console", 10), Brushes.Red, 660, 700);
            //            g.DrawString($"{Skills.TimeLapse.ToString()}: {data[(int)Skills.TimeLapse]}", new Font("Console", 10), Brushes.Red, 660, 720);
            g.DrawImage(bmp, 750, 400);
        }
    }
}
