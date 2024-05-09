using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TelefonePessoaSqlRepository : DatabaseConnection, ITelefonePessoaSqlRepository
{
    public void Create(TelefonePessoa telefonePessoa, Guid idPessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TELEFONES_PESSOAS VALUES (@id_telefone_pes, @pessoa_id, @nro_telefone)";

        cmd.Parameters.AddWithValue("@id_telefone_pes", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@pessoa_id", idPessoa);
        cmd.Parameters.AddWithValue("@nro_telefone", telefonePessoa.NroTelefone);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<TelefonePessoa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TELEFONES_PESSOAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<TelefonePessoa> telefonePessoas = new List<TelefonePessoa>();

        while(reader.Read())
        {
            TelefonePessoa telefonePessoa = new TelefonePessoa();
            telefonePessoa.Id = reader.GetGuid(0);
            telefonePessoa.PessoaId = reader.GetGuid(1);
            telefonePessoa.NroTelefone = reader.GetString(2);

            telefonePessoas.Add(telefonePessoa);
        }

        return telefonePessoas;
    }

    public void Update(TelefonePessoa telefonePessoa, Guid idPessoa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE TELEFONES_PESSOAS SET ID_TELEFONE_PES = @id_telefone_pes, PESSOA_ID = @pessoa_id, NRO_TELEFONE = @nro_telefone";

        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
        cmd.Parameters.AddWithValue("@nro_telefone", telefonePessoa.NroTelefone);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idPessoa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM TELEFONES_PESSOAS WHERE ID_TELEFONE_PES = @idTelefone AND PESSOA_ID = @idPessoa";

        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.ExecuteNonQuery();
    }
}