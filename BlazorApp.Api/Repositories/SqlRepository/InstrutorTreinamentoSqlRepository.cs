using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class InstrutorTreinamentoSqlRepository : DatabaseConnection, IInstrutorTreinamentoSqlRepository
{
    public void Create(InstrutorTreinamento instrutorTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO INSTRUTORES_TREINAMENTOS VALUES (@idPessoa, @idTreinamento)";

        cmd.Parameters.AddWithValue("@idPessoa", instrutorTreinamento.PessoaId);
        cmd.Parameters.AddWithValue("@idTreinamento", instrutorTreinamento.TreinamentoId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<InstrutorTreinamento> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM INSTRUTORES_TREINAMENTOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<InstrutorTreinamento> instrutorTreinamentos = new List<InstrutorTreinamento>();

        while(reader.Read())
        {
            InstrutorTreinamento instrutorTreinamento = new InstrutorTreinamento();
            instrutorTreinamento.PessoaId = reader.GetGuid(0);
            instrutorTreinamento.TreinamentoId = reader.GetGuid(1);

            instrutorTreinamentos.Add(instrutorTreinamento);
        }

        return instrutorTreinamentos;
    }

     public InstrutorTreinamento Read(Guid idPessoa, Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM INSTRUTORES_TREINAMENTOS WHERE PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);

        SqlDataReader reader = cmd.ExecuteReader();

        InstrutorTreinamento instrutorTreinamento = new InstrutorTreinamento();

        while(reader.Read())
        {
            instrutorTreinamento.PessoaId = reader.GetGuid(0);
            instrutorTreinamento.TreinamentoId = reader.GetGuid(1);
        }

        return instrutorTreinamento;
    }

    public void Update(InstrutorTreinamento instrutorTreinamento, Guid idPessoa, Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "";

        cmd.Parameters.AddWithValue("", idPessoa);
        cmd.Parameters.AddWithValue("", idTreinamento);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idPessoa, Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM INSTRUTORES_TREINAMENTOS WHERE PESSOA_ID = @idPessoa AND TREINAMENTO_ID = @idTreinamento";

        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);
        cmd.ExecuteNonQuery();
    }
}