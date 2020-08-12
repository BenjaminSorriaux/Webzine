using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webzine.Entity
{
    /// <summary>
    /// Cette entité correspond à un titre, c'est à dire une musique.
    /// On retrouve ici toutes les informations correspondantes à celle-ci.
    /// Il s'agit de l'entité locale correspondant au titre.
    /// </summary>
    public class Titre
    {
        [Column("id")]
        [Key]
        public int IdTitre { get; set; }

        [Column("libelle")]
        [Display(Name = "Titre")]
        [MinLength(1)]
        [MaxLength(200)]
        [Required]
        public string Libelle { get; set; }

        [Column("chronique")]
        [MinLength(10)]
        [MaxLength(4000)]
        [Required]
        public string Chronique { get; set; }

        [Column("id_artiste")]
        [ForeignKey(nameof(Artiste))]
        public int IdArtiste { get; set; }

        public Artiste Artiste { get; set; }

        [Column("duree")]
        [Display(Name = "Durée en secondes")]
        [Required]
        public int Duree { get; set; }

        [Column("url_jaquette")]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250)]
        [Required]
        public string UrlJaquette { get; set; }

        [Column("url_ecoute")]
        [Display(Name = "URL d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        public string UrlEcoute { get; set; }

        [NotMapped]
        public string Album { get; set; }

        [Column("date_creation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de création")]
        [Required]
        public DateTime DateCreation { get; set; }

        [Column("date_sortie")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de sortie")]
        [Required]
        public DateTime DateSortie { get; set; }

        [Column("nb_lectures")]
        [Display(Name = "Nombre de lectures")]
        [Required]
        public int NbLectures { get; set; }

        [Column("nb_likes")]
        [Display(Name = "Nombre de likes")]
        [Required]
        public int NbLikes { get; set; }

        [NotMapped]
        public List<LienTitreStyle> TitresStyles { get; set; }

        public List<Commentaire> Commentaires { get; set; }

        public Titre()
        {
            Commentaires = new List<Commentaire>();
            TitresStyles = new List<LienTitreStyle>();
        }

        public Titre(string libelle, string contenuChronique, Artiste artiste, string imageAlbum, string lien, DateTime dateSortie, List<Style> styles)
        {
            Libelle = libelle;
            Chronique = contenuChronique;
            UrlJaquette = imageAlbum;
            UrlEcoute = lien;
            DateCreation = DateTime.Now;
            DateSortie = dateSortie;
            NbLectures = 0;
            NbLikes = 0;
            styles.ForEach(s=> { this.TitresStyles.Add(new LienTitreStyle {IdStyle=s.IdStyle, Style=s, Titre=this, IdTitre=this.IdTitre }); });
            Commentaires = new List<Commentaire>();
        }
    }
}
