using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class CursoConteudoSqlRepository : DatabaseConnection, ICursoConteudoSqlRepository
{
    public void Create(CursoConteudo cursoConteudo)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CURSOS_CONTEUDOS VALUES (@cursoId, @conteudoId, @status)";

        cmd.Parameters.AddWithValue("@cursoId", cursoConteudo.CursoId);
        cmd.Parameters.AddWithValue("@conteudoId", cursoConteudo.ConteudoProgramaticoId);
        cmd.Parameters.AddWithValue("@status", cursoConteudo.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<CursoConteudo> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS_CONTEUDOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<CursoConteudo> cursoConteudos = new List<CursoConteudo>();

        while(reader.Read())
        {
            CursoConteudo cursoConteudo = new CursoConteudo();
            cursoConteudo.CursoId = reader.GetGuid(0);
            cursoConteudo.ConteudoProgramaticoId = reader.GetGuid(1);
            cursoConteudo.Status = reader.GetInt32(2);

            cursoConteudos.Add(cursoConteudo);
        }

        return cursoConteudos;
    }

    public CursoConteudo Read(Guid idCurso, Guid idConteudo)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS_CONTEUDOS WHERE CONTEUDO_ID = @idConteudo AND CURSO_ID = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", idCurso);
        cmd.Parameters.AddWithValue("@idConteudo", idConteudo);

        SqlDataReader reader = cmd.ExecuteReader();

        CursoConteudo cursoConteudo = new CursoConteudo();

        while(reader.Read())
        {
            cursoConteudo.CursoId = reader.GetGuid(0);
            cursoConteudo.ConteudoProgramaticoId = reader.GetGuid(1);
            cursoConteudo.Status = reader.GetInt32(2);
        }

        return cursoConteudo;
    }

    public void Update(CursoConteudo cursoConteudo, Guid idCurso, Guid idConteudo)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CURSOS_CONTEUDOS SET STATUS = @status WHERE CURSO_ID = @idCurso AND CONTEUDO_ID = @idConteudo";

        cmd.Parameters.AddWithValue("@idCurso", idCurso);
        cmd.Parameters.AddWithValue("@idConteudo", idConteudo);
        cmd.Parameters.AddWithValue("@status", cursoConteudo.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idCurso, Guid idConteudo)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CURSOS_CONTEUDOS WHERE CONTEUDO_ID = @idConteudo AND CURSO_ID = @idCurso";

        cmd.Parameters.AddWithValue("@idConteudo", idConteudo);
        cmd.Parameters.AddWithValue("@idCurso", idCurso);
        cmd.ExecuteNonQuery();
    }
}