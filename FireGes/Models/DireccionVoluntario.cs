using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class DireccionVoluntario
    {
        public int IdDireccionVoluntario { get; set; }
        public int IdVoluntario { get; set; }
        public int IdComuna { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Departamento { get; set; }

        public Comuna IdComunaNavigation { get; set; }
        public Voluntario IdVoluntarioNavigation { get; set; }
    }
}
