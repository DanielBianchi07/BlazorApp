using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class CadernoRespostaSqlRepository : DatabaseConnection, ICadernoRespostaSqlRepository
{
    public void Create(CadernoResposta cadernoResposta)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO CADERNOS_RESPOSTAS VALUES (@caderno_id, @nro_pergunta, @alt_selecionada, @pessoa_id)";

        cmd.Parameters.AddWithValue("@caderno_id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nro_pergunta", cadernoResposta.NroPergunta);
        cmd.Parameters.AddWithValue("@alt_selecionada", cadernoResposta.AltSelecionada);
        cmd.Parameters.AddWithValue("@pessoa_id", cadernoResposta.PessoaId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<CadernoResposta> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CADERNOS_RESPOSTAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<CadernoResposta> cadernoRespostas = new List<CadernoResposta>();

        while(reader.Read())
        {
            CadernoResposta cadernoResposta = new CadernoResposta();
            cadernoResposta.Id = reader.GetGuid(0);
            cadernoResposta.NroPergunta = reader.GetInt32(1);
            cadernoResposta.AltSelecionada = reader.GetString(2);
            cadernoResposta.PessoaId = reader.GetGuid(3);

            cadernoRespostas.Add(cadernoResposta);
        }

        return cadernoRespostas;
    }

    public CadernoResposta Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM CADERNOS_RESPOSTAS WHERE CADERNO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        CadernoResposta cadernoResposta = new CadernoResposta();

        while(reader.Read())
        {;
            cadernoResposta.Id = reader.GetGuid(0);
            cadernoResposta.NroPergunta = reader.GetInt32(1);
            cadernoResposta.AltSelecionada = reader.GetString(2);
            cadernoResposta.PessoaId = reader.GetGuid(3);
        }

        return cadernoResposta;
    }

    public void Update(CadernoResposta cadernoResposta, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE CADERNOS_RESPOSTAS SET CADERNO_ID = @caderno_id, NRO_PERGUNTA = @nro_pergunta, ALT_SELECIONADA = @alt_selecionada, PESSOA_ID = @pessoa_id";

        cmd.Parameters.AddWithValue("@caderno_id", cadernoResposta.Id);
        cmd.Parameters.AddWithValue("@nro_pergunta", cadernoResposta.NroPergunta);
        cmd.Parameters.AddWithValue("@alt_selecionada", cadernoResposta.AltSelecionada);
        cmd.Parameters.AddWithValue("@pessoa_id", cadernoResposta.PessoaId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM CADERNOS_RESPOSTAS WHERE CADERNO_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}