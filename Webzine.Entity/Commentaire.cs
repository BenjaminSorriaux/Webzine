using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webzine.Entity
{
    /// <summary>
    /// Cette entité correspond à un commentaire sur un titre.
    /// On va donc retrouver les informations importantes pour chaque commentaire.
    /// Cette entité est une entité locale.
    /// </summary>
    public class Commentaire
    {
        public Commentaire()
        {
        }

        [Column("id")]
        [Key]
        public int IdCommentaire { get; set; }

        [Column("auteur")]
        [Display(Name = "Nom")]
        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Auteur { get; set; }

        [Column("contenu")]
        [Display(Name = "Commentaire")]
        [MinLength(10)]
        [MaxLength(1000)]
        [Required]
        public string Contenu { get; set; }

        [Column("date_creation")]
        [Display(Name = "Date de création")]
        [Required]
        public DateTime DateCreation { get; set; }

        [Column("id_titre")]
        [ForeignKey(nameof(Musique))]
        public int IdTitre { get; set; }

        public Titre Musique { get; set; }
    }
}
