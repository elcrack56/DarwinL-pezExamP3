using DarwinLópezExamenP3.Data;
using DarwinLópezExamenP3.Models;
using DarwinLópezExamenP3.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DarwinLópezExamenP3.ViewModels
{
    public class SegundaPageViewModel : BaseViewModel
    {
        private readonly AeropuertoDataBase _database;

        public ObservableCollection<DLopezAeropuerto> Aeropuertos { get; }

        public SegundaPageViewModel(AeropuertoDataBase database)
        {
            _database = database;
            Aeropuertos = new ObservableCollection<DLopezAeropuerto>();
            _ = CargarAeropuertosAsync();
        }

        private async Task CargarAeropuertosAsync()
        {
            var aeropuertos = await _database.GetAeropuertosAsync();
            Aeropuertos.Clear();

            foreach (var aeropuerto in aeropuertos)
            {
                Aeropuertos.Add(aeropuerto);
            }
        }
    }
}
