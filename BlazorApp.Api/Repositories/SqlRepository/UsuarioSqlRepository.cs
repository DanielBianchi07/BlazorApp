using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class UsuarioSqlRepository : DatabaseConnection, IUsuarioSqlRepository
{
    public void Create(Usuario usuario)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO USUARIOS VALUES (@pessoaId, @nomeUsuario, @senha, @status)";

        cmd.Parameters.AddWithValue("@pessoaId", usuario.PessoaId);
        cmd.Parameters.AddWithValue("@nomeUsuario", usuario.Nome);
        cmd.Parameters.AddWithValue("@senha", usuario.Senha);
        cmd.Parameters.AddWithValue("@status", usuario.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Usuario> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM USUARIOS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Usuario> usuarios = new List<Usuario>();

        while(reader.Read())
        {
            Usuario usuario = new Usuario();
            usuario.PessoaId = reader.GetGuid(0);
            usuario.Nome = reader.GetString(1);
            usuario.Senha = reader.GetString(2);
            usuario.Status = reader.GetInt32(3);

            usuarios.Add(usuario);
        }

        return usuarios;
    }

    public IEnumerable<Usuario> Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM USUARIOS WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        List<Usuario> usuarios = new List<Usuario>();

        while(reader.Read())
        {
            Usuario usuario = new Usuario();
            usuario.PessoaId = reader.GetGuid(0);
            usuario.Nome = reader.GetString(1);
            usuario.Senha = reader.GetString(2);
            usuario.Status = reader.GetInt32(3);

            usuarios.Add(usuario);
        }

        return usuarios;
    }

    public void Update(Usuario usuario, Guid idPessoa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE USUARIOS SET NOME_USUARIO = @nomeUsuario, SENHA = @senha, STATUS = @status WHERE PESSOA_ID = @pessoa_id";

        cmd.Parameters.AddWithValue("@pessoa_id", idPessoa);
        cmd.Parameters.AddWithValue("@nomeUsuario", usuario.Nome);
        cmd.Parameters.AddWithValue("@senha", usuario.Senha);
        cmd.Parameters.AddWithValue("@status", usuario.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM USUARIOS WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}