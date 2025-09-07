namespace Domain
{
    public class Archivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public long Tamano { get; set; }
        public string Ruta { get; set; } = string.Empty;
        public DateTime FechaSubida { get; set; }
    }
}
