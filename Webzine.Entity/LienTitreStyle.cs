using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webzine.Entity
{
    public class LienTitreStyle
    {
        [Column("id_titre")]
        [Key]
        public int IdTitre { get; set; }
        public Titre Titre { get; set; }

        [Column("id_style")]
        [Key]
        public int IdStyle { get; set; }
        public Style Style { get; set; }
    }
}
