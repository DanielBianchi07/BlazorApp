using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;

// Model = Aluno
// variavel do model = aluno
// variavel no plural = alunos


public class AlunoSqlRepository : DatabaseConnection, IAlunoRepository
{
    public void Create(Aluno aluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ALUNOS VALUES (@pessoa_id, @cpf, @rg, @assinatura, @usuario_id)";

        cmd.Parameters.AddWithValue("@pessoa_id", aluno.PessoaId);
        cmd.Parameters.AddWithValue("@cnpj", aluno.CPF);
        cmd.Parameters.AddWithValue("@razao_social", aluno.RG);
        cmd.Parameters.AddWithValue("@email", aluno.Assinatura);
        cmd.Parameters.AddWithValue("@status", aluno.UsuarioId);

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
            aluno.UsuarioId = reader.GetGuid(4);

            alunos.Add(aluno);
        }

        return alunos;
    }

    public void Update(Aluno aluno, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ALUNOS SET PESSOA_ID = @pessoa_id, CPF = @cpf, RG = @rg, ASSINATURA = @assinatura, USUARIO_ID = @usuario_id WHERE PESSOA_ID = @pessoa_id";

        cmd.Parameters.AddWithValue("@pessoa_id", id);
        cmd.Parameters.AddWithValue("@cpf", aluno.CPF);
        cmd.Parameters.AddWithValue("@rg", aluno.RG);
        cmd.Parameters.AddWithValue("@assinatura", aluno.Assinatura);
        cmd.Parameters.AddWithValue("@usuario_id", aluno.UsuarioId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM PESSOAS WHERE ID_PESSOA = @pessoa_id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}