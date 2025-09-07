namespace Domain
{
    public class Bitacora
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Accion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Ip { get; set; } = string.Empty;
    }
}
