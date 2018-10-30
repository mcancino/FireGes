using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Compania
    {
        public Compania()
        {
            DireccionCompania = new HashSet<DireccionCompania>();
            Disponibilidad = new HashSet<Disponibilidad>();
            Voluntario = new HashSet<Voluntario>();
        }

        public int IdCompania { get; set; }
        public int IdCuerpo { get; set; }
        public string DenominacionCompania { get; set; }
        public string NombreFantasia { get; set; }

        public Cuerpo IdCuerpoNavigation { get; set; }
        public ICollection<DireccionCompania> DireccionCompania { get; set; }
        public ICollection<Disponibilidad> Disponibilidad { get; set; }
        public ICollection<Voluntario> Voluntario { get; set; }
    }
}
