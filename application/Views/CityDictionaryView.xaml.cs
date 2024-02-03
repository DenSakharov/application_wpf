using application.ViewModels;
using System.Windows.Controls;

namespace application.Views
{
    public partial class CityDictionaryView:UserControl
    {
        public CityDictionaryView()
        {
            InitializeComponent();

            var cityDictionaryViewModel = new CityDictionaryViewModel();

            DataContext = cityDictionaryViewModel;
        }
    }
}
