namespace Domain
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty; // Info, Warning, Error
        public int UsuarioId { get; set; }
    }
}
