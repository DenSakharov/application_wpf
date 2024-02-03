using application.ViewModels;
using System.Windows.Controls;

namespace application.Views
{
    public partial class DepartmentView:UserControl
    {
        public DepartmentView()
        {
            InitializeComponent();

            var departmentViewModel = new DepartmentViewModel();

            DataContext = departmentViewModel;
        }
    }
}
