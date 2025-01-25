using Newtonsoft.Json;

namespace DarwinLópezExamenP3.Models
{
    public class Locacion
    {
        [JsonProperty("latitud")]
        public double Latitud { get; set; }

        [JsonProperty("longitud")]
        public double Longitud { get; set; }
    }

    public class ContactoInformacion
    {
        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("Sitio web")]
        public string SitioWeb { get; set; }
    }

    public class Aeropuertos
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("locacion")]
        public Location Locacion { get; set; }

        [JsonProperty("ciudad")]
        public string Ciudad { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("zona tiempal")]
        public string Zona { get; set; }

        [JsonProperty("contactoInformacion")]
        public ContactoInformacion ContactoInformacion { get; set; }
    }

}
