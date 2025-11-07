using System;
using System.Windows.Input;

namespace Restaurant_Manager.ViewModels
{
    internal class RelayCommand<T> : ICommand
    {
        private Action<object> login;

        public RelayCommand(Action<object> login)
        {
            this.login = login;
        }
    }
}