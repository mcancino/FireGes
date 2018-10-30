using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Comuna
    {
        public Comuna()
        {
            DireccionCompania = new HashSet<DireccionCompania>();
            DireccionCuerpo = new HashSet<DireccionCuerpo>();
            DireccionVoluntario = new HashSet<DireccionVoluntario>();
        }

        public int IdComuna { get; set; }
        public string NombreComuna { get; set; }

        public ICollection<DireccionCompania> DireccionCompania { get; set; }
        public ICollection<DireccionCuerpo> DireccionCuerpo { get; set; }
        public ICollection<DireccionVoluntario> DireccionVoluntario { get; set; }
    }
}
