using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.ui.Models
{
    //Definimos el nombre de la tabla
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codcli")]
        public int codigo { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Nombre")]
        [Column("nomcli")]
        public string nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Apellido Paterno")]
        [Column("apepcli")]
        public string apellidoPaterno { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Apellido Materno")]
        [Column("apemcli")]
        public string apellidoMaterno { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Documento Cliente")]
        [Column("doccli")]
        public string documentoCliente { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Dirección Cliente")]
        [Column("dircli")]
        public string direccionCliente { get; set; }

        [Required]
        [StringLength(7)]
        [Display(Name = "Telefono Cliente")]
        [Column("telcli")]
        public string telefonoCliente { get; set; }

        [Required]
        [StringLength(9)]
        [Display(Name = "Celular Cliente")]
        [Column("celcli")]
        public string celularCliente { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Correo Cliente")]
        [Column("corcli")]
        public string correoCliente { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [Column("estcli")]
        public bool estado { get; set; }

        [Required]
        public int coddis { get; set; }
        //asignamos la clave foranea
        [ForeignKey("coddis")]
        [Display(Name = "Distrito")]
        public virtual Distrito distrito { get; set; }

        [Required]
        public int codtipd { get; set; }
        //asignamos la clave foranea
        [ForeignKey("codtipd")]
        [Display(Name = "Tipo Documento")]
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}