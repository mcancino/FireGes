using System;
using System.Collections.Generic;

namespace FireGes.Models
{
    public partial class TipoMarca
    {
        public TipoMarca()
        {
            MarcaVoluntario = new HashSet<MarcaVoluntario>();
        }

        public int IdTipoMarca { get; set; }
        public string DescripcionTipoMarca { get; set; }

        public ICollection<MarcaVoluntario> MarcaVoluntario { get; set; }
    }
}
