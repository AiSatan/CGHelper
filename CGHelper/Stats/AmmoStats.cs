using System.Drawing;
using Accord.Imaging.Filters;
using Red.BitmapHelpers;

namespace CGHelper.Stats
{
    internal class AmmoStats
    {
        internal static void OnUpdate(Graphics g)
        {
            var bmpSource = RedHelper.GetCopyFromScreen(1268, 855, 40, 40);

            var grayscaleFilter = new Grayscale(0.0125, 0.0154, 0.0021);
            var bmp = grayscaleFilter.Apply(bmpSource);

            var grayRemover = new SISThreshold();
            grayRemover.ApplyInPlace(bmp);

            var resizer = new ResizeBicubic(20, 20);
            bmp = resizer.Apply(bmp);
            g.DrawImage(bmp, 750, 400);
        }
    }
}
