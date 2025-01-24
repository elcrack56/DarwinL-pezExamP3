using DarwinLópezExamenP3.Data;
using System.IO;

namespace DarwinLópezExamenP3
{
    public partial class App : Application
    {
        private static AeropuertoDataBase _database;

        public static AeropuertoDataBase Database => _database ??= new AeropuertoDataBase(Path.Combine(FileSystem.AppDataDirectory, "aeropuerto.db3"));

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(Database);
        }
    }
}
