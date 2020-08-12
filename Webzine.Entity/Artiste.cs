using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webzine.Entity
{
    /// <summary>
    /// Cette entité correspond à un artiste.
    /// On retrouve les informations nécessaires pour ceux-ci.
    /// Il s'agit de l'entité locale d'un artiste.
    /// </summary>
    public class Artiste
    {
        public Artiste()
        {

        }

        public Artiste(string nom, string biographie)
        {
            Nom = nom;
            Biographie = biographie;
        }

        [Column("id")]
        [Key]
        public int IdArtiste { get; set; }

        [Column("nom")]
        [Display(Name = "Nom de l'artiste")]
        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Nom { get; set; }

        [Column("biographie")]
        public string Biographie { get; set; }

        public List<Titre> Titres { get; set; }
    }
}
