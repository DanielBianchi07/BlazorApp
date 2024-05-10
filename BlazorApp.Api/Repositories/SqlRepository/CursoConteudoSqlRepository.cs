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
        cmd.CommandText = "INSERT INTO CURSOS_CONTEUDOS VALUES (@curso_id, @conteudo_id, @status)";

        cmd.Parameters.AddWithValue("@curso_id", cursoConteudo.CursoId);
        cmd.Parameters.AddWithValue("@conteudo_id", cursoConteudo.ConteudoProgramaticoId);
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

    public IEnumerable<CursoConteudo> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS_CONTEUDOS WHERE CONTEUDO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);

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

    public void Update(CursoConteudo cursoConteudo, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CURSOS_CONTEUDOS SET CURSO_ID = @curso_id, CONTEUDO_ID = @conteudo_id, STATUS = @status";

        cmd.Parameters.AddWithValue("@curso_id", cursoConteudo.CursoId);
        cmd.Parameters.AddWithValue("@conteudo_id", cursoConteudo.ConteudoProgramaticoId);
        cmd.Parameters.AddWithValue("@status", cursoConteudo.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CURSOS_CONTEUDOS WHERE CONTEUDO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}