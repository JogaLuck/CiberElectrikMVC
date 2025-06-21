using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.ui.Models
{
    [Table("tipodocumento")]
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codtipd")]
        public int codigo { get; set; }

        [Required, StringLength(40)]
        [Column("nomtipd")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("esttipd")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
