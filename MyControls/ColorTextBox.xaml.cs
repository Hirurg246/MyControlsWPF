using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для ColorTextBox.xaml
    /// </summary>
    public partial class ColorTextBox : TextBox
    {
        protected int val = 0;
        protected bool hexMode = false;
        protected bool chTextFlag = false;
        public int Val
        {
            get => val;
            set
            {
                if (value < 0) value = 0;
                else if (value > 255) value = 255;
                val = value;
                RefreshText();
                ColorComponentChanged?.Invoke();
            }
        }
        public bool HexMode
        {
            get => hexMode;
            set
            {
                hexMode = value;
                RefreshText();
            }
        }
        public ColorTextBox()
        {
            InitializeComponent();
        }

        public delegate void CTBHandler();
        public event CTBHandler ColorComponentChanged;

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (chTextFlag) return;
            if (string.IsNullOrWhiteSpace(Text)) Val = 0;
            else if (HexMode)
            {
                if (int.TryParse(Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int newVal))
                    Val = newVal;
                else RefreshText();
            }
            else
            {
                if (int.TryParse(Text, out int newVal))
                    Val = newVal;
                else RefreshText();
            }
        }

        public void RefreshText()
        {
            chTextFlag = true;
            if (HexMode) Text = Val.ToString("X");
            else Text = Val.ToString();
            CaretIndex = Text.Length;
            chTextFlag = false;
        }
    }
}
