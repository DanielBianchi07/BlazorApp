using BlazorApp.Web.Components;
using BlazorApp.Web.Services;

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

var app = builder.Build();

public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication("MyCookieAuthenticationScheme")
        .AddCookie("MyCookieAuthenticationScheme", options =>
        {
            options.Cookie.Name = "MyCookie";
            options.LoginPath = "/login";
        });

    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<WeatherForecastService>();
}

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