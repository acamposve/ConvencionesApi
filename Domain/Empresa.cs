namespace Domain
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string Rif { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}
