using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codpro")]
        public int codigo { get; set; }
        [Required]
        [StringLength(80)]
        [Display(Name = "Nombre")]
        [Column("nompro")]
        public string nombre { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Descripcion")]
        [Column("despro")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Precio")]
        [Column("prepro")]
        public decimal precio { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        [Column("canpro")]
        public int cantidad { get; set; }
        [Required]
        [Display(Name = "Fec. Ingreso")]
        [Column("fecing")]
        public DateTime fechaingreso { get; set; }
        [Required]
        [Display(Name = "Estado")]
        [Column("estpro")]
        public bool estado { get; set; }
        //para la clave foranea
        [Required]
        public int codmar { get; set; }
        //asignamos la clave foranea
        [ForeignKey("codmar")]
        [Display(Name = "Marca")]
        public virtual Marca marca { get; set; }
        //para la clave foranea
        [Required]
        public int codcat { get; set; }
        //asignamos la clave foranea
        [ForeignKey("codcat")]
        [Display(Name = "Categoria")]
        public virtual Categoria categoria { get; set; }
    }
}