using BlazorApp.Web.Components;
using BlazorApp.Web.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Configurar o HttpClient
builder.Services.AddSingleton<HttpClient>(sp =>
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
    return httpClient;
});

// Adicionar o HttpClient aos serviços
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<TelefoneEmpresaService>();
builder.Services.AddScoped<EnderecoEmpresaService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true; // Requer confirmação de conta por email
})
.AddEntityFrameworkStores<ApplicationDbContext>();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));// Use o contexto do banco de dados (opcional)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();