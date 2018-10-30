using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class Funcionalidad
    {
        public Funcionalidad()
        {
            FuncionalidadPerfil = new HashSet<FuncionalidadPerfil>();
        }

        public int IdFuncionalidad { get; set; }
        public string DescripcionFuncionalidad { get; set; }
        public string Controller { get; set; }
        public string Metodo { get; set; }

        public ICollection<FuncionalidadPerfil> FuncionalidadPerfil { get; set; }
    }
}
