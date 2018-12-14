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

namespace Altkom.Motorola.WPFDemo.Navigations
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();


        }

        private void Button_PageA_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("../Navigations/PageAView.xaml", UriKind.Relative);

            MainFrame.Navigate(uri);
        }

        private void Button_PageB_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("../Navigations/PageBView.xaml", UriKind.Relative);

            MainFrame.Navigate(uri);
        }
    }
}
