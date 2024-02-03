using application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace application.ViewModels
{
    public class CityDictionaryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CityDictionary> _cityDictionaries;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
