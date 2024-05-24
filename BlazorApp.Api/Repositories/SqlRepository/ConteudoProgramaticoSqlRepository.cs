using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class ConteudoProgramaticoSqlRepository : DatabaseConnection, IConteudoProgramaticoSqlRepository
{
    public void Create(ConteudoProgramatico conteudoProgramatico)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CONTEUDOS_PROGRAMATICOS VALUES (@id_conteudo, @assunto, @carga_horaria, @status)";

        cmd.Parameters.AddWithValue("@id_conteudo", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@assunto", conteudoProgramatico.Assunto);
        cmd.Parameters.AddWithValue("@carga_horaria", conteudoProgramatico.CargaHoraria);
        cmd.Parameters.AddWithValue("@status", conteudoProgramatico.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<ConteudoProgramatico> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CONTEUDOS_PROGRAMATICOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<ConteudoProgramatico> conteudoProgramaticos = new List<ConteudoProgramatico>();

        while(reader.Read())
        {
            ConteudoProgramatico conteudoProgramatico = new ConteudoProgramatico();
            conteudoProgramatico.Id = reader.GetGuid(0);
            conteudoProgramatico.Assunto = reader.GetString(1);
            conteudoProgramatico.CargaHoraria = reader.GetInt32(2);
            conteudoProgramatico.Status = reader.GetInt32(4);

            conteudoProgramaticos.Add(conteudoProgramatico);
        }

        return conteudoProgramaticos;
    }

    public IEnumerable<ConteudoProgramatico> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CONTEUDOS_PROGRAMATICOS WHERE ID_CONTEUDO = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<ConteudoProgramatico> conteudoProgramaticos = new List<ConteudoProgramatico>();

        while(reader.Read())
        {
            ConteudoProgramatico conteudoProgramatico = new ConteudoProgramatico();
            conteudoProgramatico.Id = reader.GetGuid(0);
            conteudoProgramatico.Assunto = reader.GetString(1);
            conteudoProgramatico.CargaHoraria = reader.GetInt32(2);
            conteudoProgramatico.Status = reader.GetInt32(4);

            conteudoProgramaticos.Add(conteudoProgramatico);
        }

        return conteudoProgramaticos;
    }

    public void Update(ConteudoProgramatico conteudoProgramatico, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CONTEUDOS_PROGRAMATICOS SET ASSUNTO = @assunto, CARGA_HORARIA = @cargaHoraria, STATUS = @status WHERE ID_CONTEUDO = @idConteudo";

        cmd.Parameters.AddWithValue("@idConteudo", id);
        cmd.Parameters.AddWithValue("@assunto", conteudoProgramatico.Assunto);
        cmd.Parameters.AddWithValue("@cargaHoraria", conteudoProgramatico.CargaHoraria);
        cmd.Parameters.AddWithValue("@status", conteudoProgramatico.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CONTEUDOS_PROGRAMATICOS WHERE ID_CONTEUDO = @idConteudo";

        cmd.Parameters.AddWithValue("@idConteudo", id);
        cmd.ExecuteNonQuery();
    }
}