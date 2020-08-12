using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;
using Webzine.Repository.Contracts;
using Webzine.Repository;
using Webzine.Entity;
using System;

namespace Webzine.WebApplication.Controllers
{
    [Area("Administration")]
    public class ArtisteController : Controller
    {
        ArtisteAdminViewModel ArtisteAdmin { get; set; }


        public IActionResult Index(string MessageErreur)
        {
            //call de l'interface pour obtenir la liste des artistes
            var data = Startup.iartisteRepository.FindAll().ToList();

            ArtisteAdminViewModel artisteAdminViewModel = new ArtisteAdminViewModel();
            artisteAdminViewModel.Artistes = data;
            artisteAdminViewModel.MessageErreur = MessageErreur;

            return View(artisteAdminViewModel);
        }


        /// <summary>
        /// redirige l'utilisateur sur la page de modification/création d'artiste
        /// si l'utilisateur choisit création alors l'id sera égal à  et l'artiste passé en paramètre nulle
        /// si l'utilisateur sélectionne un artiste existant , l'artiste est passé en paramétre
        /// (n'ajoute pas l'artiste)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddArtiste(int id)
        {
            ArtisteAdminViewModel artisteAdminViewModel = new ArtisteAdminViewModel();
            if (id != 0)
            {
                artisteAdminViewModel.Artiste = Startup.iartisteRepository.Find(id);
            }
            return View(artisteAdminViewModel);
        }

        /// <summary>
        /// Permet de determiner si l'utilisateur effectue une modification ou une création d'artiste
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitAction(Artiste artiste)
        {
            if (artiste.IdArtiste == 0)
            {
                AddArtiste(artiste);
            }
            else
            {
                UpdateArtiste(artiste);
            }
            //retour à la vue préçedente
            return RedirectToAction("Index");
        }

        /// <summary>
        /// La méthode renvoie la vue de confirmation de suppression d'un artiste
        /// </summary>
        /// <param name="id">Identifiant de l'artiste à supprimer</param>
        /// <returns>La vue de confirmation de suppression de l'artiste avec en paramètre un view model contenant l'artiste à supprimer</returns>
        public IActionResult DeleteArtiste(int id)
        {
            ArtisteAdminViewModel artisteAdminViewModel = new ArtisteAdminViewModel();

            artisteAdminViewModel.Artiste = Startup.iartisteRepository.Find(id);
            return View(artisteAdminViewModel);
        }

        /// <summary>
        /// permet l'ajout d'artiste, fonction overload avec un artiste en paramètre
        /// </summary>
        /// <param name="artiste">artiste a ajouter</param>
        private void AddArtiste(Artiste artiste)
        {
            //l'id de l'artiste est determiné dans le Repository
            try
            {
                Startup.iartisteRepository.Add(artiste);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// call l'interface qui modifira l'artiste
        /// </summary>
        /// <param name="artiste">artiste a modifier avec ses nouveau paramètre</param>
        private void UpdateArtiste(Artiste artiste)
        {
            try
            {
                Startup.iartisteRepository.Update(artiste);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult DeleteArtisteConfirmation(Artiste artiste)
        {
            string messageErreur = null;
            try
            {
                if (!artiste.Titres.Any())
                {
                    Startup.iartisteRepository.Delete(artiste);
                }
                else
                {
                    messageErreur = "Suppression échoué : des titres sont liés à l'artiste";
                }
            }
            catch (Exception)
            {

                throw;
            }
            //appeler index avec erreur en parametre
            //return RedirectToAction("Index",messageErreur);
            return RedirectToAction("Index", new { MessageErreur = messageErreur });
        }

    }
}