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
        cmd.CommandText = "INSERT INTO LISTAS_PRESENCAS VALUES (@id_treinamento, @codigo, @data)";

        cmd.Parameters.AddWithValue("@id_treinamento", listaPresenca.TreinamentoId);
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

    public void Update(ListaPresenca listaPresenca, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE LISTAS_PRESENCAS SET ID_TREINAMENTO = @id_treinamento, CODIGO = @codigo, DATA = @data";

        cmd.Parameters.AddWithValue("@id_treinamento", listaPresenca.TreinamentoId);
        cmd.Parameters.AddWithValue("@codigo", listaPresenca.Codigo);
        cmd.Parameters.AddWithValue("@data", listaPresenca.DataEmissao);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM LISTAS_PRESENCAS WHERE ID_TREINAMENTO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}