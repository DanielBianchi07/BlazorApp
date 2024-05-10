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
        cmd.CommandText = "INSERT INTO INSTRUTORES VALUES (@id, @especializacao, @assinatura, @registro, @status)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
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

    public IEnumerable<Instrutor> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM INSTRUTORES WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);

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

    public void Update(Instrutor instrutor, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE INSTRUTORES SET ESPECIALIZACAO = @especializacao, ASSINATURA = @assinatura, REGISTRO = @registro, STATUS = @status WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
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
        cmd.CommandText = "DELETE FROM INSTRUTORES WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}