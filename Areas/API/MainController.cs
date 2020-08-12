using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Newtonsoft.Json;

namespace Webzine.WebApplication.Areas.API
{
    public class MainController : Controller
    {
        /// <summary>
        /// Retourne tous les Artistes en JSON.
        /// </summary>
        /// <returns>Liste d'Artiste en JSON</returns>
        [Route("api/Artistes")]
        [HttpGet]
        public IActionResult Artistes()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.iartisteRepository.FindAll(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne l'artiste ayant l'id recherché.
        /// </summary>
        /// <param name="id">Id du Titre recheché</param>
        /// <returns>Artiste en JSON</returns>
        [Route("api/Artiste/{id}")]
        [HttpGet]
        public IActionResult Artiste(int id)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.iartisteRepository.Find(id), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne tous les commentaires en JSON.
        /// </summary>
        /// <returns>Liste de commentaire en JSON</returns>
        [Route("api/Commentaires")]
        [HttpGet]
        public IActionResult Commentaires()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.icommentaireRepository.FindAll(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne le commentaire ayant l'id recherché.
        /// </summary>
        /// <param name="id">Id du Titre recheché</param>
        /// <returns>Commentaire en JSON</returns>
        [Route("api/Commentaire/{id}")]
        [HttpGet]
        public IActionResult Commentaire(int id)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.icommentaireRepository.Find(id), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne tous les Styles en JSON.
        /// </summary>
        /// <returns>Liste de Style en JSON</returns>
        [Route("api/Styles")]
        [HttpGet]
        public IActionResult Styles()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.istyleRepository.FindAll(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne le Style ayant l'id recherché.
        /// </summary>
        /// <param name="id">Id du Titre recheché</param>
        /// <returns>Style en JSON</returns>
        [Route("api/Style/{id}")]
        [HttpGet]
        public IActionResult Style(int id)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.istyleRepository.Find(id), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne tous les titres en JSON.
        /// </summary>
        /// <returns>Liste de Titres en JSON</returns>
        [Route("api/Titres")]
        [HttpGet]
        public IActionResult Titres()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.ititreRepository.FindAll(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })) ;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retourne le titre ayant l'id recherché.
        /// </summary>
        /// <param name="id">Id du Titre recheché</param>
        /// <returns>Titre en JSON</returns>
        [Route("api/Titre/{id}")]
        [HttpGet]
        public IActionResult Titre(int id)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Startup.ititreRepository.Find(id), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ajoute un nouveau titre.
        /// </summary>
        /// <param name="titre">Titre a ajouter</param>
        /// <returns>Titre en JSON</returns>
        [Route("api/Post")]
        [HttpPost]
        public IActionResult AddTitre([FromBody]Titre titre)
        {
            try
            {
                Startup.ititreRepository.Add(titre);
                return Ok(JsonConvert.SerializeObject(titre));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifier le titre ayant l'id recherché.
        /// </summary>
        /// <param name="id">Id du Titre recheché</param>
        /// <returns></returns>
        [Route("api/Put/Titre/{id}")]
        [HttpPut]
        public IActionResult ModifyTitre(int id)
        {
            try
            {
                Startup.ititreRepository.Update(Startup.ititreRepository.Find(id));
            }
            catch (System.Exception)
            {
                throw;
            }
            return null;
        }

        /// <summary>
        /// Supprime le titre ayant l'id recherché.
        /// </summary>
        /// <param name="id">Id du Titre recheché</param>
        /// <returns></returns>
        [Route("api/Delete/Titre/{id}")]
        [HttpDelete]
        public IActionResult DeleteTitre(int id)
        {
            try
            {
                Startup.ititreRepository.Delete(Startup.ititreRepository.Find(id));
            }
            catch (System.Exception)
            {
                throw;
            }
            return null;
        }
    }
}