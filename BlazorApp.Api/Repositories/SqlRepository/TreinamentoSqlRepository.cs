using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TreinamentoSqlRepository : DatabaseConnection, ITreinamentoSqlRepository
{
    public void Create(Treinamento treinamento, Guid idCurso)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TREINAMENTOS VALUES (@id, @tipo, @curso_id, @status)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@tipo", treinamento.Tipo);
        cmd.Parameters.AddWithValue("@curso_id", idCurso);
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
            treinamento.Tipo = reader.GetInt32(1);
            treinamento.CursoId = reader.GetGuid(2);
            treinamento.Status = reader.GetInt32(3);

            treinamentos.Add(treinamento);
        }

        return treinamentos;
    }

    public IEnumerable<Treinamento> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TREINAMENTOS WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<Treinamento> treinamentos = new List<Treinamento>();

        while(reader.Read())
        {
            Treinamento treinamento = new Treinamento();
            treinamento.Id = reader.GetGuid(0);
            treinamento.Tipo = reader.GetInt32(1);
            treinamento.CursoId = reader.GetGuid(2);
            treinamento.Status = reader.GetInt32(3);

            treinamentos.Add(treinamento);
        }

        return treinamentos;
    }

    public void Update(Treinamento treinamento, Guid idCurso)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE TREINAMENTOS SET TIPO = @tipo, CURSO_ID = @curso_id, STATUS = @status WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", treinamento.Id);
        cmd.Parameters.AddWithValue("@tipo", treinamento.Tipo);
        cmd.Parameters.AddWithValue("@curso_id", idCurso);
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