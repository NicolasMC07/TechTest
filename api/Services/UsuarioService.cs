using api.Interfaces;
using api.Interfaces.Repository;
using api.Models;

namespace api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = _repository.GetAll();
            return usuarios ?? new List<Usuario>();
        }

        public Usuario GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor a cero.");

            var usuario = _repository.GetById(id);

            if (usuario == null)
                throw new KeyNotFoundException($"No se encontró un usuario con ID {id}.");

            return usuario;
        }

        public void Add(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre del usuario es obligatorio.");

            _repository.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            var existingUser = _repository.GetById(usuario.Id);
            if (existingUser == null)
                throw new KeyNotFoundException($"No se puede actualizar. Usuario con ID {usuario.Id} no encontrado.");

            _repository.Update(usuario);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor a cero.");

            var usuario = _repository.GetById(id);
            if (usuario == null)
                throw new KeyNotFoundException($"No se puede eliminar. Usuario con ID {id} no encontrado.");

            _repository.Delete(id);
        }
    }
}