using api.Models;

namespace api.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}