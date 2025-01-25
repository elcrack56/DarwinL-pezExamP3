using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
using SQLite;
using DarwinLópezExamenP3.Models;

namespace DarwinLópezExamenP3.ViewModels
{
    public class PrimeraPaginaBusquedasDlopezViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyNombre) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNombre));

        public ObservableCollection<Aeropuertos> Aeropuerto { get; } = new ObservableCollection<Aeropuertos>();
        private HttpClient cliente = new HttpClient();

        private SQLiteAsyncConnection database;
        private static readonly string DbPath = Path.Combine(FileSystem.AppDataDirectory, "DLopez.db");

        private string busquedaText;
        public string BusquedaText
        {
            get => busquedaText;
            set
            {
                if (busquedaText != value)
                {
                    busquedaText = value;
                    OnPropertyChanged(nameof(BusquedaText));
                }
            }
        }

        public PrimeraPaginaBusquedasDlopezViewModel()
        {
            database = new SQLiteAsyncConnection(DbPath);
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            await database.CreateTableAsync<DLopezAeropuerto>();
        }

        public Command BuscarAeropuertoCommand => new Command(async () => await BuscarAeropuerto());
        public Command LimpiarCommand => new Command(() =>
        {
            Aeropuerto.Clear();
            BusquedaText = string.Empty;
        });

        public async Task BuscarAeropuerto()
        {
            if (string.IsNullOrWhiteSpace(BusquedaText))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Por favor, ingresa el nombre del aeropuerto", "OK");
                return;
            }

            var respuesta = await cliente.GetAsync($"https://freetestapi.com/api/v1/airports?search={Uri.EscapeDataString(BusquedaText)}");

            var json = await respuesta.Content.ReadAsStringAsync();
            var aeropuertosDS = JsonConvert.DeserializeObject<List<Aeropuertos>>(json);

            if (aeropuertosDS != null && aeropuertosDS.Count > 0)
            {
                Aeropuerto.Clear();
                var aeropuertoLE = aeropuertosDS[0];
                Aeropuerto.Add(aeropuertoLE);

                var DLaeropuerto = new DLopezAeropuerto
                {
                    Nombre = aeropuertoLE.Nombre,
                    Pais = aeropuertoLE.Pais,
                    Latitud = aeropuertoLE.Locacion?.Latitude ?? 0,
                    Longitud = aeropuertoLE.Locacion?.Longitude ?? 0,
                    Email = aeropuertoLE.ContactoInformacion?.Correo ?? "No disponible",
                    Registradopor = "DLopez"
                };

                var existing = await database.Table<DLopezAeropuerto>()
                                             .Where(a => a.Nombre == DLaeropuerto.Nombre)
                                             .FirstOrDefaultAsync();

                if (existing == null)
                {
                    await database.InsertAsync(DLaeropuerto);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Sin resultados", "No se encontraron aeropuertos", "OK");
            }
        }
    }
}
