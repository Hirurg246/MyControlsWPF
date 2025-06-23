using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MyControls
{
    public partial class ClockDigit : UserControl
    {
        protected static SolidColorBrush enaBrush = Brushes.Black,
                                         disBrush = Brushes.Transparent;
        protected static byte[] States =
        {
            0b0111_0111,    //0 на часах
            0b0001_0010,    //1 на часах
            0b0101_1101,    //2 на часах
            0b0101_1011,    //3 на часах
            0b0011_1010,    //4 на часах
            0b0110_1011,    //5 на часах
            0b0110_1111,    //6 на часах
            0b0101_0010,    //7 на часах
            0b0111_1111,    //8 на часах
            0b0111_1011     //9 на часах
        };
        protected int val = 0;

        public int Val
        {
            get => val;
            set
            {
                if (value < 0) value = 9;
                if (value > 9) value = 0;
                val = value;
                SetDigit();
            }
        }
        public ClockDigit()
        {
            InitializeComponent();
            SetDigit();
        }

        protected void SetDigit()
        {
            UPol.Fill   = (States[Val] & 0b0100_0000) != 0 ? enaBrush : disBrush;
            ULPol.Fill  = (States[Val] & 0b0010_0000) != 0 ? enaBrush : disBrush;
            URPol.Fill  = (States[Val] & 0b0001_0000) != 0 ? enaBrush : disBrush;
            MPol.Fill   = (States[Val] & 0b0000_1000) != 0 ? enaBrush : disBrush;
            LLPol.Fill  = (States[Val] & 0b0000_0100) != 0 ? enaBrush : disBrush;
            LRPol.Fill  = (States[Val] & 0b0000_0010) != 0 ? enaBrush : disBrush;
            LPol.Fill   = (States[Val] & 0b0000_0001) != 0 ? enaBrush : disBrush;
        }
    }
}
