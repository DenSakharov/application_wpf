using application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace application.Views
{
    partial class CombinedDataView : UserControl
    {
        public CombinedDataView()
        {
            InitializeComponent();

            var combinedDataViewModel = new CombinedDataViewModel();

            DataContext = combinedDataViewModel;
        }
    }
}
