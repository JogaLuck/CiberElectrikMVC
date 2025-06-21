using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("distrito")]
    public class Distrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("coddis")]
        public int codigo { get; set; }

        [Required, StringLength(40)]
        [Column("nomdis")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estdis")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}