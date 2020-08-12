using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webzine.Entity
{
    /// <summary>
    /// Entité correspondant à un style, un style est un type de musique, par exemple pop ou rock.
    /// On retrouve ici les informations nécessaires sur le style de musique.
    /// Il s'agit d'une entité locale, il n'y a donc pas besoin d'un identifiant.
    /// </summary>
    public class Style
    {
        [Column("id")]
        [Key]
        public int IdStyle { get; set; }

        [Column("libelle")]
        [Display(Name = "Libellé")]
        [MaxLength(50)]
        [MinLength(2)]
        [Required]
        public string Libelle { get; set; }

        [NotMapped]
        public List<LienTitreStyle> TitresStyles { get; set; }

        [NotMapped]
        public bool CheckboxAnswer { get; set; }
        public Style()
        {
        }

        public Style(string libelle)
        {
            Libelle = libelle;
            TitresStyles = new List<LienTitreStyle>();
        }

    }
}
