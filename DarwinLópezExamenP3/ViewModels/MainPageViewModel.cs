using DarwinLópezExamenP3.Models;
using DarwinLópezExamenP3.Services;
using DarwinLópezExamenP3.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DarwinLópezExamenP3.ViewModels
{
    public class MainPageViewModel
    {
        private readonly AeropuertoServices _aeropuertoService;
        private readonly AeropuertoDatabase _aeropuertoDatabase;

        public ObservableCollection<DLopezAeropuerto> Aeropuertos { get; } = new ObservableCollection<DLopezAeropuerto>();

        public MainPageViewModel(AeropuertoServices aeropuertoService, AeropuertoDatabase aeropuertoDatabase)
        {
            _aeropuertoService = aeropuertoService;
            _aeropuertoDatabase = aeropuertoDatabase;
        }

        public async Task BuscarAeropuertoAsync(string nombreAeropuerto)
        {
            var aeropuerto = await _aeropuertoService.ObtenerAeropuertoAsync(nombreAeropuerto);
            if (aeropuerto != null)
            {
                aeropuerto.DLopez = "DLopez"; 
                await _aeropuertoDatabase.GuardarAeropuertoAsync(aeropuerto); 
                await CargarAeropuertosAsync(); 
            }
        }

        public async Task CargarAeropuertosAsync()
        {
            var aeropuertos = await _aeropuertoDatabase.ObtenerAeropuertosAsync();
            Aeropuertos.Clear();
            foreach (var aeropuerto in aeropuertos)
            {
                Aeropuertos.Add(aeropuerto); 
            }
        }

        public void LimpiarAeropuertos()
        {
            Aeropuertos.Clear();
        }
    }
}
