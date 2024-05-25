using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TelefonePessoaSqlRepository : DatabaseConnection, ITelefonePessoaSqlRepository
{
    public void Create(TelefonePessoa telefonePessoa)
    {
        telefonePessoa.Id = Guid.NewGuid();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TELEFONES_PESSOAS VALUES (@id_telefone_pes, @pessoa_id, @nro_telefone, @status)";

        cmd.Parameters.AddWithValue("@id_telefone_pes", telefonePessoa.Id);
        cmd.Parameters.AddWithValue("@pessoa_id", telefonePessoa.PessoaId);
        cmd.Parameters.AddWithValue("@nro_telefone", telefonePessoa.NroTelefone);
        cmd.Parameters.AddWithValue("@status", telefonePessoa.Status);

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
            telefonePessoa.Status = reader.GetInt32(3);

            telefonePessoas.Add(telefonePessoa);
        }

        return telefonePessoas;
    }

    public TelefonePessoa Read(Guid idPessoa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TELEFONES_PESSOAS WHERE PESSOA_ID = @idPessoa AND ID_TELEFONE_PES = @idTelefone";

        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);

        SqlDataReader reader = cmd.ExecuteReader();

        TelefonePessoa telefonePessoa = new TelefonePessoa();

        while(reader.Read())
        {
            telefonePessoa.Id = reader.GetGuid(0);
            telefonePessoa.PessoaId = reader.GetGuid(1);
            telefonePessoa.NroTelefone = reader.GetString(2);
            telefonePessoa.Status = reader.GetInt32(3);
        }

        return telefonePessoa;
    }

    public void Update(TelefonePessoa telefonePessoa, Guid idPessoa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE TELEFONES_PESSOAS SET NRO_TELEFONE = @nro_telefone, STATUS = @status WHERE ID_TELEFONE_PES = @idTelefone AND  PESSOA_ID = @pessoa_id";

        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.Parameters.AddWithValue("@pessoa_id", idPessoa);
        cmd.Parameters.AddWithValue("@nro_telefone", telefonePessoa.NroTelefone);
        cmd.Parameters.AddWithValue("@status", telefonePessoa.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idPessoa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM TELEFONES_PESSOAS WHERE PESSOA_ID = @idPessoa AND ID_TELEFONE_PES = @idTelefone";

        cmd.Parameters.AddWithValue("@idPessoa", idPessoa);
        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.ExecuteNonQuery();
    }
}