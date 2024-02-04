using application.Services;
using application.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(); 
        }
        private void MenuItem_Print_Click(object sender, RoutedEventArgs e)
        {
            IExportService exportService = new ExcelExportService();
            exportService.ExportToExcel(((MainWindowViewModel)DataContext).FilteredCombinedDatas, "output.xlsx");
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                viewModel.EditCommand.Execute(null);
            }
        }
    }
}
