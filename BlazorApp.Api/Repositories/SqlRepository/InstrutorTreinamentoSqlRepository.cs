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
        cmd.CommandText = "INSERT INTO INSTRUTORES_TREINAMENTOS VALUES (@pessoa_id, @treinamento_id)";

        cmd.Parameters.AddWithValue("@pessoa_id", instrutorTreinamento.PessoaId);
        cmd.Parameters.AddWithValue("@treinamento_id", instrutorTreinamento.TreinamentoId);

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

    public void Update(InstrutorTreinamento instrutorTreinamento, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE INSTRUTORES_TREINAMENTOS SET PESSOA_ID = @pessoa_id, TREINAMENTO_ID = @treinamento_id";

        cmd.Parameters.AddWithValue("@pessoa_id", instrutorTreinamento.PessoaId);
        cmd.Parameters.AddWithValue("@treinamento_id", instrutorTreinamento.TreinamentoId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM INSTRUTORES_TREINAMENTOS WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}