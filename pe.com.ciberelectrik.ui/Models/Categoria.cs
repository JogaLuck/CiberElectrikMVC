using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.ui.Models
{
    //definimos el nombre de la tabla
    [Table("categoria")]
    public class Categoria
    {
        //definimos la clave primaria
        [Key]
        //definimos el identity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //definimos la forma de como se mostrara en los formularios
        [Display(Name = "Codigo")]
        //definimos el campo de la tabla
        [Column("codcat")]
        public int codigo { get; set; }
        //hacemos que el campo sea requerido
        [Required]
        //definimos el tamaño del campo
        [StringLength(30)]
        //definimos la forma de como se mostrara en los formularios
        [Display(Name = "Nombre")]
        //definimos el campo de la tabla
        [Column("nomcat")]
        public string nombre { get; set; }
        //hacemos que el campo sea requerido
        [Required]
        //definimos la forma de como se mostrara en los formularios
        [Display(Name = "Estado")]
        //definimos el campo de la tabla
        [Column("estcat")]
        public bool estado { get; set; }
    }
}
