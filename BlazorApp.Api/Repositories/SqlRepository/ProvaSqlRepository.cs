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
        cmd.CommandText = "INSERT INTO PROVAS VALUES (@id_prova, @data_prova, @pessoa_id)";

        cmd.Parameters.AddWithValue("@id_prova", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@data_prova", prova.DataRealizacao);
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
            prova.PessoaId = reader.GetGuid(2);

            provas.Add(prova);
        }

        return provas;
    }

    public void Update(Prova prova, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE PROVAS SET ID_PROVA = @id_prova, DATA_PROVA = @data_prova, PESSOA_ID = pessoa_id";

        cmd.Parameters.AddWithValue("@id_prova", prova.Id);
        cmd.Parameters.AddWithValue("@data_prova", prova.DataRealizacao);
        cmd.Parameters.AddWithValue("@pessoa_id", prova.PessoaId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM PROVAS WHERE ID_PROVA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}