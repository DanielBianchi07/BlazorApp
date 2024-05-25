using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class ListaPresencaSqlRepository : DatabaseConnection, IListaPresencaSqlRepository
{
    public void Create(ListaPresenca listaPresenca)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO LISTAS_PRESENCAS VALUES (@idTreinamento, @codigo, @data)";

        cmd.Parameters.AddWithValue("@idTreinamento", listaPresenca.TreinamentoId);
        cmd.Parameters.AddWithValue("@codigo", listaPresenca.Codigo);
        cmd.Parameters.AddWithValue("@data", listaPresenca.DataEmissao);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<ListaPresenca> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM LISTAS_PRESENCAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<ListaPresenca> listaPresencas = new List<ListaPresenca>();

        while(reader.Read())
        {
            ListaPresenca listaPresenca = new ListaPresenca();
            listaPresenca.TreinamentoId = reader.GetGuid(0);
            listaPresenca.Codigo = reader.GetString(1);
            listaPresenca.DataEmissao = reader.GetDateTime(2);

            listaPresencas.Add(listaPresenca);
        }

        return listaPresencas;
    }

    public ListaPresenca Read(Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM LISTAS_PRESENCAS WHERE ID_TREINAMENTO = @idTreinamento";

        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);

        SqlDataReader reader = cmd.ExecuteReader();

        ListaPresenca listaPresenca = new ListaPresenca();

        while(reader.Read())
        {
            listaPresenca.TreinamentoId = reader.GetGuid(0);
            listaPresenca.Codigo = reader.GetString(1);
            listaPresenca.DataEmissao = reader.GetDateTime(2);

        }

        return listaPresenca;
    }

    public void Update(ListaPresenca listaPresenca, Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE LISTAS_PRESENCAS SET CODIGO = @codigo, DATA = @data WHERE ID_TREINAMENTO = @idTreinamento";

        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);
        cmd.Parameters.AddWithValue("@codigo", listaPresenca.Codigo);
        cmd.Parameters.AddWithValue("@data", listaPresenca.DataEmissao);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idTreinamento)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM LISTAS_PRESENCAS WHERE ID_TREINAMENTO = @idTreinamento";

        cmd.Parameters.AddWithValue("@idTreinamento", idTreinamento);
        cmd.ExecuteNonQuery();
    }
}