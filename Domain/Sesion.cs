namespace Domain
{
    public class Sesion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
