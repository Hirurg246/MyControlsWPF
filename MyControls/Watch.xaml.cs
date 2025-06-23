using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyControls
{
    public partial class Watch : UserControl
    {
        protected Timer Timer = new Timer(1000);

        public Watch()
        {
            InitializeComponent();
            Timer.Elapsed += TimerElapsed;
            Timer.Enabled = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var time = DateTime.Now;
            Dispatcher.Invoke(
                DispatcherPriority.Normal,
                (Action)(() =>
                {
                    RotateSecond.Angle = 6 * time.Second;
                    RotateMinute.Angle = 6 * time.Minute + RotateSecond.Angle / 60;
                    RotateHour.Angle = 30 * (time.Hour % 12) + RotateMinute.Angle / 12;
                }));
        }
    }
}
