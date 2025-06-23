using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
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
    public partial class Clock : UserControl
    {
        protected Timer Timer = new Timer(1000);

        public Clock()
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
                    SOCD.Val = time.Second % 10;
                    STCD.Val = time.Second / 10;
                    MOCD.Val = time.Minute % 10;
                    MTCD.Val = time.Minute / 10;
                    HOCD.Val = time.Hour % 10;
                    HTCD.Val = time.Hour / 10;
                }));
        }
    }
}
