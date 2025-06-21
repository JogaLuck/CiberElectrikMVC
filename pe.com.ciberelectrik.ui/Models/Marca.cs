using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("marca")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codmar")]
        public int codigo { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre")]
        [Column("nommar")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Estado")]
        [Column("estmar")]
        public bool estado { get; set; }
    }
}