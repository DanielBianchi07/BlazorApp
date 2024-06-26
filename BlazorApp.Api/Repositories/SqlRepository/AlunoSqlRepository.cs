using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class AlunoSqlRepository : DatabaseConnection, IAlunoSqlRepository
{
    public void Create(Aluno aluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ALUNOS VALUES (@pessoa_id, @cpf, @rg, @assinatura, @status, @usuario_id)";

        cmd.Parameters.AddWithValue("@pessoa_id", aluno.PessoaId);
        cmd.Parameters.AddWithValue("@cpf", aluno.CPF);
        cmd.Parameters.AddWithValue("@rg", aluno.RG);
        cmd.Parameters.AddWithValue("@assinatura", aluno.Assinatura);
        cmd.Parameters.AddWithValue("@status", aluno.Status);
        cmd.Parameters.AddWithValue("@usuario_id", aluno.UsuarioId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Aluno> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALUNOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Aluno> alunos = new List<Aluno>();

        while(reader.Read())
        {
            Aluno aluno = new Aluno();
            aluno.PessoaId = reader.GetGuid(0);
            aluno.CPF = reader.GetString(1);
            aluno.RG = reader.GetString(2);
            aluno.Assinatura = reader.GetString(3);
            aluno.Status = reader.GetInt32(4);
            aluno.UsuarioId = reader.GetGuid(5);

            alunos.Add(aluno);
        }

        return alunos;
    }

    public Aluno Read(Guid idPessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALUNOS WHERE PESSOA_ID = @pessoa_id";

        cmd.Parameters.AddWithValue("@pessoa_id", idPessoa);

        SqlDataReader reader = cmd.ExecuteReader();

        Aluno aluno = new Aluno();

        while(reader.Read())
        {
            aluno.PessoaId = reader.GetGuid(0);
            aluno.CPF = reader.GetString(1);
            aluno.RG = reader.GetString(2);
            aluno.Assinatura = reader.GetString(3);
            aluno.Status = reader.GetInt32(4);
            aluno.UsuarioId = reader.GetGuid(5);

        }

        return aluno;
    }

    public void Update(Aluno aluno, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ALUNOS SET PESSOA_ID = @pessoa_id, CPF = @cpf, RG = @rg, ASSINATURA = @assinatura, STATUS = @status, USUARIO_ID = @usuario_id WHERE PESSOA_ID = @pessoa_id";

        cmd.Parameters.AddWithValue("@pessoa_id", id);
        cmd.Parameters.AddWithValue("@cpf", aluno.CPF);
        cmd.Parameters.AddWithValue("@rg", aluno.RG);
        cmd.Parameters.AddWithValue("@assinatura", aluno.Assinatura);
        cmd.Parameters.AddWithValue("@status", aluno.Status);
        cmd.Parameters.AddWithValue("@usuario_id", aluno.UsuarioId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ALUNOS WHERE ID_PESSOA = @pessoa_id";

        cmd.Parameters.AddWithValue("@pessoa_id", id);
        cmd.ExecuteNonQuery();
    }
}