using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class EstadoVoluntario
    {
        public EstadoVoluntario()
        {
            Voluntario = new HashSet<Voluntario>();
        }

        public int IdEstadoVoluntario { get; set; }
        public string DescripcionEstadoVoluntario { get; set; }

        public ICollection<Voluntario> Voluntario { get; set; }
    }
}
