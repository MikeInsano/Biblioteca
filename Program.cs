using BibliotecaBolonMiguel.Context;
using BibliotecaBolonMiguel.Services.IServices;
using BibliotecaBolonMiguel.Services.Services;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionString")));

var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings");
var account = new Account(
    cloudinarySettings["CloudName"],
    cloudinarySettings["ApiKey"],
    cloudinarySettings["ApiSecret"]
);
var cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);

// Configurar autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";  // Página de login
        options.AccessDeniedPath = "/Auth/AccessDenied"; // Si no tiene permisos
    });

// Configurar autorización
builder.Services.AddAuthorization();

// Las inyecciones de dependencia
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddScoped<IRolServices, RolServices>();
builder.Services.AddScoped<IGeneroServices, GeneroServices>();
builder.Services.AddScoped<IAutorServices, AutorServices>();
builder.Services.AddScoped<IEditorialServices, EditorialServices>();    
builder.Services.AddScoped<ILibroServices, LibroServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
