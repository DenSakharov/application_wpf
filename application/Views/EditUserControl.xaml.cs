using application.Models;
using application.ViewModels;
using System.Windows;

namespace application.Views
{
    public partial class EditUserControl : Window
    {
        public EditUserControl(CombinedData data)
        {
            InitializeComponent();
            var viewModel = new EditViewModel(data);
            DataContext = viewModel;
            viewModel.RequestClose += (sender, e) => Close();
        }
    }
}
