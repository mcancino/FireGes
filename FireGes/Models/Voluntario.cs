using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Voluntario
    {
        public Voluntario()
        {
            CitacionVoluntario = new HashSet<CitacionVoluntario>();
            DireccionVoluntario = new HashSet<DireccionVoluntario>();
            Disponibilidad = new HashSet<Disponibilidad>();
            MarcaVoluntario = new HashSet<MarcaVoluntario>();
            VoluntarioCargo = new HashSet<VoluntarioCargo>();
        }

        public int IdVoluntario { get; set; }
        public int IdCompania { get; set; }
        public int IdEstadoVoluntario { get; set; }
        public int Rut { get; set; }
        public string DigitoVerificador { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIncorporacion { get; set; }

        public Compania IdCompaniaNavigation { get; set; }
        public EstadoVoluntario IdEstadoVoluntarioNavigation { get; set; }
        public ICollection<CitacionVoluntario> CitacionVoluntario { get; set; }
        public ICollection<DireccionVoluntario> DireccionVoluntario { get; set; }
        public ICollection<Disponibilidad> Disponibilidad { get; set; }
        public ICollection<MarcaVoluntario> MarcaVoluntario { get; set; }
        public ICollection<VoluntarioCargo> VoluntarioCargo { get; set; }
    }
}
