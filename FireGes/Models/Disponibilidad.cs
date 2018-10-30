using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Disponibilidad
    {
        public int IdDisponibilidad { get; set; }
        public int? IdVoluntario { get; set; }
        public int? IdCompania { get; set; }

        public Compania IdCompaniaNavigation { get; set; }
        public Voluntario IdVoluntarioNavigation { get; set; }
    }
}
