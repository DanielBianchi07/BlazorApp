using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class AlternativaSqlRepository : DatabaseConnection, IAlternativaRepository
{
    public void Create(Alternativa alternativa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ALTERNATIVAS VALUES (@id, @conteudo, @status, @questao_id)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@conteudo", alternativa.Conteudo);
        cmd.Parameters.AddWithValue("@status", alternativa.Status);
        cmd.Parameters.AddWithValue("@questao_id", alternativa.QuestaoId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Alternativa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALTERNATIVAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Alternativa> alternativas = new List<Alternativa>();

        while(reader.Read())
        {
            Alternativa alternativa = new Alternativa();
            alternativa.Id = reader.GetGuid(0);
            alternativa.Conteudo = reader.GetString(1);
            alternativa.Status = reader.GetInt16(2);
            alternativa.QuestaoId = reader.GetGuid(3);

            alternativas.Add(alternativa);
        }

        return alternativas;
    }

    public void Update(Alternativa alternativa, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ALTERNATIVAS SET CONTEUDO = @conteudo, STATUS = @status, QUESTAO_ID = @questao_id WHERE ID_ALTERNATIVA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@conteudo", alternativa.Conteudo);
        cmd.Parameters.AddWithValue("@status", alternativa.Status);
        cmd.Parameters.AddWithValue("@questao_id", alternativa.QuestaoId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ALTERNATIVAS WHERE ID_ALTERNATIVA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}