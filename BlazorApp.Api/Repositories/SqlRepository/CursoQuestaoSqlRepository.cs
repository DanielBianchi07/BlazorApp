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
        cmd.CommandText = "INSERT INTO CURSOS_QUESTOES VALUES (@cursoId, @questaoId, @status)";

        cmd.Parameters.AddWithValue("@cursoid", cursoQuestao.CursoId);
        cmd.Parameters.AddWithValue("@questaoId", cursoQuestao.QuestaoId);
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

    public IEnumerable<CursoQuestao> Read(Guid idCurso, Guid idQuestao)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS_QUESTOES WHERE QUESTAO_ID = @idQuestao AND CURSO_ID = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", idCurso);
        cmd.Parameters.AddWithValue("@idQuestao", idQuestao);

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

    public void Update(CursoQuestao cursoQuestao, Guid idCurso, Guid idQuestao)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CURSOS_QUESTOES SET STATUS = @status WHERE QUESTAO_ID = @idQuestao AND CURSO_ID = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", idCurso);
        cmd.Parameters.AddWithValue("@idQuestao", idQuestao);
        cmd.Parameters.AddWithValue("@status", cursoQuestao.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idCurso, Guid idQuestao)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CURSOS_QUESTOES WHERE QUESTAO_ID = @idQuestao AND CURSO_ID = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", idCurso);
        cmd.Parameters.AddWithValue("@idQuestao", idQuestao);
        cmd.ExecuteNonQuery();
    }
}