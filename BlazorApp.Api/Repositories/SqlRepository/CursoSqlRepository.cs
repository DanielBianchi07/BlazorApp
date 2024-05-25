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
        cmd.CommandText = "INSERT INTO CURSOS VALUES (@idCurso, @nomeCurso, @logo, @cargaHorariaPeriodico, @cargaHorariaInicial, @validade, @status)";

        cmd.Parameters.AddWithValue("@idCurso", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nomeCurso", curso.Nome);
        cmd.Parameters.AddWithValue("@logo", curso.Logo);
        cmd.Parameters.AddWithValue("@cargaHorariaPeriodico", curso.CargaHorariaPeriodico);
        cmd.Parameters.AddWithValue("@cargaHorariaInicial", curso.CargaHorariaInicial);
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

    public Curso Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CURSOS WHERE ID_CURSO = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", id);

        SqlDataReader reader = cmd.ExecuteReader();

        Curso curso = new Curso();

        while(reader.Read())
        {
            curso.Id = reader.GetGuid(0);
            curso.Nome = reader.GetString(1);
            curso.Logo = reader.GetString(2);
            curso.CargaHorariaPeriodico = reader.GetInt32(3);
            curso.CargaHorariaInicial = reader.GetInt32(4);
            curso.Validade = reader.GetInt32(5);
            curso.Status = reader.GetInt32(6);
        }

        return curso;
    }

    public void Update(Curso curso, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CURSOS SET NOME_CURSO = @nomeCurso, LOGO = @logo, CARGA_HORARIA_PER = @cargaHorariaPeriodico, CARGA_HORARIA_INI = @cargaHorariaInicial, VALIDADE = @validade , STATUS = @status WHERE ID_CURSO = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", id);
        cmd.Parameters.AddWithValue("@nomeCurso", curso.Nome);
        cmd.Parameters.AddWithValue("@logo", curso.Logo);
        cmd.Parameters.AddWithValue("@cargaHorariaPeriodico", curso.CargaHorariaPeriodico);
        cmd.Parameters.AddWithValue("@cargaHorariaInicial", curso.CargaHorariaInicial);
        cmd.Parameters.AddWithValue("@validade", curso.Validade);
        cmd.Parameters.AddWithValue("@status", curso.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CURSOS WHERE ID_CURSO = @idCurso";

        cmd.Parameters.AddWithValue("@idCurso", id);
        cmd.ExecuteNonQuery();
    }
}