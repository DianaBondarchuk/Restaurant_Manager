using System.Windows;
using Restaurant_Manager.ViewModels;
using Restaurant_Manager.Services;

namespace Restaurant_Manager.Views
{
    public partial class MenuView : Window
    {
        public MenuView()
        {
            InitializeComponent();
            DataContext = new MenuViewModel(new MenuItemService(new AppDbContext()));
        }
    }
}