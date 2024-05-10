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

    public void Update(AlunoTreinamento alunoTreinamento, Guid idAluno, Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ALUNOS_TREINAMENTOS SET DATA_TREINAMENTO = @data_treinamento, DATA_INICIO_CERTIFICADO = @data_inicio_certificado, RESULTADO = @resultado WHERE PESSOA_ID = @idAluno and TREINAMENTO_ID = @idTreinamento";

        cmd.Parameters.AddWithValue("@idAluno", idAluno);
        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);
        cmd.Parameters.AddWithValue("@data_treinamento", alunoTreinamento.DataTreinamento);
        cmd.Parameters.AddWithValue("@data_inicio_certificado", alunoTreinamento.DataInicioCertificado);
        cmd.Parameters.AddWithValue("@resultado", alunoTreinamento.Resultado);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ALUNOS_TREINAMENTOS WHERE TREINAMENTO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}