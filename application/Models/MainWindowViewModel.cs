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
        // Событие, оповещающее об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;
        // Метод для вызова события изменения свойства
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Строка поиска
        private string _searchInput;
        // Свойство для доступа к строке поиска
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
        // Коллекция для хранения всех данных
        private ObservableCollection<CombinedData> _combinedDatas;
        // Свойство для доступа к данным
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
        // Коллекция для хранения отфильтрованных данных
        private ObservableCollection<CombinedData> _filteredCombinedDatas;
        // Свойство для доступа к отфильтрованным данным
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
        // Команды для загрузки , выполнения поиска и редактирования данных
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
        // Метод для выполнения поиска
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
        // Признак загрузки данных
        private bool _isLoading;
        // Свойство для доступа к признаку загрузки
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
        // Количество записей после фильтрации
        private int _numberOfRecords;
        // Свойство для доступа к количеству записей
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
        // Метод загрузки данных
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
        // Метод для фильтрации данных
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
        // Выбранный элемент для редактирования
        private CombinedData _selectedCombinedData;
        // Свойство для доступа к выбранному элементу
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
        /// <summary>
        /// Метод для открытия редактирования
        /// </summary>
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
