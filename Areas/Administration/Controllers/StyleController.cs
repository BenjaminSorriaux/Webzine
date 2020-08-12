using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Administration.Controllers
{
    [Area("Administration")]
    public class StyleController : Controller
    {
        /// <summary>
        /// La methode Index appelle la vue qui contient tout les styles
        /// </summary>
        /// <returns>La vue avec en paramètre le view model contenant les styles</returns>
        public IActionResult Index(string MessageErreur = null)
        {            
            BaseViewModel baseViewModel = new BaseViewModel();
            baseViewModel.Styles = Startup.istyleRepository.FindAll().ToList();
            baseViewModel.MessageErreur = MessageErreur;
            return View(baseViewModel);
        }

        /// <summary>
        /// La methode AddStyle renvoie la vue qui contient les champs de création d'un style
        /// </summary>
        /// <param name="id">Id d'un style que l'on veut modifier</param>
        /// <returns>La vue avec le view model contenant les informations du style déjà existant</returns>
        public IActionResult AddStyle(int id)
        {
            StyleAdminViewModel styleAdminViewModel = new StyleAdminViewModel();
            if (id != 0)
            {
                styleAdminViewModel.Style = Startup.istyleRepository.Find(id);
            }
            return View(styleAdminViewModel);
        }

        /// <summary>
        /// Permet de determiner si l'utilisateur effectue une modification ou une création d'un style
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitAction(Style style)
        {
            if (style.IdStyle == 0)
            {
                ActionAdd(style);
            }
            else
            {
                ActionEdit(style);
            }
            //retour à la vue préçedente
            return RedirectToAction("Index");
        }


        /// <summary>
        /// La méthode effectue le traitement de création d'un style et redirige l'utilisateur sur la page index d'administration des stymes
        /// </summary>
        /// <param name="style">L'objet style contenant les informations du nouveau style à créer</param>
        /// <returns>Une redirection vers la page d'index d'administration des styles</returns>
        [HttpPost]
        public IActionResult ActionAdd(Style style)
        {
            Startup.istyleRepository.Add(style);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// La méthode effectue les traitement pour éditer un style précédemment créer
        /// </summary>
        /// <param name="style">L'objet style avec les modifications à mettre à jour</param>
        /// <returns>Une redirection vers la page d'index d'administration des style</returns>
        [HttpPost]
        public IActionResult ActionEdit(Style style)
        {
            Startup.istyleRepository.Update(style);
            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// La méthode renvoie la vue de confirmation de suppression du style
        /// </summary>
        /// <param name="id">Identifiant du style à supprimer</param>
        /// <returns>Renvoie la vue de confirmation de suppression avec en paramètre l'objet view model avec les informations du style à supprimer</returns>
        public IActionResult DeleteStyle(int id)
        {
            StyleAdminViewModel styleAdminViewModel = new StyleAdminViewModel();
            styleAdminViewModel.Style = Startup.istyleRepository.Find(id);
            return View(styleAdminViewModel);
        }

        /// <summary>
        /// La méthode effectue le traitement de suppression du style
        /// </summary>
        /// <param name="style">L'objet style contenant l'id du style à supprimer</param>
        /// <returns>Une redirection vers l'index d'administration des styles</returns>
        [HttpPost]
        public IActionResult ActionDelete(Style style)
        {

            string messageErreur = null;
            try
            {
                style = Startup.istyleRepository.Find(style.IdStyle);
                if (!style.TitresStyles.Any())
                {
                    Startup.istyleRepository.Delete(style);
                }
                else
                {
                    messageErreur = "Suppression échoué : des titres sont liés au style";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index", new { MessageErreur = messageErreur });

        }
    }
}
