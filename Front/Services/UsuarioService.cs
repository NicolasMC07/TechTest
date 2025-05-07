using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Front.Interfaces;
using Front.Models;

namespace Front.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios");
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _http.GetFromJsonAsync<Usuario>($"api/usuarios/{id}");
        }

        public async Task<bool> CreateUsuario(Usuario usuario)
        {
            var response = await _http.PostAsJsonAsync("api/usuarios", usuario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var response = await _http.PutAsJsonAsync($"api/usuarios/{usuario.Id}", usuario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var response = await _http.DeleteAsync($"api/usuarios/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}