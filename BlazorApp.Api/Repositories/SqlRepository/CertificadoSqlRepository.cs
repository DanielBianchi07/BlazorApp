using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class CertificadoSqlRepository : DatabaseConnection, ICertificadoSqlRepository
{
    public void Create(Certificado certificado)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CERTIFICADOS VALUES (@treinamento_id, @codigo, @data_emissao, @status)";

        cmd.Parameters.AddWithValue("@treinamento_id", certificado.TreinamentoId);
        cmd.Parameters.AddWithValue("@codigo", certificado.Codigo);
        cmd.Parameters.AddWithValue("@data_emissao", certificado.DataEmissao);
        cmd.Parameters.AddWithValue("@status", certificado.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Certificado> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CERTIFICADOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Certificado> certificados = new List<Certificado>();

        while(reader.Read())
        {
            Certificado certificado = new Certificado();
            certificado.TreinamentoId = reader.GetGuid(0);
            certificado.Codigo = reader.GetString(1);
            certificado.DataEmissao = reader.GetDateTime(2);
            certificado.Status = reader.GetInt32(3);

            certificados.Add(certificado);
        }

        return certificados;
    }

    public void Update(Certificado certificado, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CERTIFICADOS SET TREINAMENTO_ID = @treinamento_id, CODIGO = @codigo, DATA_EMISSAO = @data_emissao, STATUS = @status";

        cmd.Parameters.AddWithValue("@treinamento_id", certificado.TreinamentoId);
        cmd.Parameters.AddWithValue("@codigo", certificado.Codigo);
        cmd.Parameters.AddWithValue("@data_emissao", certificado.DataEmissao);
        cmd.Parameters.AddWithValue("@status", certificado.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CERTIFICADOS WHERE TREINAMENTO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}