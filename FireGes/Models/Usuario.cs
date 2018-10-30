using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdEstadoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CorreoElectronico { get; set; }
        public string Password { get; set; }

        public EstadoUsuario IdEstadoUsuarioNavigation { get; set; }
        public Perfil IdPerfilNavigation { get; set; }
    }
}
