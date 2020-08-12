using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webzine.Entity;

namespace Webzine.Entity
{
    public static class Factory
    {
        public static List<Titre> Titres { get; set; }
        public static List<Commentaire> Commentaires { get; set; }
        public static List<Style> Styles { get; set; }
        public static List<Artiste> Artistes { get; set; }
        public static List<LienTitreStyle> LienTitreStyles { get; set; }
        static Factory()
        {
            Commentaires = new List<Commentaire>();
            Artistes = new List<Artiste>();
            LienTitreStyles = new List<LienTitreStyle>();


            Commentaire commentaire1 = new Commentaire
            {
                Auteur = "Bob",
                Contenu = "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                DateCreation = DateTime.Now
            };

            Commentaire commentaire2 = new Commentaire
            {
                Auteur = "Martin",
                Contenu = "J'adore cette musique.",
                DateCreation = DateTime.Now
            };

            Titres = new List<Titre>();
            Styles = new List<Style>();
            #region powerwolf
            Titre titre1 = new Titre
            {
                Libelle = "Fire & Forgive",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/qenZrPLT7EE",

            };
            Titres.Add(titre1);

            Titre titre2 = new Titre
            {
                Libelle = "Demons Are a Girl's Best Friend",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre2);

            Titre titre3 = new Titre
            {
                Libelle = "Killers with the Cross",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",
            };
            Titres.Add(titre3);

            Titre titre4 = new Titre
            {
                Libelle = "Incense & Iron",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre4);

            Titre titre5 = new Titre
            {
                Libelle = "Where the Wild Wolves Have Gone",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre5);

            Titre titre6 = new Titre
            {
                Libelle = "Stossgebet",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre6);

            Titre titre7 = new Titre
            {
                Libelle = "Nightside of Siberia",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre7);

            Titre titre8 = new Titre
            {
                Libelle = "The Sacrament of Sin",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre8);

            Titre titre9 = new Titre
            {
                Libelle = "Venom of Venus",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",

            };
            Titres.Add(titre9);

            Titre titre10 = new Titre
            {
                Libelle = "Nighttime Rebel",
                Album = "The Sacrament of Sin",
                UrlJaquette = "https://www.heavylaw.com/content/images/2018/09/powerwolf.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",
                Commentaires = new List<Commentaire>(),
                TitresStyles = new List<LienTitreStyle>()
            };
            Titres.Add(titre10);

            Titre titre11 = new Titre
            {
                Libelle = "Fist by Fist (Sacralize or Strike)",
                Album = "Blessed & Possessed",
                UrlJaquette = "https://images-na.ssl-images-amazon.com/images/I/61S4NDAD-tL._SY355_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",
                Commentaires = new List<Commentaire>(),
                TitresStyles = new List<LienTitreStyle>()
            };
            Titres.Add(titre11);

            Titre titre12 = new Titre
            {
                Libelle = "Blessed & Possessed",
                Album = "Blessed & Possessed",
                UrlJaquette = "https://images-na.ssl-images-amazon.com/images/I/61S4NDAD-tL._SY355_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",
                Commentaires = new List<Commentaire>(),
                TitresStyles = new List<LienTitreStyle>()
            };
            Titres.Add(titre12);

            Titre titre13 = new Titre
            {
                Libelle = "Dead Until Dark",
                Album = "Blessed & Possessed",
                UrlJaquette = "https://images-na.ssl-images-amazon.com/images/I/61S4NDAD-tL._SY355_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/4UcOODrEPpA",
                Commentaires = new List<Commentaire>(),
                TitresStyles = new List<LienTitreStyle>()
            };
            Titres.Add(titre13);

            Titre titre14 = new Titre
            {
                Libelle = "Army of the Night",
                Album = "Blessed & Possessed",
                UrlJaquette = "https://images-na.ssl-images-amazon.com/images/I/61S4NDAD-tL._SY355_.jpg",
                Commentaires = new List<Commentaire>(),
                TitresStyles = new List<LienTitreStyle>()
            };
            Titres.Add(titre14);
            Artiste artiste1 = new Artiste
            {
                Nom = "Powerwolf",
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Titres = new List<Titre>()

            };
            Style style1 = new Style
            {
                Libelle = "Metal",
                TitresStyles = new List<LienTitreStyle>()
            };
            Styles.Add(style1);
            #endregion
            #region GestionPowerwolf 


            artiste1.Titres.AddRange(Titres);
            Artistes.Add(artiste1);

            foreach (var titre in Titres)
            {
                titre.Artiste = artiste1;
                titre.TitresStyles = new List<LienTitreStyle>();
                titre.Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est labor";
                LienTitreStyle lienTitreStyle = new LienTitreStyle { Titre = titre, Style = style1 };
                LienTitreStyles.Add(lienTitreStyle);
                style1.TitresStyles.Add(lienTitreStyle);
                titre.TitresStyles.Add(lienTitreStyle);
                titre.DateCreation = DateTime.Now;
                titre.DateSortie = DateTime.Now;

            }

            #endregion
            #region BlackSabbath    
            List<Titre> titresBlackSabbath = new List<Titre>();

            Titre titre1BlackSabbath = new Titre
            {
                Libelle = "Paranoid",
                Album = "Paranoid",
                UrlJaquette = "https://websvc.afi-sa.net/afi_opac_services/images/jaquettes/big/3394277.jpeg",
                UrlEcoute = "https://www.youtube.com/embed/uk_wUT1CvWM",

            };
            titresBlackSabbath.Add(titre1BlackSabbath);
            Titre titre2BlackSabbath = new Titre
            {
                Libelle = "War Pigs",
                Album = "Paranoid",
                UrlJaquette = "https://websvc.afi-sa.net/afi_opac_services/images/jaquettes/big/3394277.jpeg",
                UrlEcoute = "https://www.youtube.com/embed/uk_wUT1CvWM",

            };
            titresBlackSabbath.Add(titre2BlackSabbath);
            Titre titre3BlackSabbath = new Titre
            {
                Libelle = "Planet Caravan",
                Album = "Paranoid",
                UrlJaquette = "https://websvc.afi-sa.net/afi_opac_services/images/jaquettes/big/3394277.jpeg",
                UrlEcoute = "https://www.youtube.com/embed/SvrOzYtnLMA"

            };
            titresBlackSabbath.Add(titre3BlackSabbath);
            Artiste artisteBlackSabbath = new Artiste
            {
                Nom = "Black Sabbath",
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Titres = new List<Titre>()

            };

            #endregion
            #region GestionBlackSabbath
            Titres.AddRange(titresBlackSabbath);
            Artistes.Add(artisteBlackSabbath);

            foreach (var titre in titresBlackSabbath)
            {
                titre.Artiste = artisteBlackSabbath;
                titre.TitresStyles = new List<LienTitreStyle>();
                titre.Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est labor";
                LienTitreStyle lienTitreStyle = new LienTitreStyle { Titre = titre, Style = style1 };
                LienTitreStyles.Add(lienTitreStyle);
                style1.TitresStyles.Add(lienTitreStyle);
                titre.TitresStyles.Add(lienTitreStyle);
                titre.DateCreation = DateTime.Now;
                titre.DateSortie = DateTime.Now;

            }

            #endregion
            #region HeavyHorses
            Artiste artisteHeavyHorses = new Artiste
            {
                Nom = "Heavy Horses",
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Titres = new List<Titre>()

            };
            Style styleCountry = new Style
            {
                Libelle = "Country",
                TitresStyles = new List<LienTitreStyle>()
            };

            List<Titre> titresHeavieHorses = new List<Titre>();

            Titre titre1HeavieHorses = new Titre
            {
                Libelle = "Pale Rider",
                Album = "Murder Ballad And Other Love Song",
                UrlJaquette = "https://m.media-amazon.com/images/I/71T8euE7KuL._SS500_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/bdtx1nF-Ki0",

            };
            titresHeavieHorses.Add(titre1HeavieHorses);
            Titre titre2HeavieHorses = new Titre
            {
                Libelle = "Hell Awaits",
                Album = "Murder Ballad And Other Love Song",
                UrlJaquette = "https://m.media-amazon.com/images/I/71T8euE7KuL._SS500_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/uHX1iP3qB2E ",

            };
            titresHeavieHorses.Add(titre2HeavieHorses);
            Titre titre3HeavieHorses = new Titre
            {
                Libelle = "Copper & Gold",
                Album = "https://www.youtube.com/embed/27XbOBFRI58?list=RDbdtx1nF-Ki0",
                UrlJaquette = "https://m.media-amazon.com/images/I/71T8euE7KuL._SS500_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/bdtx1nF-Ki0",

            };
            titresHeavieHorses.Add(titre3HeavieHorses);
            Titre titre4HeavieHorses = new Titre
            {
                Libelle = "In Darkness He Came",
                Album = "Murder Ballad And Other Love Song",
                UrlJaquette = "https://m.media-amazon.com/images/I/71T8euE7KuL._SS500_.jpg",
                UrlEcoute = "https://www.youtube.com/embed/3nsrgrSuDnk",

            };
            titresHeavieHorses.Add(titre4HeavieHorses);

            #endregion
            #region GestionHeavyHorses
            Titres.AddRange(titresHeavieHorses);
            Artistes.Add(artisteHeavyHorses);
            Styles.Add(styleCountry);
            foreach (var titre in titresHeavieHorses)
            {
                titre.Artiste = artisteHeavyHorses;
                titre.TitresStyles = new List<LienTitreStyle>();
                titre.Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est labor";
                LienTitreStyle lienTitreStyle = new LienTitreStyle { Titre = titre, Style = styleCountry };
                LienTitreStyles.Add(lienTitreStyle);
                styleCountry.TitresStyles.Add(lienTitreStyle);
                titre.TitresStyles.Add(lienTitreStyle);
                titre.DateCreation = DateTime.Now;
                titre.DateSortie = DateTime.Now;

            }
            #endregion
            Titre titrex = new Titre
            {
                Libelle = "Simon's Theme",
                DateCreation = DateTime.Now,
                DateSortie = DateTime.Now,
                Album = "Super Castlevania IV",
                UrlJaquette = "https://vignette.wikia.nocookie.net/castlevania/images/5/5c/ABV2front.jpg/revision/latest?cb=20170304055351",
                UrlEcoute = "https://www.youtube.com/embed/wuqWGn8b1wo",
                NbLectures = 1,
                NbLikes = 1,
                Chronique = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Commentaires = new List<Commentaire>(),
                TitresStyles = new List<LienTitreStyle>()
            };




            Style style2 = new Style
            {
                Libelle = "Jeux Vidéos",
                TitresStyles = new List<LienTitreStyle>()
            };





            Artiste artiste2 = new Artiste
            {
                Nom = "Michiru Yamane",
                Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Titres = new List<Titre>()
            };


            LienTitreStyle lienTitreStyle32 = new LienTitreStyle() { Titre = titre3, Style = style2 };

            titrex.Artiste = artiste2;
            artiste2.Titres.Add(titrex);
            Titres.Add(titrex);
            titrex.TitresStyles.Add(lienTitreStyle32);
            style2.TitresStyles.Add(lienTitreStyle32);

            Styles.Add(style2);

            Titres.Add(titre3);

            Artistes.Add(artiste2);

            LienTitreStyles.Add(lienTitreStyle32);

            Random rnd = new Random();
            Titres.ForEach(t => { t.Duree = rnd.Next(90, 547); t.NbLectures = rnd.Next(30, 1000); t.NbLikes = rnd.Next(0, 1200); });
        }

        public static void SetId()
        {
            for (int i = 0; i < Titres.Count; i++)
            {
                Titres[i].IdTitre = i + 1;
            }
            for (int i = 0; i < Artistes.Count; i++)
            {
                Artistes[i].IdArtiste = i + 1;
            }
            for (int i = 0; i < Commentaires.Count; i++)
            {
                Commentaires[i].IdCommentaire = i + 1;
            }
            for (int i = 0; i < Styles.Count; i++)
            {
                Styles[i].IdStyle = i + 1;
            }

        }
    }
}
