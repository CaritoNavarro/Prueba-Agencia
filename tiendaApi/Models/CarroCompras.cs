using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tiendaApi.Models
{
    public class CarroCompras
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal ValorTotal { get; set; }
    }
}