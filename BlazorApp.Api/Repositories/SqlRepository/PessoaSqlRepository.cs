using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class PessoaSqlRepository : DatabaseConnection, IPessoaRepository
{
    public void Create(Pessoa pessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO PESSOAS VALUES (@id, @nome, @email)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
        cmd.Parameters.AddWithValue("@email", pessoa.Email);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Pessoa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM PESSOAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Pessoa> pessoas = new List<Pessoa>();

        while(reader.Read())
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Id = reader.GetGuid(0);
            pessoa.Nome = reader.GetString(1);
            pessoa.Email = reader.GetString(2);
            pessoas.Add(pessoa);
        }

        return pessoas;
    }

    public void Update(Pessoa pessoa, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE PESSOAS SET NOME = @nome, EMAIL = @email WHERE ID_PESSOA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
        cmd.Parameters.AddWithValue("@email", pessoa.Email);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM PESSOAS WHERE ID_PESSOA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}