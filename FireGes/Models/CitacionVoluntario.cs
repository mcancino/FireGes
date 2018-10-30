using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class CitacionVoluntario
    {
        public int IdCitacionVoluntario { get; set; }
        public int IdVoluntario { get; set; }
        public int IdCitacion { get; set; }

        public Citacion IdCitacionNavigation { get; set; }
        public Voluntario IdVoluntarioNavigation { get; set; }
    }
}
