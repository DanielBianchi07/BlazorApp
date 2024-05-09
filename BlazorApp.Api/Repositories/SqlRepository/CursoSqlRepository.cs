using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class CursoSqlRepository : DatabaseConnection, ICursoSqlRepository
{
    public void Create(Curso curso)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CURSOS VALUES (@id, @nome_curso, @logo, @carga_horaria_per, @carga_horaria_ini, @validade, @status)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nome_curso", curso.Nome);
        cmd.Parameters.AddWithValue("@logo", curso.Logo);
        cmd.Parameters.AddWithValue("@carga_horaria_per", curso.CargaHorariaPeriodico);
        cmd.Parameters.AddWithValue("@carga_horaria_ini", curso.CargaHorariaInicial);
        cmd.Parameters.AddWithValue("@validade", curso.Validade);
        cmd.Parameters.AddWithValue("@status", curso.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Curso> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Curso> cursos = new List<Curso>();

        while(reader.Read())
        {
            Curso curso = new Curso();
            curso.Id = reader.GetGuid(0);
            curso.Nome = reader.GetString(1);
            curso.Logo = reader.GetString(2);
            curso.CargaHorariaPeriodico = reader.GetInt32(3);
            curso.CargaHorariaInicial = reader.GetInt32(4);
            curso.Validade = reader.GetInt32(5);
            curso.Status = reader.GetInt32(6);

            cursos.Add(curso);
        }

        return cursos;
    }

    public void Update(Curso curso, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CURSOS SET NOME_CURSO = @nome, LOGO = @logo, CARGA_HORARIA_PER = @carga_horaria_per, CARGA_HORARIA_INI = @carga_horaria_ini, VALIDADE = @validade , STATUS = @status WHERE ID_CURSO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nome_curso", curso.Nome);
        cmd.Parameters.AddWithValue("@logo", curso.Logo);
        cmd.Parameters.AddWithValue("@carga_horaria_per", curso.CargaHorariaPeriodico);
        cmd.Parameters.AddWithValue("@carga_horaria_ini", curso.CargaHorariaInicial);
        cmd.Parameters.AddWithValue("@validade", curso.Validade);
        cmd.Parameters.AddWithValue("@status", curso.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CURSOS WHERE ID_CURSO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}