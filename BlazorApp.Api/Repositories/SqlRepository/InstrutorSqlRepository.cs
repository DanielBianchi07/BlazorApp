using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class InstrutorSqlRepository : DatabaseConnection, IInstrutorSqlRepository
{
    public void Create(Instrutor instrutor)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO INSTRUTORES VALUES (@idInstrutor, @especializacao, @assinatura, @registro, @status)";

        cmd.Parameters.AddWithValue("@idInstrutor", instrutor.PessoaId);
        cmd.Parameters.AddWithValue("@especializacao", instrutor.Especializacao);
        cmd.Parameters.AddWithValue("@assinatura", instrutor.Assinatura);
        cmd.Parameters.AddWithValue("@registro", instrutor.Registro);
        cmd.Parameters.AddWithValue("@status", instrutor.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Instrutor> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM INSTRUTORES";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Instrutor> instrutores = new List<Instrutor>();

        while(reader.Read())
        {
            Instrutor instrutor = new Instrutor();
            instrutor.PessoaId = reader.GetGuid(0);
            instrutor.Especializacao = reader.GetString(1);
            instrutor.Assinatura = reader.GetString(2);
            instrutor.Registro = reader.GetString(3);
            instrutor.Status = reader.GetInt32(4);

            instrutores.Add(instrutor);
        }

        return instrutores;
    }

    public Instrutor Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM INSTRUTORES WHERE PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idPessoa", id);

        SqlDataReader reader = cmd.ExecuteReader();

        Instrutor instrutor = new Instrutor();

        while(reader.Read())
        {
            instrutor.PessoaId = reader.GetGuid(0);
            instrutor.Especializacao = reader.GetString(1);
            instrutor.Assinatura = reader.GetString(2);
            instrutor.Registro = reader.GetString(3);
            instrutor.Status = reader.GetInt32(4);
        }

        return instrutor;
    }

    public void Update(Instrutor instrutor, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE INSTRUTORES SET ESPECIALIZACAO = @especializacao, ASSINATURA = @assinatura, REGISTRO = @registro, STATUS = @status WHERE PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idPessoa", id);
        cmd.Parameters.AddWithValue("@especializacao", instrutor.Especializacao);
        cmd.Parameters.AddWithValue("@assinatura", instrutor.Assinatura);
        cmd.Parameters.AddWithValue("@registro", instrutor.Registro);
        cmd.Parameters.AddWithValue("@status", instrutor.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM INSTRUTORES WHERE PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idPessoa", id);
        cmd.ExecuteNonQuery();
    }
}