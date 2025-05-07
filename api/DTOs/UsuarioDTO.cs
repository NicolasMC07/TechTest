namespace api.DTOs
{
    public class UsuarioDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}