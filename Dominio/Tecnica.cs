using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tecnica
    {
        public int IdHatsu { get; set; }
        public int IdPersonaje { get; set; }
        public string Hatsu { get; set; }
        public string Descripcion { get; set; }

        // Relación inversa (opcional)
        public Personajes Personaje { get; set; }
    }
}
