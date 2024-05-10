using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class AlunoEmpresaSqlRepository : DatabaseConnection, IAlunoEmpresaSqlRepository
{
    public void Create(AlunoEmpresa alunoEmpresa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ALUNOS_EMPRESAS VALUES (@aluno_id, @empresa_id, @status)";

        cmd.Parameters.AddWithValue("@aluno_id", alunoEmpresa.AlunoId);
        cmd.Parameters.AddWithValue("@empresa_id", alunoEmpresa.EmpresaId);
        cmd.Parameters.AddWithValue("@status", alunoEmpresa.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<AlunoEmpresa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALUNOS_EMPRESAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<AlunoEmpresa> alunosEmpresa = new List<AlunoEmpresa>();

        while(reader.Read())
        {
            AlunoEmpresa alunoEmpresa = new AlunoEmpresa();
            alunoEmpresa.AlunoId = reader.GetGuid(0);
            alunoEmpresa.EmpresaId = reader.GetGuid(1);
            alunoEmpresa.Status = reader.GetInt32(2);

            alunosEmpresa.Add(alunoEmpresa);
        }

        return alunosEmpresa;
    }

    public IEnumerable<AlunoEmpresa> Read(Guid aluno_id, Guid empresa_id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALUNOS_EMPRESAS WHERE ALUNO_ID = @aluno_id and EMPRESA_ID = @empresa_id";

        cmd.Parameters.AddWithValue("@aluno_id", aluno_id);
        cmd.Parameters.AddWithValue("@empresa_id", empresa_id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<AlunoEmpresa> alunosEmpresa = new List<AlunoEmpresa>();

        while(reader.Read())
        {
            AlunoEmpresa alunoEmpresa = new AlunoEmpresa();
            alunoEmpresa.AlunoId = reader.GetGuid(0);
            alunoEmpresa.EmpresaId = reader.GetGuid(1);
            alunoEmpresa.Status = reader.GetInt32(2);

            alunosEmpresa.Add(alunoEmpresa);
        }

        return alunosEmpresa;
    }


    public void Update(AlunoEmpresa alunoEmpresa, Guid aluno_id, Guid empresa_id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ALUNOS_EMPRESAS SET ALUNO_ID = @aluno_id, EMPRESA_ID = @empresa_id, STATUS = @status WHERE ALUNO_ID = @aluno_id and EMPRESA_ID = @empresa_id";

        cmd.Parameters.AddWithValue("@aluno_id", aluno_id);
        cmd.Parameters.AddWithValue("@empresa_id", empresa_id);
        cmd.Parameters.AddWithValue("@status", alunoEmpresa.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid aluno_id, Guid empresa_id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ALUNOS_EMPRESAS WHERE ALUNO_ID = @aluno_id and EMPRESA_ID = @empresa_id";

        cmd.Parameters.AddWithValue("@aluno_id", aluno_id);
        cmd.Parameters.AddWithValue("@empresa_id", empresa_id);
        cmd.ExecuteNonQuery();
    }
}