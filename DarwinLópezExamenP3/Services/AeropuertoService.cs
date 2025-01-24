
using System.Net.Http.Json;
using DarwinLópezExamenP3.Models;

namespace DarwinLópezExamenP3.Services
{
    public class AeropuertoService
    {
        private readonly HttpClient _httpClient;

        public AeropuertoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<DLopezAeropuerto?> BuscarAeropuertoAsync(string name)
        {
            var response = await _httpClient.GetFromJsonAsync<List<DLopezAeropuerto>>(
                $"https://freetestapi.com/api/v1/airports?search={name}&limit=1");

            return response?.FirstOrDefault();
        }
    }
}
