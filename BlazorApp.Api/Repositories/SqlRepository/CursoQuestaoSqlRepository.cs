using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class CursoQuestaoSqlRepository : DatabaseConnection, ICursoQuestaoSqlRepository
{
    public void Create(CursoQuestao cursoQuestao)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CURSOS_QUESTOES VALUES (@curso_id, @questao_id, @status)";

        cmd.Parameters.AddWithValue("@curso_id", cursoQuestao.CursoId);
        cmd.Parameters.AddWithValue("@questao_id", cursoQuestao.QuestaoId);
        cmd.Parameters.AddWithValue("@status", cursoQuestao.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<CursoQuestao> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS_QUESTOES";

        SqlDataReader reader = cmd.ExecuteReader();

        List<CursoQuestao> cursoQuestoes = new List<CursoQuestao>();

        while(reader.Read())
        {
            CursoQuestao cursoQuestao = new CursoQuestao();
            cursoQuestao.CursoId = reader.GetGuid(0);
            cursoQuestao.QuestaoId = reader.GetGuid(1);
            cursoQuestao.Status = reader.GetInt32(2);

            cursoQuestoes.Add(cursoQuestao);
        }

        return cursoQuestoes;
    }

    public IEnumerable<CursoQuestao> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS_QUESTOES WHERE QUESTAO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<CursoQuestao> cursoQuestoes = new List<CursoQuestao>();

        while(reader.Read())
        {
            CursoQuestao cursoQuestao = new CursoQuestao();
            cursoQuestao.CursoId = reader.GetGuid(0);
            cursoQuestao.QuestaoId = reader.GetGuid(1);
            cursoQuestao.Status = reader.GetInt32(2);

            cursoQuestoes.Add(cursoQuestao);
        }

        return cursoQuestoes;
    }

    public void Update(CursoQuestao cursoQuestao, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CURSOS_QUESTOES SET CURSO_ID = @curso_id, QUESTAO_ID = @questao_id, STATUS = @status";

        cmd.Parameters.AddWithValue("@curso_id", cursoQuestao.CursoId);
        cmd.Parameters.AddWithValue("@questao_id", cursoQuestao.QuestaoId);
        cmd.Parameters.AddWithValue("@status", cursoQuestao.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CURSOS_QUESTOES WHERE QUESTAO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}