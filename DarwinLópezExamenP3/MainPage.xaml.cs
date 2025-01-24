using Microsoft.Maui.Controls;
using DarwinLópezExamenP3.ViewModels;

namespace DarwinLópezExamenP3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
