using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codrol")]
        public int codigo { get; set; }

        [Required, StringLength(40)]
        [Column("nomrol")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estrol")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}