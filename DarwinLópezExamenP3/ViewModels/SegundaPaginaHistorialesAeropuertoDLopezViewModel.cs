using DarwinLópezExamenP3.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace DarwinLópezExamenP3.ViewModels
{
    public class SegundaPaginaHistorialesAeropuertoDLopezViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyNombre) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNombre));

        public ObservableCollection<string> Historial { get; } = new ObservableCollection<string>();
        private SQLiteAsyncConnection database;
        private static readonly string DbPath = Path.Combine(FileSystem.AppDataDirectory, "DLopez.db");

        public SegundaPaginaHistorialesAeropuertoDLopezViewModel()
        {
            database = new SQLiteAsyncConnection(DbPath);
            CargarHistorial();
        }

        private async void CargarHistorial()
        {
            var aeropuertosSL = await database.Table<DLopezAeropuerto>().ToListAsync();
            Historial.Clear();

            foreach (var aeropuertoDE in aeropuertosSL)
            {
                Historial.Add($"Nombre: {aeropuertoDE.Nombre} - Pais: {aeropuertoDE.Pais} - Latitud: {aeropuertoDE.Latitud} - Longitud: {aeropuertoDE.Longitud} - Correo: {aeropuertoDE.Email} - DLopez: {aeropuertoDE.Registradopor})");
            }
        }
    }
}
