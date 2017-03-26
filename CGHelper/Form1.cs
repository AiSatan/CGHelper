using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CGHelper.Stats;
using Dota2AdInfo;

namespace CGHelper
{
    public partial class Form1 : Form
    {
        internal static event Action<Graphics> OnUpdateFrame = delegate { };
        public Form1()
        {
            InitializeComponent();
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            ResizeRedraw = true;
            SetFormToTransparent();
            OnUpdateFrame += AmmoStats.OnUpdate;
            OnUpdateFrame += HealthStats.OnUpdate;
            OnUpdateFrame += BombStats.OnUpdate;
            var th = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(5);
                    if (InvokeRequired)
                    {
                        Invoke(new Action(Refresh));
                    }
                    else
                    {
                        Refresh();
                    }
                }
            });
            th.Start();
        }

        private void SetFormToTransparent()
        {
            Win32Delegates.SetWindowLong(Handle, (int)Win32Delegates.GWL.ExStyle, (int)Win32Delegates.WS_EX.Layered | (int)Win32Delegates.WS_EX.Transparent);

            //SetLayeredWindowAttributes(Handle, 0, 255 * (0 / 100), LWA.Alpha);
        }

        int i = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(Color.Black);

                OnUpdateFrame(e.Graphics);

                //var mp = GetCursorPosition();
                //var x = (int)mp.X - 20;
               // var y = (int)mp.Y - 20;

//                e.Graphics.DrawString($"x: {mp.X}, y: {mp.Y}", new Font("Console", 7), Brushes.Red, x, y-14);
                // e.Graphics.DrawString($"Shot! {++i}", new Font("Console", 40), Brushes.Red, 0, 0);
                //
                //e.Graphics.DrawRectangle(new Pen(Color.Red, 0.8f), x, y, 40, 40);
            }
            catch
            {
                // ignore 
            }
        }
    }
}
