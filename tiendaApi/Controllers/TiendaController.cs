
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using tiendaApi.Models;
using DatosTienda;
using Microsoft.Ajax;

namespace tiendaApi.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    public class TiendaController : ApiController
    {
        List<Models.Producto> listaProductos = new List<Models.Producto>();
        List<CarroCompras> CarroCompras = new List<CarroCompras>();

        public TiendaController()

        {

        }
       
        /// <summary>
        /// Lista todos los productos que se encuentran en la tienda 
        /// </summary>
        /// <returns> la lista completa </returns>
        //https://localhost:44300/ListaProductos
        [HttpGet]
        [Route("ListaProductos")]
        public List<Models.Producto> ListaProductos()
        {
            using (PruebaAgenciaEntities contexto = new PruebaAgenciaEntities())
            {
                var pro = contexto.Productos;
                foreach (var valor in pro)
                {
                    Models.Producto producto = new Models.Producto();
                    producto.Stock = valor.Stock;
                    producto.IdProducto = valor.IdProducto;
                    producto.Descripcion = valor.Descripcion; 
                    producto.Nombre = valor.Nombre;
                    producto.Valor = valor.Valor;
                    listaProductos.Add(producto);
                }
            }
          
            return this.listaProductos;
        }


      
        /// <summary>
        /// Lista un producto, buscando por el id del producto 
        /// </summary>
        /// <returns> producto  </returns>
        //https://localhost:44300/BuscarProducto?IdProducto=1
        [Route("BuscarProducto")]
        [HttpGet]
        public Models.Producto BuscarProducto(int IdProducto)

        {

            Models.Producto producto = new Models.Producto();
            using (PruebaAgenciaEntities contexto = new PruebaAgenciaEntities())
            {
                var pro = contexto.Productos.Where(x=>x.IdProducto == IdProducto);
                foreach (var valor in pro)
                {
                   
                    producto.Stock = valor.Stock;
                    producto.IdProducto = valor.IdProducto;
                    producto.Descripcion = valor.Descripcion;
                    producto.Nombre = valor.Nombre;
                    producto.Valor = valor.Valor;
                    listaProductos.Add(producto);
                }
            }

            
            return producto;

        }

        /// <summary>
        ///crea un carro, con el producto y la cantidad especificada 
        /// </summary>
        /// <returns> mensaje de exito o de error  </returns>
        //https://localhost:44300/CrearCarro
        [Route("CrearCarro")]
        [HttpPost]
        public IHttpActionResult CrearCarro([FromBody] ProductoCarro CarroNuevo)
        {
            Models.Producto p = this.listaProductos.Find(z => z.IdProducto == CarroNuevo.IdProducto);

            Models.Producto producto = new Models.Producto();
            string Mensaje = string.Empty;
            long? maximo;
            Pedido PedidoCreado = new Pedido();
            using (PruebaAgenciaEntities contexto = new PruebaAgenciaEntities())
            {
                var pro = contexto.Productos.Where(x => x.IdProducto == CarroNuevo.IdProducto);
                foreach (var valor in pro)
                {
                    producto.Stock = valor.Stock;
                    producto.IdProducto = valor.IdProducto;
                    producto.Descripcion = valor.Descripcion;
                    producto.Nombre = valor.Nombre;
                    producto.Valor = valor.Valor;
                }
                int Coun = contexto.Pedido.Count();
                
                if (Coun == 0)
                {
                    maximo = 1;
                }
                else
                {
                    maximo = contexto.Pedido.Max(x => x.IdPedido);
                    maximo ++;
                }
                if (producto.Stock >= CarroNuevo.Cantidad)
                {

                    Pedido carrito = new Pedido();
                    carrito.IdPedido = maximo.Value;
                    carrito.IdProducto = producto.IdProducto;
                    carrito.Cantidad = CarroNuevo.Cantidad;
                    carrito.ValorTotal = producto.Valor * CarroNuevo.Cantidad;

                    PedidoCreado = contexto.Pedido.Add(carrito);
                    contexto.SaveChanges();
                    Mensaje = "creado con exito el pedido " ;


                }
                else
                {
                    Mensaje = "no existe Stock del producto " + producto.Nombre;
                }

            }


            return  Json(new { msg = Mensaje, PedidoCreado.IdPedido });



        }


      
        /// <summary>
        /// añade un producto  a un carro teniendo en cuenta el numero de pedido, el producto y la cantidad, se suma la cantidad a la se tenia  previamente en el pedido  
        /// </summary>
        /// <returns> mensaje de exito o error </returns>
        //https://localhost:44300/AnnadirProducto?idPedido=6
        [Route("AnnadirProducto")]
        [HttpPost]
        public IHttpActionResult AnnadirProducto([FromBody] ProductoCarro CarroNuevo, int IdPedido)
        {
            Models.Producto p = this.listaProductos.Find(z => z.IdProducto == CarroNuevo.IdProducto);

            Models.Producto producto = new Models.Producto();
            string Mensaje = string.Empty;
            
            Pedido PedidoCreado = new Pedido();
            using (PruebaAgenciaEntities contexto = new PruebaAgenciaEntities())
            {
                var pro = contexto.Productos.Where(x => x.IdProducto == CarroNuevo.IdProducto);
                foreach (var valor in pro)
                {
                    producto.Stock = valor.Stock;
                    producto.IdProducto = valor.IdProducto;
                    producto.Descripcion = valor.Descripcion;
                    producto.Nombre = valor.Nombre;
                    producto.Valor = valor.Valor;
                }
               
               
                    PedidoCreado = contexto.Pedido.Where(x => x.IdPedido == IdPedido && x.IdProducto == producto.IdProducto).FirstOrDefault();

                    if (PedidoCreado != null)
                    {
                        if (producto.Stock >= CarroNuevo.Cantidad+ PedidoCreado.Cantidad)
                        {
                            PedidoCreado.Cantidad = CarroNuevo.Cantidad + PedidoCreado.Cantidad;
                            PedidoCreado.ValorTotal = producto.Valor * PedidoCreado.Cantidad;
                    }
                        else
                        {
                            Mensaje = "no existe Stock del producto " + producto.Nombre;
                        }
                    }
                    else
                    {
                        if (producto.Stock >= CarroNuevo.Cantidad)
                        {
                            Pedido carrito = new Pedido();
                            carrito.IdPedido = IdPedido;
                            carrito.IdProducto = producto.IdProducto;
                            carrito.Cantidad = CarroNuevo.Cantidad;
                            carrito.ValorTotal = producto.Valor * CarroNuevo.Cantidad;
                            PedidoCreado = contexto.Pedido.Add(carrito);
                        }
                        else
                        {
                            Mensaje = "no existe Stock del producto " + producto.Nombre;
                        }
                    }
                    contexto.SaveChanges();
                    Mensaje = "Actualizado con exito el pedido ";
            }


            return Json(new { msg = Mensaje, PedidoCreado.IdPedido });



        }



       
        /// <summary>
        /// actualzia los productos de un carro teniendo en cuenta el pedido, el producto y la cantidad, remplaza la cantidad de producto 
        /// </summary>
        /// <returns> la lista completa </returns>
        //https://localhost:44300/ActualizarCarro?idPedido=1
        [Route("ActualizarCarro")]
        [HttpPut]
        public IHttpActionResult ActualizarCarro(int IdPedido, [FromBody] ProductoCarro ProductoCarro)
        {

            Models.Producto p = this.listaProductos.Find(z => z.IdProducto == ProductoCarro.IdProducto);
            Models.Producto producto = new Models.Producto();
            string Mensaje = string.Empty;

            Pedido PedidoCreado = new Pedido();
            using (PruebaAgenciaEntities contexto = new PruebaAgenciaEntities())
            {
                var pro = contexto.Productos.Where(x => x.IdProducto == ProductoCarro.IdProducto);
                foreach (var valor in pro)
                {
                    producto.Stock = valor.Stock;
                    producto.IdProducto = valor.IdProducto;
                    producto.Descripcion = valor.Descripcion;
                    producto.Nombre = valor.Nombre;
                    producto.Valor = valor.Valor;
                }


                PedidoCreado = contexto.Pedido.Where(x => x.IdPedido == IdPedido && x.IdProducto == producto.IdProducto).FirstOrDefault();

                if (PedidoCreado != null)
                {
                    if (producto.Stock >= ProductoCarro.Cantidad )
                    {
                        PedidoCreado.Cantidad = ProductoCarro.Cantidad ;
                        PedidoCreado.ValorTotal = producto.Valor * PedidoCreado.Cantidad;
                    }
                    else
                    {
                        Mensaje = "no existe Stock del producto " + producto.Nombre;
                    }
                }
                else
                {
                    
                      Mensaje = "No se  encontro el producto  " + producto.Nombre + " en el pedido " +IdPedido;

                }
                contexto.SaveChanges();
                Mensaje = "Actualizado con exito el pedido ";
            }


            return Json(new { msg = Mensaje, PedidoCreado.IdPedido });
        }

       
        /// <summary>
        /// borra un producto de un pedido 
        /// </summary>
        /// <returns> la lista completa </returns>
        //https://localhost:44300/BorrarProductoCarro?idPedido=1
        [Route("BorrarProductoCarro")]
        [HttpDelete]
        public IHttpActionResult BorrarProductoCarro(int IdPedido, [FromBody] ProductoCarro ProductoCarro)
        {
            string Mensaje = string.Empty;
            Pedido PedidoCreado = new Pedido();
            using (PruebaAgenciaEntities contexto = new PruebaAgenciaEntities())
            {
                PedidoCreado = contexto.Pedido.Where(x => x.IdPedido == IdPedido && x.IdProducto == ProductoCarro.IdProducto).FirstOrDefault();

                if (PedidoCreado != null)
                {
                    contexto.Pedido.Remove(PedidoCreado);
                    Mensaje = "Producto eliminado en el pedido " + IdPedido;
                    contexto.SaveChanges();
                }
                else
                {
                    Mensaje = "No se  encontro el producto en el pedido " + IdPedido;

                }
                
            }
            return Json(new { msg = Mensaje, PedidoCreado.IdPedido });
        }
    }
}