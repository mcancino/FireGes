using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class VoluntarioCargo
    {
        public int IdVoluntarioCargo { get; set; }
        public int IdCargo { get; set; }
        public int IdVoluntario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }

        public Cargo IdCargoNavigation { get; set; }
        public Voluntario IdVoluntarioNavigation { get; set; }
    }
}
