using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TreinamentoSqlRepository : DatabaseConnection, ITreinamentoSqlRepository
{
    public void Create(Treinamento treinamento)
    {
        treinamento.Id = Guid.NewGuid();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TREINAMENTOS VALUES (@id, @tipo, @situacao, @cursoId, @provaId, @status)";

        cmd.Parameters.AddWithValue("@id", treinamento.Id);
        cmd.Parameters.AddWithValue("@tipo", treinamento.Tipo);
        cmd.Parameters.AddWithValue("@situacao", treinamento.Situacao);
        cmd.Parameters.AddWithValue("@cursoId", treinamento.CursoId);
        cmd.Parameters.AddWithValue("@provaId", treinamento.ProvaId);
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
            treinamento.Situacao = reader.GetInt32(2);
            treinamento.CursoId = reader.GetGuid(3);
            treinamento.ProvaId = reader.GetGuid(4);
            treinamento.Status = reader.GetInt32(5);

            treinamentos.Add(treinamento);
        }

        return treinamentos;
    }

    public Treinamento Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TREINAMENTOS WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        Treinamento treinamento = new Treinamento();

        while(reader.Read())
        {
            treinamento.Id = reader.GetGuid(0);
            treinamento.Tipo = reader.GetInt32(1);
            treinamento.Situacao = reader.GetInt32(2);
            treinamento.CursoId = reader.GetGuid(3);
            treinamento.ProvaId = reader.GetGuid(4);
            treinamento.Status = reader.GetInt32(5);
        }

        return treinamento;
    }

    public void Update(Treinamento treinamento, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE TREINAMENTOS SET TIPO = @tipo, SITUACAO = @situacao, CURSO_ID = @cursoId, STATUS = @status WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@tipo", treinamento.Tipo);
        cmd.Parameters.AddWithValue("@situacao", treinamento.Situacao);
        cmd.Parameters.AddWithValue("@cursoId", treinamento.CursoId);
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