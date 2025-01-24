using DarwinLópezExamenP3.ViewModels;

namespace DarwinLópezExamenP3
{
    public partial class SegundaPage : ContentPage
    {
        private readonly SegundaPageViewModel _viewModel;

        public SegundaPage(SegundaPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CargarAeropuertosAsync();
        }
    }
}

