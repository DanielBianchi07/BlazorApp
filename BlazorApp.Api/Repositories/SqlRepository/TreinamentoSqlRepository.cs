using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TreinamentoSqlRepository : DatabaseConnection, ITreinamentoRepository
{
    public void Create(Treinamento treinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TREINAMENTOS VALUES (@id, @tipo, @curso_id, @status)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@tipo", treinamento.Tipo);
        cmd.Parameters.AddWithValue("@razao_social", treinamento.CursoId);
        cmd.Parameters.AddWithValue("@status", treinamento.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Treinamento> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TREINAMENTOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Treinamento> treinamentos = new List<Treinamento>();

        while(reader.Read())
        {
            Treinamento treinamento = new Treinamento();
            treinamento.Id = reader.GetGuid(0);
            treinamento.Tipo = reader.GetInt16(1);
            treinamento.CursoId = reader.GetGuid(2);
            treinamento.Status = reader.GetInt16(3);

            treinamentos.Add(treinamento);
        }

        return treinamentos;
    }

    public void Update(Treinamento treinamento, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE TREINAMENTOS SET TIPO = @tipo, CURSO_ID = @curso_id, STATUS = @status WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@tipo", treinamento.Tipo);
        cmd.Parameters.AddWithValue("@curso_id", treinamento.CursoId);
        cmd.Parameters.AddWithValue("@status", treinamento.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM TREINAMENTOS WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}