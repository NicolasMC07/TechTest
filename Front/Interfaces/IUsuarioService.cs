using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front.Models;

namespace Front.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<bool> CreateUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(int id);
    }
}