using Autoestrada.Domain.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Autoestrada.Domain.Entity.Entities
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }

        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
