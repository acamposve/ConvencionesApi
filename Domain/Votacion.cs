namespace Domain
{
    public class Votacion
    {
        public int Id { get; set; }
        public int AcuerdoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activa { get; set; }
    }
}
