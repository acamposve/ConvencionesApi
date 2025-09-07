namespace Domain
{
    public class Acuerdo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int ContratoId { get; set; }
    }
}
