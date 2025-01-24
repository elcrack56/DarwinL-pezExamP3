using DarwinLópezExamenP3.ViewModels;
using DarwinLópezExamenP3.Data;

namespace DarwinLópezExamenP3
{
    public partial class SegundaPage : ContentPage
    {
        public SegundaPage(AeropuertoDataBase database)
        {
            InitializeComponent();
            BindingContext = new SegundaPageViewModel(database); 
        }
    }
}
