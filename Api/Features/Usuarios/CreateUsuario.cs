using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class CreateUsuario
{
    public record Command(string UserName, string Email, string Password, string Rol, DateTime? FechaExpiracion);

    public class Handler
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public Handler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<int> Handle(Command command, ClaimsPrincipal currentUser)
        {
            // Verifica si el usuario actual es administrador
            if (!currentUser.IsInRole("Administrador"))
                throw new UnauthorizedAccessException("Solo el administrador puede crear usuarios y roles.");

            var user = new ApplicationUser
            {
                UserName = command.UserName,
                Email = command.Email,
                FechaExpiracion = command.Rol == "Administrador" ? null : command.FechaExpiracion
            };

            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded) throw new Exception("Error creando usuario");

            if (!await _roleManager.RoleExistsAsync(command.Rol))
                await _roleManager.CreateAsync(new IdentityRole<int>(command.Rol));

            await _userManager.AddToRoleAsync(user, command.Rol);

            return user.Id;
        }
    }
}