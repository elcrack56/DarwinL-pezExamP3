using DarwinLópezExamenP3.Models;
using DarwinLópezExamenP3.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DarwinLópezExamenP3.ViewModels
{
    public class SegundaPageViewModel
    {
        private readonly AeropuertoDatabase _aeropuertoDatabase;

        public ObservableCollection<DLopezAeropuerto> Aeropuertos { get; } = new ObservableCollection<DLopezAeropuerto>();

        public SegundaPageViewModel(AeropuertoDatabase aeropuertoDatabase)
        {
            _aeropuertoDatabase = aeropuertoDatabase;
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
    }
}
