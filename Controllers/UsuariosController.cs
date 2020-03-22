using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoN.Models;
using ProjetoN.Repositorio;

namespace ProjetoN.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        protected readonly IUsuarioRepository _usuarioRpository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRpository = usuarioRepository;
        }

        [HttpGet]
        // GET: Usuarios/Details/5
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRpository.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        // GET: Usuarios/Details/5
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioRpository.Find(id);
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);

        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public IActionResult Create([FromBody] Usuario user)
        {
            if (user == null)
                return null; 

            _usuarioRpository.Add(user);
            return CreatedAtRoute("GetUsuario", new {id = user.UsuarioId, user });

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario user)
        {
            if (user == null || user.UsuarioId != id)
                return NotFound(); ;

            var usuario = _usuarioRpository.Find(id);

            if (usuario == null)
                return NotFound(); ;

            usuario.Nome = user.Nome;
            _usuarioRpository.Updade(usuario);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] Usuario user)
        {
            var usuario = _usuarioRpository.Find(id);

            if (usuario == null)
                return NotFound();

            _usuarioRpository.Remove(user.UsuarioId);
            return new NoContentResult();

        }


        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}