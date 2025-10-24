using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio
{
    public class Personajes
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdRol { get; set; }
        public int IdHabilidad { get; set; }
        public int? IdImagen { get; set; }


        public string ImagenUrl { get; set; }

        // Propiedades de navegación
        public RolProtagonico Rol { get; set; }
        public Habilidad Habilidad { get; set; }
        public Imagen Imagen { get; set; }

        // Lista opcional de técnicas (relación uno a muchos)
        public List<Tecnica> Tecnicas { get; set; }
    }
}
