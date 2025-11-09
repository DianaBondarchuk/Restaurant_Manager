using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Restaurant_Manager.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
    public ObservableCollection<Restaurant_Manager.Entity.MenuItem> MenuItems { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

