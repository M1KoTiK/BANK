using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
#nullable enable
namespace BANK_Kargin.ViewModel
{

    public class ActionCommand : ICommand
    {
   
        public event EventHandler? CanExecuteChanged;
        Action action;
        private bool canExecuteCommand;
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }
            set
            {
                canExecuteCommand = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }
        public bool CanExecute(object? parameter)
        {
            return CanExecuteCommand;
        }

        public void Execute(object? parameter)
        {
            action?.Invoke();
        }
        public ActionCommand(Action action, bool canEx = true)
        {
            this.action = action;
            CanExecuteCommand = canEx;
        }

    }
}
