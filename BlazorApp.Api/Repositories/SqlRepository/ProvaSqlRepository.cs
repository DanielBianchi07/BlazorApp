using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class ProvaSqlRepository : DatabaseConnection, IProvaSqlRepository
{
    public void Create(Prova prova)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO PROVAS VALUES (@id_prova, @data_prova, @status, @pessoa_id)";

        cmd.Parameters.AddWithValue("@id_prova", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@data_prova", prova.DataRealizacao);
        cmd.Parameters.AddWithValue("@status", prova.Status);
        cmd.Parameters.AddWithValue("@pessoa_id", prova.PessoaId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Prova> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM PROVAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Prova> provas = new List<Prova>();

        while(reader.Read())
        {
            Prova prova = new Prova();
            prova.Id = reader.GetGuid(0);
            prova.DataRealizacao = reader.GetDateTime(1);
            prova.Status = reader.GetInt32(2);
            prova.PessoaId = reader.GetGuid(3);

            provas.Add(prova);
        }

        return provas;
    }

    public Prova Read(Guid idProva, Guid idPessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM PROVAS WHERE ID_PROVA = @idProva AND PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idProva", idProva);
        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);

        SqlDataReader reader = cmd.ExecuteReader();

        Prova prova = new Prova();

        while(reader.Read())
        {
            prova.Id = reader.GetGuid(0);
            prova.DataRealizacao = reader.GetDateTime(1);
            prova.Status = reader.GetInt32(2);
            prova.PessoaId = reader.GetGuid(3);
        }

        return prova;
    }

    public void Update(Prova prova, Guid idProva, Guid idPessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE PROVAS SET DATA_PROVA = @dataProva, STATUS = @status WHERE ID_PROVA = @idProva AND PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idProva", idProva);
        cmd.Parameters.AddWithValue("@dataProva", prova.DataRealizacao);
        cmd.Parameters.AddWithValue("@status", prova.Status);
        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idProva, Guid idPessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM PROVAS WHERE ID_PROVA = @idProva AND PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idProva", idProva);
        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
        cmd.ExecuteNonQuery();
    }
}