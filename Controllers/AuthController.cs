using System.Security.Claims;
using BibliotecaBolonMiguel.Models.Domain;
using BibliotecaBolonMiguel.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly IUserServices _userServices;
    private readonly IRolServices _rolServices;

    public AuthController(IUserServices userServices, IRolServices rolServices)
    {
        _userServices = userServices;
        _rolServices = rolServices;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = _userServices.ObtenerUsuario().FirstOrDefault(u => u.UserName == username && u.Password == password);

        if (user == null)
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Roles.Nombre)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties { IsPersistent = true };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        if (user.Roles.Nombre == "Admin")
        {
            return RedirectToAction("Index", "User");
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Usuario model)
    {
        // Verificar si el usuario ya existe
        if (_userServices.ObtenerUsuario().Any(u => u.UserName == model.UserName))
        {
            ViewBag.Error = "El nombre de usuario ya existe.";
            return View();
        }

        // Asignar el rol "Usuario" por defecto
        var rolUsuario = _rolServices.ObtenerRoles().FirstOrDefault(r => r.Nombre == "Usuario");
        if (rolUsuario == null)
        {
            ViewBag.Error = "El rol 'Usuario' no existe en la base de datos.";
            return View();
        }

        model.FkRol = rolUsuario.PkRol;

        // Guardar usuario en la base de datos
        _userServices.CrearUsuario(model);

        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}