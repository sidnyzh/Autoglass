using Autoestrada.Domain.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Autoestrada.Domain.Entity.Entities
{
    public partial class Producto
    {
        public int Id { get; set; }
        public int Proveedor { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        [JsonIgnore]
        public virtual Proveedor ProveedorNavigation { get; set; }
    }
}
