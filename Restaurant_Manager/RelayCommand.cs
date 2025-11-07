using System;
using System.Windows.Input;

namespace Restaurant_Manager
{
    internal class RelayCommand : ICommand
    {
        private Action addItem;

        public RelayCommand(Action addItem)
        {
            this.addItem = addItem;
        }

        public RelayCommand(Action addItem, Func<bool> value)
        {
            this.addItem = addItem;
        }
    }
}