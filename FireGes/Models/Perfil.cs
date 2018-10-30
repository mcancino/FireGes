using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            FuncionalidadPerfil = new HashSet<FuncionalidadPerfil>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPerfil { get; set; }
        public string DescripcionPerfil { get; set; }

        public ICollection<FuncionalidadPerfil> FuncionalidadPerfil { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
