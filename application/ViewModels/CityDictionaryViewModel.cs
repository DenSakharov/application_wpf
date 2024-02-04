using application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace application.ViewModels
{
    /// <summary>
    /// ViewModel для управления данными справочника городов.
    /// </summary>
    public class CityDictionaryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CityDictionary> _cityDictionaries;
        /// <summary>
        /// Коллекция городов.
        /// </summary>
        public ObservableCollection<CityDictionary> CityDictionaries
        {
            get { return _cityDictionaries; }
            set
            {
                _cityDictionaries = value;
                OnPropertyChanged(nameof(CityDictionaries));
            }
        }

        public CityDictionaryViewModel()
        {
            using (var dbContext = new OracleDBContext())
            {
                CityDictionaries = new ObservableCollection<CityDictionary>(dbContext.CityDictionaries.ToList());
            }
        }
        /// <summary>
        /// Событие, уведомляющее об изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Вызывается при изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
