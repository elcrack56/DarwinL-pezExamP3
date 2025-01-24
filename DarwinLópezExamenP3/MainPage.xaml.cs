using DarwinLópezExamenP3.ViewModels;

namespace DarwinLópezExamenP3
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent(); 
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private async void OnBuscarClicked(object sender, EventArgs e)
        {
            var nombreAeropuerto = AeropuertoNombres.Text;

            if (!string.IsNullOrEmpty(nombreAeropuerto))
            {
                var aeropuerto = await _viewModel.BuscarAeropuertoAsync(nombreAeropuerto);
                if (aeropuerto != null)
                {
                    // El aeropuerto fue guardado correctamente
                    await DisplayAlert("Éxito", "Aeropuerto encontrado y guardado.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró el aeropuerto.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Por favor ingresa el nombre del aeropuerto.", "OK");
            }
        }

    }


