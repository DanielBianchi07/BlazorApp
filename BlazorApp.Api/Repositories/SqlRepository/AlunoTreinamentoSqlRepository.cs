using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class AlunoTreinamentoSqlRepository : DatabaseConnection, IAlunoTreinamentoSqlRepository
{
    public void Create(AlunoTreinamento alunoTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ALUNOS_TREINAMENTOS VALUES (@pessoa_id, @treinamento_id, @data_treinamento, @data_inicio_certificado, @resultado)";

        cmd.Parameters.AddWithValue("@pessoa_id", alunoTreinamento.PessoaId);
        cmd.Parameters.AddWithValue("@treinamento_id", alunoTreinamento.TreinamentoId);
        cmd.Parameters.AddWithValue("@data_treinamento", alunoTreinamento.DataTreinamento);
        cmd.Parameters.AddWithValue("@data_inicio_certificado", alunoTreinamento.DataInicioCertificado);
        cmd.Parameters.AddWithValue("@resultado", alunoTreinamento.Resultado);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<AlunoTreinamento> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALUNOS_TREINAMENTOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<AlunoTreinamento> alunosTreinamentos = new List<AlunoTreinamento>();

        while(reader.Read())
        {
            AlunoTreinamento alunoTreinamento = new AlunoTreinamento();
            alunoTreinamento.PessoaId = reader.GetGuid(0);
            alunoTreinamento.TreinamentoId = reader.GetGuid(1);
            alunoTreinamento.DataTreinamento = reader.GetDateTime(2);
            alunoTreinamento.DataInicioCertificado = reader.GetDateTime(3);
            alunoTreinamento.Resultado = reader.GetInt32(4);

            alunosTreinamentos.Add(alunoTreinamento);
        }

        return alunosTreinamentos;
    }

     public AlunoTreinamento Read(Guid idTreinamento, Guid idAluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ALUNOS_TREINAMENTOS WHERE TREINAMENTO_ID = @idTreinamento AND PESSOA_ID = @idAluno";

        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);
        cmd.Parameters.AddWithValue("@idAluno", idAluno);

        SqlDataReader reader = cmd.ExecuteReader();

        AlunoTreinamento alunoTreinamento = new AlunoTreinamento();

        while(reader.Read())
        {
            alunoTreinamento.PessoaId = reader.GetGuid(0);
            alunoTreinamento.TreinamentoId = reader.GetGuid(1);
            alunoTreinamento.DataTreinamento = reader.GetDateTime(2);
            alunoTreinamento.DataInicioCertificado = reader.GetDateTime(3);
            alunoTreinamento.Resultado = reader.GetInt32(4);
        }

        return alunoTreinamento;
    }

    public void Update(AlunoTreinamento alunoTreinamento, Guid idTreinamento, Guid idAluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ALUNOS_TREINAMENTOS SET PESSOA_ID = @pessoa_id, TREINAMENTO_ID = @treinamento_id, DATA_TREINAMENTO = @data_treinamento, DATA_INICIO_CERTIFICADO = @data_inicio_certificado, RESULTADO = @resultado WHERE TREINAMENTO_ID = @idTreinamento AND PESSOA_ID = idAluno";

        cmd.Parameters.AddWithValue("@pessoa_id", alunoTreinamento.PessoaId);
        cmd.Parameters.AddWithValue("@treinamento_id", alunoTreinamento.TreinamentoId);
        cmd.Parameters.AddWithValue("@data_treinamento", alunoTreinamento.DataTreinamento);
        cmd.Parameters.AddWithValue("@data_inicio_certificado", alunoTreinamento.DataInicioCertificado);
        cmd.Parameters.AddWithValue("@resultado", alunoTreinamento.Resultado);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idTreinamento, Guid idAluno)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ALUNOS_TREINAMENTOS WHERE TREINAMENTO_ID = @idTreinamento AND PESSOA_ID = @idAluno";

        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);
        cmd.Parameters.AddWithValue("@idAluno", idAluno);
        cmd.ExecuteNonQuery();
    }
}