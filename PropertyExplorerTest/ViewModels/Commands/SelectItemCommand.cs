using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PropertyExplorerTest.ViewModels.Commands
{
    public class SelectItemCommand<IPropertyOperative> : ICommand
    {

        MainContainerViewModel VM;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SelectItemCommand(MainContainerViewModel vm)
        {
            VM = vm;
        }
        

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            //IPropertyOperative param = parameter as IPropertyOperative;
            VM.SelectModel((Defines.Interfaces.IPropertyOperative)parameter);
        }
    }
}
