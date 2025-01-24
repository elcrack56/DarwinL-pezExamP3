using DarwinLópezExamenP3.Data;

namespace DarwinLópezExamenP3
{
    public partial class AppShell : Shell
    {
        private readonly AeropuertoDataBase _database;

        public AppShell(AeropuertoDataBase database)
        {
            InitializeComponent();
            _database = database;

            Routing.RegisterRoute(nameof(SegundaPage), typeof(SegundaPage));
        }
    }
}

