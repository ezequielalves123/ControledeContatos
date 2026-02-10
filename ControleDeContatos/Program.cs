using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- COPIE E COLE ESTE TRECHO ABAIXO ---

// 1. Pega a string de conexão que você configurou no appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DataBase");

// 2. Registra o seu Contexto de Banco de Dados (substitua 'BancoContext' pelo nome que você criou)
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
// --- FIM DO TRECHO ---

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
