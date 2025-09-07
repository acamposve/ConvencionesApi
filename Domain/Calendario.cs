namespace Domain
{
    public class Calendario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Color { get; set; } = "#FFFFFF";
    }
}
