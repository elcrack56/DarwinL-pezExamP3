using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinLópezExamenP3.Models
{
    public class DLopezAeropuerto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Email { get; set; }
        public string Registradopor { get; set; } = "Dlopez";
    }
}
