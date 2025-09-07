namespace Domain
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ruta { get; set; } = string.Empty;
        public DateTime FechaCarga { get; set; }
        public int UsuarioId { get; set; }
    }
}
