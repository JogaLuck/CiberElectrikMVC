using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codemp")]
        public int codigo { get; set; }

        [Required, StringLength(60)]
        [Column("nomemp")]
        [Display(Name = "Nombres")]
        public string nombre { get; set; }

        [Required, StringLength(60)]
        [Column("apepemp")]
        [Display(Name = "Apellido Paterno")]
        public string apepaterno { get; set; }

        [Required, StringLength(60)]
        [Column("apememp")]
        [Display(Name = "Apellido Materno")]
        public string apematerno { get; set; }

        [Required, StringLength(20)]
        [Column("docemp")]
        [Display(Name = "Documento")]
        public string documento { get; set; }

        [Required, StringLength(100)]
        [Column("diremp")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required, StringLength(7)]
        [Column("telemp")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required, StringLength(9)]
        [Column("celemp")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required, StringLength(60)]
        [Column("coremp")]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required, StringLength(20)]
        [Column("usuemp")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required, StringLength(20)]
        [Column("claemp")]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Required]
        [Column("estemp")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Required]
        public int coddis { get; set; }

        [ForeignKey("coddis")]
        [Display(Name = "Distrito")]
        public virtual Distrito distrito { get; set; }

        [Required]
        public int codrol { get; set; }

        [ForeignKey("codrol")]
        [Display(Name = "Rol")]
        public virtual Rol rol { get; set; }

        [Required]
        public int codtipd { get; set; }

        [ForeignKey("codtipd")]
        [Display(Name = "Tipo Documento")]
        public virtual TipoDocumento tipodocumento { get; set; }
    }
}