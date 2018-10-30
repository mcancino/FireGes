using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Citacion
    {
        public Citacion()
        {
            CitacionVoluntario = new HashSet<CitacionVoluntario>();
        }

        public int IdCitacion { get; set; }
        public int IdTipoCitacion { get; set; }
        public DateTime FechaCitacion { get; set; }

        public TipoCitacion IdTipoCitacionNavigation { get; set; }
        public ICollection<CitacionVoluntario> CitacionVoluntario { get; set; }
    }
}
