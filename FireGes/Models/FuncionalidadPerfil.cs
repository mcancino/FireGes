using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class FuncionalidadPerfil
    {
        public int IdFuncionalidadPerfil { get; set; }
        public int IdFuncionalidad { get; set; }
        public int IdPerfil { get; set; }

        public Funcionalidad IdFuncionalidadNavigation { get; set; }
        public Perfil IdPerfilNavigation { get; set; }
    }
}
