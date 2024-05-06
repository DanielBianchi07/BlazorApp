using BlazorApp.Api.Repositories.Interface;
using BlazorApp.Api.Repositories.SqlRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IEmpresaRepository, EmpresaSqlRepository>();
builder.Services.AddTransient<IAlunoEmpresaRepository, AlunoEmpresaSqlRepository>();
builder.Services.AddTransient<IAlunoRepository, AlunoSqlRepository>();
builder.Services.AddTransient<IPessoaRepository, PessoaSqlRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API BlazorApp");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();