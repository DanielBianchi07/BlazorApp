using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class QuestaoSqlRepository : DatabaseConnection, IQuestaoSqlRepository
{
    public void Create(Questao questao)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO QUESTOES VALUES (@id_questao, @pergunta)";

        cmd.Parameters.AddWithValue("@id_questao", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@pergunta", questao.Conteudo);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Questao> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM QUESTOES";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Questao> questoes = new List<Questao>();

        while(reader.Read())
        {
            Questao questao = new Questao();
            questao.Id = reader.GetGuid(0);
            questao.Conteudo = reader.GetString(1);

            questoes.Add(questao);
        }

        return questoes;
    }

    public void Update(Questao questao, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE QUESTOES SET ID_QUESTAO = @id_questao, PERGUNTA = @pergunta";

        cmd.Parameters.AddWithValue("@id_questao", questao.Id);
        cmd.Parameters.AddWithValue("@pergunta", questao.Conteudo);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM QUESTOES WHERE ID_QUESTAO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}