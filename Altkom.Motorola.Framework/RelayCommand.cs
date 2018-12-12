using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.Motorola.Framework
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;
        
        // private readonly Func<object, bool> canExecute;


        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        #region CommandManager

        //Add reference to PresentationCore

        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        CommandManager.RequerySuggested += value;
        //    }

        //    remove
        //    {
        //        CommandManager.RequerySuggested -= value;
        //    }
        //}

        #endregion



        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;
        
        public void Execute(object parameter) => execute(parameter);

        // return canExecute == null || canExecute.Invoke(parameter);

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }

    }
}
