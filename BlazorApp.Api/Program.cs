using BlazorApp.Api.Repositories.Interface;
using BlazorApp.Api.Repositories.SqlRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IAlternativaSqlRepository, AlternativaSqlRepository>();
builder.Services.AddTransient<IAlunoEmpresaSqlRepository, AlunoEmpresaSqlRepository>();
builder.Services.AddTransient<IAlunoSqlRepository, AlunoSqlRepository>();
builder.Services.AddTransient<IAlunoTreinamentoSqlRepository, AlunoTreinamentoSqlRepository>();
builder.Services.AddTransient<ICadernoRespostaSqlRepository, CadernoRespostaSqlRepository>();
builder.Services.AddTransient<ICertificadoSqlRepository, CertificadoSqlRepository>();
builder.Services.AddTransient<ICidadeSqlRepository, CidadeSqlRepository>();
builder.Services.AddTransient<IConteudoProgramaticoSqlRepository, ConteudoProgramaticoSqlRepository>();
builder.Services.AddTransient<ICursoConteudoSqlRepository, CursoConteudoSqlRepository>();
builder.Services.AddTransient<ICursoQuestaoSqlRepository, CursoQuestaoSqlRepository>();
builder.Services.AddTransient<ICursoSqlRepository, CursoSqlRepository>();
builder.Services.AddTransient<IEmpresaSqlRepository, EmpresaSqlRepository>();
builder.Services.AddTransient<IEnderecoEmpresaSqlRepository, EnderecoEmpresaSqlRepository>();
builder.Services.AddTransient<IEstadoSqlRepository, EstadoSqlRepository>();
builder.Services.AddTransient<IInstrutorSqlRepository, InstrutorSqlRepository>();
builder.Services.AddTransient<IInstrutorTreinamentoSqlRepository, InstrutorTreinamentoSqlRepository>();
builder.Services.AddTransient<IListaPresencaSqlRepository, ListaPresencaSqlRepository>();
builder.Services.AddTransient<IPessoaSqlRepository, PessoaSqlRepository>();
builder.Services.AddTransient<IProvaQuestaoSqlRepository, ProvaQuestaoSqlRepository>();
builder.Services.AddTransient<IProvaSqlRepository, ProvaSqlRepository>();
builder.Services.AddTransient<IQuestaoSqlRepository, QuestaoSqlRepository>();
builder.Services.AddTransient<ITelefonePessoaSqlRepository, TelefonePessoaSqlRepository>();
builder.Services.AddTransient<ITelefoneEmpresaSqlRepository, TelefoneEmpresaSqlRepository>();
builder.Services.AddTransient<ITreinamentoSqlRepository, TreinamentoSqlRepository>();
builder.Services.AddTransient<IUsuarioSqlRepository, UsuarioSqlRepository>();


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