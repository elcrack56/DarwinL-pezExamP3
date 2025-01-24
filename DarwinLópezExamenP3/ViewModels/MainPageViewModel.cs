using System.Windows.Input;
using DarwinLópezExamenP3.Data;
using DarwinLópezExamenP3.Helpers;
using DarwinLópezExamenP3.Models;
using DarwinLópezExamenP3.Services;

namespace DarwinLópezExamenP3.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly AeropuertoService _aeropuertoService;
        private readonly AeropuertoDataBase _database;
        private string _searchText;
        private string _result;

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public ICommand BuscarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public MainPageViewModel(AeropuertoDataBase database)
        {
            _aeropuertoService = new AeropuertoService();
            _database = database;

            BuscarCommand = new Command(async () => await BuscarAeropuerto());
            LimpiarCommand = new Command(() => SearchText = string.Empty);
        }

        public MainPageViewModel()
        {
        }

        private async Task BuscarAeropuerto()
        {
            var aeropuerto = await _aeropuertoService.BuscarAeropuertoAsync(SearchText);
            if (aeropuerto != null)
            {
                aeropuerto.DLopez = "DLopez";
                await _database.SaveAeropuertoAsync(aeropuerto);
                Result = $"Aeropuerto encontrado: {aeropuerto.Nombre}";
            }
            else
            {
                Result = "No se encontró ningún aeropuerto.";
            }
        }
    }
}
