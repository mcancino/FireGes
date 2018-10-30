using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class EstadoUsuario
    {
        public EstadoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdEstadoUsuario { get; set; }
        public string DescripcionEstadoUsuario { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
