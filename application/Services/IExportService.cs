using application.Models;
using System.Collections.ObjectModel;

namespace application.Services
{
    public interface IExportService
    {
        void ExportToExcel(ObservableCollection<CombinedData> data, string filePath);
    }
}
