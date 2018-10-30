using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Cuerpo
    {
        public Cuerpo()
        {
            Compania = new HashSet<Compania>();
            DireccionCuerpo = new HashSet<DireccionCuerpo>();
        }

        public int IdCuerpo { get; set; }
        public int Rut { get; set; }
        public string DigitoVerificador { get; set; }
        public string Denominacion { get; set; }
        public string NombreFantasia { get; set; }

        public ICollection<Compania> Compania { get; set; }
        public ICollection<DireccionCuerpo> DireccionCuerpo { get; set; }
    }
}
