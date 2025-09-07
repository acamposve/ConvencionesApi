namespace Domain
{
    public class Tema
    {
        public int Id { get; set; }
        public int ForoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }
    }
}
