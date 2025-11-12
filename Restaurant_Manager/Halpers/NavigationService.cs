using System;
using System.Windows.Controls;

namespace RestaurantManagement.Helpers
{
    public class NavigationService
    {
        private readonly ContentControl _contentControl;

        public NavigationService(ContentControl contentControl)
        {
            _contentControl = contentControl ?? throw new ArgumentNullException(nameof(contentControl));
        }

        public void Navigate(UserControl newView)
        {
            _contentControl.Content = newView;
        }
    }
}
