using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class CidadeSqlRepository : DatabaseConnection, ICidadeSqlRepository
{
    public void Create(Cidade cidade)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CIDADES VALUES (@id_cidade, @nome_cidade, @estado_id)";

        cmd.Parameters.AddWithValue("@id_cidade", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nome_cidade", cidade.Nome);
        cmd.Parameters.AddWithValue("@estado_id", cidade.EstadoId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Cidade> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CIDADES";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Cidade> cidades = new List<Cidade>();

        while(reader.Read())
        {
            Cidade cidade = new Cidade();
            cidade.Id = reader.GetGuid(0);
            cidade.Nome = reader.GetString(1);
            cidade.EstadoId = reader.GetGuid(2);

            cidades.Add(cidade);
        }

        return cidades;
    }

    public IEnumerable<Cidade> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CIDADES WHERE ID_CIDADE = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<Cidade> cidades = new List<Cidade>();

        while(reader.Read())
        {
            Cidade cidade = new Cidade();
            cidade.Id = reader.GetGuid(0);
            cidade.Nome = reader.GetString(1);
            cidade.EstadoId = reader.GetGuid(2);

            cidades.Add(cidade);
        }

        return cidades;
    }

    public void Update(Cidade cidade, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CIDADES SET ID_CIDADE = @id_cidade, NOME_CIDADE = @nome_cidade, ESTADO_ID = @estado_id";

        cmd.Parameters.AddWithValue("@id_cidade", cidade.Id);
        cmd.Parameters.AddWithValue("@nome_cidade", cidade.Nome);
        cmd.Parameters.AddWithValue("@estado_id", cidade.EstadoId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CIDADES WHERE ID_CIDADE = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}