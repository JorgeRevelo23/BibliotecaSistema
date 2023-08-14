using BiblioMundo.DatosDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseInMemoryDatabase(databaseName: "BiblioMundo"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "CookieAuthetication";
    options.DefaultSignInScheme = "CookieAuthetication";
    options.DefaultChallengeScheme = "CookieAuthetication";

})
    .AddCookie("CookieAuthetication", options =>
    {
        options.LoginPath = "/Account/Login";
        options.LoginPath = "/Account/Logout";
    });
builder.Services.AddControllersWithViews();

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

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<BibliotecaContext>();
    context.Database.EnsureCreated();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger>();
    logger.LogError(ex, "Ocurrio un error en la base de datos");
}


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
