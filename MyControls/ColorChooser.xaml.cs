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
    /// <summary>
    /// Логика взаимодействия для ColorChooser.xaml
    /// </summary>
    public partial class ColorChooser : UserControl
    {
        protected bool upColorFlag = false;

        public Color CurColor
        {
            get => Color.FromRgb((byte)RedCTB.Val, (byte)GreenCTB.Val, (byte)BlueCTB.Val);
            set
            {
                upColorFlag = true;
                RedCTB.Val = value.R;
                GreenCTB.Val = value.G;
                BlueCTB.Val = value.B;
                upColorFlag = false;
                UpdateColor();
            }
        }
        public ColorChooser()
        {
            InitializeComponent();
            RedCTB.ColorComponentChanged += UpdateColor;
            GreenCTB.ColorComponentChanged += UpdateColor;
            BlueCTB.ColorComponentChanged += UpdateColor;
        }

        public delegate void ColorChooserHandler(Color col);
        public event ColorChooserHandler ColorChanged;

        protected void UpdateColor()
        {
            if (upColorFlag) return;
            SolidColorBrush newBrush = new SolidColorBrush(CurColor);
            SmpRect.Fill = newBrush;
            ColorChanged?.Invoke(CurColor);
        }

        private void DecRB_Checked(object sender, RoutedEventArgs e) => ChngCTBMode(false);

        private void HexRB_Checked(object sender, RoutedEventArgs e) => ChngCTBMode(true);

        protected void ChngCTBMode(bool hexMode)
        {
            RedCTB.HexMode = GreenCTB.HexMode = BlueCTB.HexMode = hexMode;
        }
    }
}
