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
        cmd.CommandText = "INSERT INTO PROVAS_QUESTOES VALUES (@prova_id, @questao_id)";

        cmd.Parameters.AddWithValue("@id_treinamento", provaQuestao.ProvaId);
        cmd.Parameters.AddWithValue("@codigo", provaQuestao.QuestaoId);

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

    public void Update(ProvaQuestao provaQuestao, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE PROVAS_QUESTOES SET PROVA_ID = @prova_id, QUESTAO_ID = @questao_id";

        cmd.Parameters.AddWithValue("@id_treinamento", provaQuestao.ProvaId);
        cmd.Parameters.AddWithValue("@codigo", provaQuestao.QuestaoId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM PROVAS_QUESTOES WHERE QUESTAO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}