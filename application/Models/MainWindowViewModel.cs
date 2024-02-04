using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using application.Commands;
using application.Models;
using application.Views;

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
        private ObservableCollection<CombinedData> _combinedDatas;
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
        private ObservableCollection<CombinedData> _filteredCombinedDatas;
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
        public ICommand EditCommand { get; }
        public MainWindowViewModel()
        {
            LoadDataCommand = new RelayCommand(obj => LoadData());
            SearchCommand = new RelayCommand(obj => Search());
            EditCommand = new RelayCommand(obj=>Edit());
            LoadData();
        }
        private void Search()
        {
            IsLoading = true;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                FilterData();
            };
            worker.RunWorkerCompleted += (sender, e) =>
            {
                IsLoading = false;
            };

            worker.RunWorkerAsync();
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }
        private int _numberOfRecords;
        public int NumberOfRecords
        {
            get { return _numberOfRecords; }
            set
            {
                if (_numberOfRecords != value)
                {
                    _numberOfRecords = value;
                    OnPropertyChanged(nameof(NumberOfRecords));
                }
            }
        }
        private void LoadData()
        {
            IsLoading = true;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                CombinedDatas = new CombinedDataViewModel().CombinedDatas;
               
                FilterData();
            };
            worker.RunWorkerCompleted += (sender, e) =>
            {
                IsLoading = false;
            };

            worker.RunWorkerAsync();
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
            NumberOfRecords = FilteredCombinedDatas.Count;
            return FilteredCombinedDatas;
        }

        private CombinedData _selectedCombinedData;

        public CombinedData SelectedCombinedData
        {
            get { return _selectedCombinedData; }
            set
            {
                if (_selectedCombinedData != value)
                {
                    _selectedCombinedData = value;
                    OnPropertyChanged(nameof(SelectedCombinedData));
                }
            }
        }
        private void Edit()
        {
            if (SelectedCombinedData != null)
            {
                EditUserControl editUserControl = new EditUserControl(SelectedCombinedData);
                editUserControl.ShowDialog();
                LoadData();
            }
        }

    }
}
