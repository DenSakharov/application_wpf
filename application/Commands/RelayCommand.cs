using System;
using System.Windows.Input;

namespace application.Commands
{
    /// <summary>
    /// Реализация интерфейса ICommand для создания команд, которые привязаны к элементам управления
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        /// <summary>
        /// Инициализирует новый экземпляр класса RelayCommand
        /// </summary>
        /// <param name="execute">Делегат, представляющий метод, который вызывается при выполнении команды</param>
        /// <param name="canExecute">Делегат, представляющий метод, который вызывается для проверки возможности выполнения команды</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        /// <summary>
        /// Определяет, может ли команда выполниться
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>True, если команда может быть выполнена, иначе - False</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        /// <summary>
        /// Выполняет логику команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        /// <summary>
        /// Событие, вызываемое при изменении возможности выполнения команды
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
