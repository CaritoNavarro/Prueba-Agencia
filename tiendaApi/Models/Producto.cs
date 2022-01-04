using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tiendaApi.Models
{
    public class Producto
    {
        
        public long IdProducto { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public long Stock { get; set; }

        public decimal Valor { get; set; }
    }
}