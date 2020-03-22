using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoN.Models;

namespace ProjetoN.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjectContext _context;

        public UsuarioRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Add(Usuario user)
        {
            _context.Usuario.Add(user);
            _context.SaveChanges();
        }

        public Usuario Find(int id)
        {
            return _context.Usuario.FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public void Remove(int id)
        {
            var user = _context.Usuario.First(u => u.UsuarioId == id);
            _context.Usuario.Remove(user);
            _context.SaveChanges();
        }

        public void Updade(Usuario user)
        {
            _context.Usuario.Update(user);
            _context.SaveChanges();
        }
    }
}
