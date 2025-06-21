using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("detalleticketpedido")]
    public class DetalleTicketPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("nrodet")]
        public int numero { get; set; }

        [Required]
        [Column("canent")]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Required]
        [Column("preent")]
        [Display(Name = "Precio de Entrada")]
        public decimal precio { get; set; }

        [Required]
        public int nroped { get; set; }

        [ForeignKey("nroped")]
        [Display(Name = "Pedido")]
        public virtual TicketPedido ticketpedido { get; set; }

        [Required]
        public int codpro { get; set; }

        [ForeignKey("codpro")]
        [Display(Name = "Producto")]
        public virtual Producto producto { get; set; }
    }
}