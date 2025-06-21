using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("ticketpedido")]
    public class TicketPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("nroped")]
        public int numero { get; set; }

        [Required]
        [Column("fecped")]
        [Display(Name = "Fecha Pedido")]
        public DateTime fecha { get; set; }

        [Required]
        public int codemp { get; set; }

        [ForeignKey("codemp")]
        [Display(Name = "Empleado")]
        public virtual Empleado empleado { get; set; }

        [Required]
        public int codcli { get; set; }

        [ForeignKey("codcli")]
        [Display(Name = "Cliente")]
        public virtual Cliente cliente { get; set; }

        [Required]
        [Column("estped")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
