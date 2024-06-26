using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class ProvaQuestaoSqlRepository : DatabaseConnection, IProvaQuestaoSqlRepository
{
    public void Create(ProvaQuestao provaQuestao)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO PROVAS_QUESTOES VALUES (@idProva, @idQuestao)";

        cmd.Parameters.AddWithValue("@idProva", provaQuestao.ProvaId);
        cmd.Parameters.AddWithValue("@idQuestao", provaQuestao.QuestaoId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<ProvaQuestao> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM PROVAS_QUESTOES";

        SqlDataReader reader = cmd.ExecuteReader();

        List<ProvaQuestao> provaQuestoes = new List<ProvaQuestao>();

        while(reader.Read())
        {
            ProvaQuestao provaQuestao = new ProvaQuestao();
            provaQuestao.ProvaId = reader.GetGuid(0);
            provaQuestao.QuestaoId = reader.GetGuid(1);

            provaQuestoes.Add(provaQuestao);
        }

        return provaQuestoes;
    }

    public ProvaQuestao Read(Guid idQuestao, Guid idProva)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM PROVAS_QUESTOES WHERE QUESTAO_ID = @idQuestao AND PROVA_ID = @idProva";

        cmd.Parameters.AddWithValue("@idQuestao", idQuestao);
        cmd.Parameters.AddWithValue("@idProva", idProva);

        SqlDataReader reader = cmd.ExecuteReader();

        ProvaQuestao provaQuestao = new ProvaQuestao();

        while(reader.Read())
        {
            provaQuestao.ProvaId = reader.GetGuid(0);
            provaQuestao.QuestaoId = reader.GetGuid(1);
        }

        return provaQuestao;
    }

    public void Update(ProvaQuestao provaQuestao, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE PROVAS_QUESTOES SET PROVA_ID = @prova_id, QUESTAO_ID = @questao_id";

        cmd.Parameters.AddWithValue("@id_treinamento", provaQuestao.ProvaId);
        cmd.Parameters.AddWithValue("@codigo", provaQuestao.QuestaoId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idQuestao, Guid idProva)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM PROVAS_QUESTOES WHERE QUESTAO_ID = @idQuestao AND PROVA_ID = @idProva";

        cmd.Parameters.AddWithValue("@idProva", idProva);
        cmd.Parameters.AddWithValue("@idQuestao", idQuestao);
        cmd.ExecuteNonQuery();
    }
}