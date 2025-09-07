namespace Domain
{
    public class Voto
    {
        public int Id { get; set; }
        public int VotacionId { get; set; }
        public int UsuarioId { get; set; }
        public bool Aprobado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
