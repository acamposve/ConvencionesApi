namespace Domain;

public class Actividad
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public Guid UsuarioId { get; set; }
}
