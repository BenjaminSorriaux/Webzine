using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.WebApplication.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webzine.WebApplication.Administration.Controllers
{
    [Area("Administration")]
    public class TitreController : Controller
    {
        /// <summary>
        /// La méthode renvoie la page d'index de management des titres
        /// </summary>
        /// <returns>La vue index avec en paramètre un view model contenant une liste de titre</returns>
        public IActionResult Index()
        {
            TitresAdminViewModel titresAdminViewModel = new TitresAdminViewModel();
            titresAdminViewModel.Titres = Startup.ititreRepository.FindAll().ToList();
            return View(titresAdminViewModel);
        }

        /// <summary>
        /// La méthode renvoie la page de création ou d'édition d'un titre
        /// </summary>
        /// <param name="id">Identifiant du titre que l'on veut modifier</param>
        /// <returns>La vue de création d'un titre avec en paramètre un view model contenant les informations pour la création d'un style</returns>
        public IActionResult AddTitre(int id)
        {
            TitreAdminViewModel titreViewModel = new TitreAdminViewModel();
            titreViewModel.Artistes = Startup.iartisteRepository.FindAll().ToList();
            titreViewModel.Styles = Startup.istyleRepository.FindAll().ToList();
            titreViewModel.Titre = new Titre();
            titreViewModel.Styles.ForEach(s => s.CheckboxAnswer = false);
            if (id != 0)
            {
                titreViewModel.Titre = Startup.ititreRepository.Find(id);
                //coche les checkbox correspondantes au styles du titres
                titreViewModel.Styles.Where(s => titreViewModel.Titre.TitresStyles.Select(ts => ts.Style).Contains(s)).ToList().ForEach(s => s.CheckboxAnswer = true);

            }
            return View(titreViewModel);
        }

        /// <summary>
        /// La méthode effectue le traitement pour ajouter un titre, elle redirige vers
        /// </summary>
        /// <param name="titre">Objet Titre à ajouter</param>
        /// <returns>Une redirection vers l'index d'administration </returns>
        [HttpPost]
        public IActionResult ActionAdd(Titre titre, List<Style> styles)
        {
            var stylesToAdd = styles.Where(s => s.CheckboxAnswer).ToList();//retire tous les styles ou la checkbox n'est pas coché                
            stylesToAdd.ForEach(s => titre.TitresStyles.Add(new LienTitreStyle { Style = s, IdStyle = s.IdStyle, Titre = titre, IdTitre = titre.IdTitre }));
            titre.DateCreation = DateTime.Now;
            titre.Artiste = Startup.iartisteRepository.Find(titre.IdArtiste);
            if (titre.IdTitre == 0)
            {
                Startup.ititreRepository.Add(titre);
                return RedirectToAction("Index");
            }
            else
            {
                return ActionEdit(titre);
            }

        }

        /// <summary>
        /// La méthode effectue les traitement pour éditer un titre
        /// </summary>
        /// <param name="titre">Objet Titre à éditer</param>
        /// <returns>Une redirection vers la page index d'administration des titres</returns>
        [HttpPost]
        public IActionResult ActionEdit(Titre titre)
        {

            titre.Artiste = Startup.iartisteRepository.Find(titre.IdArtiste);
            Startup.ititreRepository.Update(titre);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// La méthode renvoie la vue de confirmation de suppression d'un titre
        /// </summary>
        /// <param name="id">Identifiant du titre à supprimer</param>
        /// <returns>La vue de suppression du titre avec en paramètre un view model contenant le titre à supprimer</returns>
        public IActionResult DeleteTitre(int id)
        {
            TitreAdminViewModel titreViewModel = new TitreAdminViewModel();
            titreViewModel.Titre = Startup.ititreRepository.Find(id);
            return View(titreViewModel);
        }
        /// <summary>
        /// La méthode effectue le traitement pour la suppression d'un titre
        /// </summary>
        /// <param name="titre">Objet Titre à supprimer</param>
        /// <returns>Une redirection vers la page index d'administration des titres</returns>
        [HttpPost]
        public IActionResult ActionDelete(Titre titre)
        {
            Startup.ititreRepository.Delete(Startup.ititreRepository.Find(titre.IdTitre));
            return RedirectToAction("Index");
        }

    }
}
