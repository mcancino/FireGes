using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            VoluntarioCargo = new HashSet<VoluntarioCargo>();
        }

        public int IdCargo { get; set; }
        public string DescripcionCargo { get; set; }

        public ICollection<VoluntarioCargo> VoluntarioCargo { get; set; }
    }
}
