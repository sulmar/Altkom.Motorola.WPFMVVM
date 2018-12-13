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
using System.Windows.Shapes;

namespace Altkom.Motorola.WPFDemo.Basic
{
    /// <summary>
    /// Interaction logic for RoutedEventsView.xaml
    /// </summary>
    public partial class RoutedEventsView : Window
    {
        public RoutedEventsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            Button button = e.Source as Button;

            MessageBox.Show($"Pressed {button.Content}");
            
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pressed 7!!!!");

            e.Handled = true;
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
