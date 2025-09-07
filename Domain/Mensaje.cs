namespace Domain
{
    public class Mensaje
    {
        public int Id { get; set; }
        public int TemaId { get; set; }
        public int UsuarioId { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
