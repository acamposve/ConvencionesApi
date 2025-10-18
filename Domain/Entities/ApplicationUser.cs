using Microsoft.AspNetCore.Identity;
using System; // Agrega esta directiva para DateTime

// Asegúrate de tener instalada la referencia al paquete NuGet:
// Microsoft.AspNetCore.Identity.EntityFrameworkCore

public class ApplicationUser : IdentityUser<int>
{
    public DateTime? FechaExpiracion { get; set; }
    // Puedes agregar otros campos personalizados si lo necesitas
}