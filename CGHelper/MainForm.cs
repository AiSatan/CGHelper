using CGHelper.Stats;
using RedOverUI;
using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Timers;

namespace CGHelper
{
    public partial class MainForm : Form
    {
        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _timer = new Timer(500);
            _timer.Elapsed += (s, a) => RedOverlay.Refresh();

            RedOverlay.OnShown += () =>
            {
                // ReSharper disable once AccessToDisposedClosure
                _timer?.Start();
            };

            RedOverlay.OnUpdate += AmmoStats.OnUpdate;
            RedOverlay.OnUpdate += BombStats.OnUpdate;
            RedOverlay.OnUpdate += HealthStats.OnUpdate;
        }

        private void Exit()
        {
            _timer.Dispose();

            RedOverlay.OnUpdate -= AmmoStats.OnUpdate;
            RedOverlay.OnUpdate -= BombStats.OnUpdate;
            RedOverlay.OnUpdate -= HealthStats.OnUpdate;
            RedOverlay.Shutdown();
            trayControl.Visible = false;
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }
            trayControl.Visible = false;
        }

        private void toolStripExitClick(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
