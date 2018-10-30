using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class MarcaVoluntario
    {
        public int IdMarcaVoluntario { get; set; }
        public int IdVoluntario { get; set; }
        public int IdTipoMarca { get; set; }
        public DateTime Fecha { get; set; }

        public TipoMarca IdTipoMarcaNavigation { get; set; }
        public Voluntario IdVoluntarioNavigation { get; set; }
    }
}
