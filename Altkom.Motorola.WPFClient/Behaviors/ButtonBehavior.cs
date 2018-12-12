using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Altkom.Motorola.WPFClient.Behaviors
{

    // PM> Install-Package System.Windows.Interactivity.WPF
    public class ButtonBehavior : Behavior<Button>
    {
        //public double Width { get; set; }

        // snippet: propdp
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(ButtonBehavior), new PropertyMetadata(100d));



        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;

            button.MouseEnter += Button_MouseEnter;
            
            base.OnAttached();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AssociatedObject.Width += Width;
        }
    }
}
