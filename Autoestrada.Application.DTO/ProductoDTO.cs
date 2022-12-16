using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Autoestrada.Application.DTO
{
    public partial class ProductoDTO
    {
        public int Proveedor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
