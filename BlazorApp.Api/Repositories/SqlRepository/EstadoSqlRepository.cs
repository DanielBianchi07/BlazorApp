using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class EstadoSqlRepository : DatabaseConnection, IEstadoSqlRepository
{
    public void Create(Estado estado)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ESTADOS VALUES (@id_estado, @nome_estado, @uf)";

        cmd.Parameters.AddWithValue("@id_estado", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nome_estado", estado.Nome);
        cmd.Parameters.AddWithValue("@uf", estado.UF);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Estado> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ESTADOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Estado> estados = new List<Estado>();

        while(reader.Read())
        {
            Estado estado = new Estado();
            estado.Id = reader.GetGuid(0);
            estado.Nome = reader.GetString(1);
            estado.UF = reader.GetString(2);

            estados.Add(estado);
        }

        return estados;
    }

    public IEnumerable<Estado> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ESTADOS WHERE ID_ESTADO = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<Estado> estados = new List<Estado>();

        while(reader.Read())
        {
            Estado estado = new Estado();
            estado.Id = reader.GetGuid(0);
            estado.Nome = reader.GetString(1);
            estado.UF = reader.GetString(2);

            estados.Add(estado);
        }

        return estados;
    }

    public void Update(Estado estado, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ESTADOS SET ID_ESTADO = @id_estado, NOME_ESTADO = @nome_estado, UF = @uf";

        cmd.Parameters.AddWithValue("@id_estado", estado.Id);
        cmd.Parameters.AddWithValue("@nome_estado", estado.Nome);
        cmd.Parameters.AddWithValue("@uf", estado.UF);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ESTADOS WHERE ID_ESTADO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}