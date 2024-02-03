using application.Services;
using application.ViewModels;
using System.Windows;

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
    }
}
