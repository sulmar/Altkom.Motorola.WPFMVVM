using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Altkom.Motorola.Framework
{
    public interface INavigationService
    {
        void GoForward();
        void GoBack();
        void Navigate(string page, object parameter = null);

        object Parameter { get; }
    }

    public class FrameNavigationService : INavigationService
    {
        public object Parameter => throw new NotImplementedException();

        public void GoBack() => GetFrame().GoBack();
        public void GoForward() => GetFrame().GoForward();

        private Frame frame;

        public void Navigate(string page, object parameter = null)
        {
            Frame frame = GetFrame();

            Uri uri = new Uri($"../Views/{page}View.xaml", UriKind.Relative);

            frame.Navigate(uri, parameter);
        }

        private Frame GetFrame()
        {
            if (frame==null)
            {
                frame = RecurseChildren<Frame>(Application.Current.MainWindow)
                .FirstOrDefault(f => f.Name == "LeftFrame");
            }

            return frame;

        }

        private static IEnumerable<T> RecurseChildren<T>(DependencyObject root)
            where T : UIElement
        {
            if (root is T)
            {
                yield return root as T;
            }

            if (root!=null)
            {
                var count = VisualTreeHelper.GetChildrenCount(root);

                for (int index = 0; index < count; index++)
                {
                    foreach (var child in RecurseChildren<T>(VisualTreeHelper.GetChild(root, index)))
                    {
                        yield return child;
                    }
                }
            }
        }
    }
}
