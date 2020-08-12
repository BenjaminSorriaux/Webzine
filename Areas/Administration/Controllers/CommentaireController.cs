using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Webzine.Entity;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Administration.Controllers
{
    [Area("Administration")]
    public class CommentaireController : Controller
    {
        /// <summary>
        /// La méthode renvoie la page d'administration des commentaires
        /// </summary>
        /// <returns>La page d'administrations des commentaires avec en paramètres un view model contenant une liste de commantaires</returns>
        public IActionResult Index()
        {
            CommentaireAdminViewModel commentaireAdminViewModel = new CommentaireAdminViewModel();
            commentaireAdminViewModel.Commentaires = Startup.icommentaireRepository.FindAll().ToList();
            return View(commentaireAdminViewModel);
        }

        /// <summary>
        /// La méthode effectue le traitement de suppression d'un commentaire
        /// </summary>
        /// <param name="id">Identifiant du commentaire à supprimer</param>
        /// <returns>Une redirection vers la page d'index d'administration des commentaires</returns>
        [HttpPost]
        public IActionResult ActionDelete(int id)
        {
            Startup.icommentaireRepository.Delete(Startup.icommentaireRepository.Find(id));
            return RedirectToAction("Index");
        }
    }
}