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
        cmd.CommandText = "INSERT INTO ESTADOS VALUES (@idEstado, @nomeEstado, @uf)";

        cmd.Parameters.AddWithValue("@idEstado", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
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

    public IEnumerable<Estado> Read(Guid idEstado)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ESTADOS WHERE ID_ESTADO = @idEstado";

        cmd.Parameters.AddWithValue("@idEstado", idEstado);

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

    public void Update(Estado estado, Guid idEstado)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ESTADOS SET NOME_ESTADO = @nomeEstado, UF = @uf WHERE ID_ESTADO = @idEstado";

        cmd.Parameters.AddWithValue("@idEstado", idEstado);
        cmd.Parameters.AddWithValue("@nomeEstado", estado.Nome);
        cmd.Parameters.AddWithValue("@uf", estado.UF);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idEstado)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ESTADOS WHERE ID_ESTADO = @idEstado";

        cmd.Parameters.AddWithValue("@idEstado", idEstado);
        cmd.ExecuteNonQuery();
    }
}