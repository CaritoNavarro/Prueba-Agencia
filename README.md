# Tienda

Consideraciones para el desarrollo:

* Es una tienda de perfumes en donde los productos están en la tabla productos y el carro de compras se consideran pedidos.
* Cada pedido puede tener uno o más productos, por lo cual se le da un número a cada pedido en donde se coloca en id del producto, la cantidad deseada   del producto y el valor total con respecto a ese producto (cantidad por valor unitario de la tabla producto).
* El stock nunca se ve afectado, porque se considera que solo se debe afectar en el momento de finalizar la compra es decir hacer el pago de pedido
* En cada uno de los métodos en donde se crea un pedido, se adiciona un producto o se actualiza la cantidad de un producto se verifica que se tenga esa cantidad en el stock del producto.

El desarrollo se realizó en dos capas la de acceso a la base de datos (DatosTienda) en donde se utilizó Entity Framework, y la capa de negocio (tiendaApi) en donde están expuesto los servicios 


### Pre-requisitos 📋

se debe tener encuenta los aplicativos en los cuales se desarrollo y el motor de base de datos



### Instalación 🔧

Tener en cuenta para la instalación el crear la base de datos, los archivos para la creación están en el repositorio y no olvidar cambiar  en el web.config  la conexión a la base de datos,  cambiar el servidor, el usuario y  la contraseña 


```
<add name="PruebaAgenciaEntities" connectionString="metadata=res://*/Tienda.csdl|res://*/Tienda.ssdl|res://*/Tienda.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=CLON\SQLEXPRESS;initial catalog=PruebaAgencia;persist security info=True;user id=PruebaAgencia;password=12345;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

```



_Finaliza con un ejemplo de cómo obtener datos del sistema o como usarlos para una pequeña demo_

## Ejecutando las pruebas ⚙️

Para las pruebas se utilizó postman, en donde se creó una colección y se privaron todos los servicios desplegados en esta aplicación.
Se bebe tener en cuenta que en el momento de realizar las pruebas cambiar el puerto por donde queda expuesto los servicios 

```
https://localhost:[Puerto]/BorrarProductoCarro?idPedido=1
```



## Despliegue 📦

_Agrega notas adicionales sobre como hacer deploy_

## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto_

* [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) - El framework web usado
* [Entity Framework 6.2.0](https://www.nuget.org/packages/EntityFramework/6.2.0) Entity Framework 6.2.0
* [Microsoft Visual Studio Professional 2019](https://visualstudio.microsoft.com/es/vs/) - ide de desarrollo
* [SQL Server 2019](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) - Base de datos 
* [Postman](https://www.postman.com/) - Pruebas 


## Versionado 📌

Usamos [github](https://github.com/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/tu/proyecto/tags).

## Autores ✒️


* **Alix Carolina Navarro Barreto** - *Trabajo Inicial* - 




---
