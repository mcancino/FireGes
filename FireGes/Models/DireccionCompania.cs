using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class DireccionCompania
    {
        public int IdDireccionCompania { get; set; }
        public int IdCompania { get; set; }
        public int? IdComuna { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Departamento { get; set; }

        public Compania IdCompaniaNavigation { get; set; }
        public Comuna IdComunaNavigation { get; set; }
    }
}
