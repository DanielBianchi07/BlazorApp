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
        cmd.CommandText = "INSERT INTO CIDADES VALUES (@idCidade, @nomeCidade, @idEstado)";

        cmd.Parameters.AddWithValue("@idCidade", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nomeCidade", cidade.Nome);
        cmd.Parameters.AddWithValue("@idEstado", cidade.EstadoId);

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
        cmd.CommandText = "SELECT * FROM CIDADES WHERE ID_CIDADE = @idCidade";

        cmd.Parameters.AddWithValue("@idCidade", id);

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
        cmd.CommandText = "UPDATE CIDADES SET NOME_CIDADE = @nomeCidade WHERE ID_CIDADE = @idCidade";

        cmd.Parameters.AddWithValue("@idCidade", id);
        cmd.Parameters.AddWithValue("@nomeCidade", cidade.Nome);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CIDADES WHERE ID_CIDADE = @idCidade";

        cmd.Parameters.AddWithValue("@idCidade", id);
        cmd.ExecuteNonQuery();
    }
}