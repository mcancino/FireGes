using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class DireccionCuerpo
    {
        public int IdDireccionCuerpo { get; set; }
        public int IdCuerpo { get; set; }
        public int? IdComuna { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Departamento { get; set; }

        public Comuna IdComunaNavigation { get; set; }
        public Cuerpo IdCuerpoNavigation { get; set; }
    }
}
