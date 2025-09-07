namespace Domain
{
    public class Contrato
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
