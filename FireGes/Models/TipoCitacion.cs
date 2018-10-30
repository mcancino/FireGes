using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class TipoCitacion
    {
        public TipoCitacion()
        {
            Citacion = new HashSet<Citacion>();
        }

        public int IdTipoCitacion { get; set; }
        public string DescripcionTipoCitacion { get; set; }

        public ICollection<Citacion> Citacion { get; set; }
    }
}
