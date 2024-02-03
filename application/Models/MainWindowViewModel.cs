using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using application.Commands;
using application.Models;

namespace application.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _searchInput;
        private ObservableCollection<CombinedData> _combinedDatas;
        private ObservableCollection<CombinedData> _filteredCombinedDatas;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                if (_searchInput != value)
                {
                    _searchInput = value;
                    FilterData();
                    OnPropertyChanged(nameof(SearchInput));
                }
            }
        }

        public ObservableCollection<CombinedData> CombinedDatas
        {
            get { return _combinedDatas; }
            set
            {
                if (_combinedDatas != value)
                {
                    _combinedDatas = value;
                    FilterData();
                    OnPropertyChanged(nameof(CombinedDatas));
                }
            }
        }

        public ObservableCollection<CombinedData> FilteredCombinedDatas
        {
            get { return _filteredCombinedDatas; }
            set
            {
                if (_filteredCombinedDatas != value)
                {
                    _filteredCombinedDatas = value;
                    OnPropertyChanged(nameof(FilteredCombinedDatas));
                }
            }
        }
        public ICommand LoadDataCommand { get; }
        public ICommand SearchCommand { get; }

        public MainWindowViewModel()
        {
            LoadDataCommand = new RelayCommand(obj => LoadData());
            SearchCommand = new RelayCommand(obj => Search());
            LoadData();
        }

        private void Search()
        {
            FilterData();
        }

        private void LoadData()
        {
            CombinedDatas = new CombinedDataViewModel().CombinedDatas;
            FilterData();
        }

        private ObservableCollection<CombinedData> FilterData()
        {
            if (string.IsNullOrWhiteSpace(SearchInput))
            {
                FilteredCombinedDatas = CombinedDatas;
            }
            else
            {
                FilteredCombinedDatas = new ObservableCollection<CombinedData>(
                    CombinedDatas.Where(data =>
                        data.DepartmentName.Contains(SearchInput) ||
                        data.EmployeeFullName.Contains(SearchInput) ||
                        data.CityName.Contains(SearchInput) ||
                        data.PositionTitle.Contains(SearchInput)
                    )
                );
            }
            return FilteredCombinedDatas;
        }
    }
}
