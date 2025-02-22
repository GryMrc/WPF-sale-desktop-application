﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OverPay.Command
{
        public class RelayCommand : ICommand
        {
        readonly Action<object> _execute;
        readonly Func<object, bool> _canExecute;


            public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                if (_canExecute != null)
                {
                    return _canExecute(parameter);
                }
                else
                {
                    return false;
                }
            }

            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
        }
}
