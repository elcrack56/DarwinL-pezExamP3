using Newtonsoft.Json;
using DarwinLópezExamenP3.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace DarwinLópezExamenP3.Services
{
    public class AeropuertoServices
    {
        private const string BaseUrl = "https://freetestapi.com/api/v1/airports?search=";

        public async Task<DLopezAeropuerto?> ObtenerAeropuertoAsync(string nombreAeropuerto)
        {
            using var cliente = new HttpClient();
            var respuesta = await cliente.GetStringAsync($"{BaseUrl}{nombreAeropuerto}&limit=1");

            var aeropuertos = JsonConvert.DeserializeObject<List<DLopezAeropuerto>>(respuesta);

            if (aeropuertos != null && aeropuertos.Count > 0)
            {
                var aeropuerto = aeropuertos.First();
            
                return new DLopezAeropuerto
                {
                    Nombre = aeropuerto.Nombre,
                    Latitud = aeropuerto.Latitud,
                    Longitud = aeropuerto.Longitud,
                    Email = aeropuerto.Email,
                    Pais = aeropuerto.Pais, 
                    DLopez = "DLopez"
                };
            }

            return null;  
        }
    }
}

