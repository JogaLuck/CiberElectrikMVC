using pe.com.ciberelectrik.ui.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.ui.Models.db
{
    //generamos una herencia del DbContext
    public class ApplicationDBContext : DbContext
    {
        //llamamos a la cadena de conexion y la instanciamos en el metodo constructor
        public ApplicationDBContext() : base("DefaultConnection") { }
        //por cada tabla generada debemos realizar un DbSet
        public DbSet<Marca> marca { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Producto> producto { get; set; }
        public DbSet<Distrito> distrito { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<TipoDocumento> tipodocumento { get; set; }
        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<TicketPedido> ticketpedido { get; set; }
        public DbSet<DetalleTicketPedido> detalleticketpedido { get; set; }

    }
}