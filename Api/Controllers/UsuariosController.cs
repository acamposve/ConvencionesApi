using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public UsuariosController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Solo el administrador puede crear usuarios y roles
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioDto dto)
    {
        if (dto.Rol != "Administrador" && dto.FechaExpiracion == null)
            return BadRequest("Los usuarios no administradores requieren fecha de expiración.");

        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            FechaExpiracion = dto.Rol == "Administrador" ? null : dto.FechaExpiracion
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        if (!await _roleManager.RoleExistsAsync(dto.Rol))
            await _roleManager.CreateAsync(new IdentityRole<int>(dto.Rol));

        await _userManager.AddToRoleAsync(user, dto.Rol);

        return Ok(new { user.Id, user.UserName, user.Email, dto.Rol, user.FechaExpiracion });
    }

    // Ejemplo: obtener todos los usuarios
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public IActionResult GetAll()
    {
        var users = _userManager.Users
            .Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                u.FechaExpiracion
            })
            .ToList();

        return Ok(users);
    }

    // Ejemplo: validar expiración en login (puedes usarlo en tu lógica de autenticación)
    [HttpGet("validate/{id}")]
    [Authorize]
    public async Task<IActionResult> ValidateExpiracion(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Administrador") && user.FechaExpiracion.HasValue && user.FechaExpiracion.Value < DateTime.UtcNow)
            return Unauthorized("Usuario expirado.");

        return Ok("Usuario válido.");
    }
}

// DTO para crear usuario
public class CreateUsuarioDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Rol { get; set; }
    public DateTime? FechaExpiracion { get; set; }
}