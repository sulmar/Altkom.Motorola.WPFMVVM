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

namespace Altkom.Motorola.WPFClient.UserControls
{
    /// <summary>
    /// Interaction logic for NumericPanel.xaml
    /// </summary>
    public partial class NumericPanel : UserControl
    {
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(NumericPanel), 
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault), OnNumberChanged);




        public Style NumericStyle
        {
            get { return (Style)GetValue(NumericStyleProperty); }
            set { SetValue(NumericStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumericStyleProperty =
            DependencyProperty.Register("NumericStyle", typeof(Style), typeof(NumericPanel), new PropertyMetadata());



        private static bool OnNumberChanged(object value)
        {
            return true;
        }

        public NumericPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            Number = button.Tag.ToString();

        }

    }
}
