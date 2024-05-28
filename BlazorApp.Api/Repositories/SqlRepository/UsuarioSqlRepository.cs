using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class UsuarioSqlRepository : DatabaseConnection, IUsuarioSqlRepository
{
    private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
    public void Create(Usuario usuario)
    {
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        // Gera o hash da senha usando PBKDF2 com SHA256
        var pbkdf2 = new Rfc2898DeriveBytes(usuario.Senha, salt, 10000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        // Combina o salt e o hash em um único array para facilitar o armazenamento
        byte[] hashBytes = new byte[48];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 32);
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO USUARIOS VALUES (@pessoaId, @nomeUsuario, @senha, @status)";

        cmd.Parameters.AddWithValue("@pessoaId", usuario.PessoaId);
        cmd.Parameters.AddWithValue("@nomeUsuario", usuario.Nome);
        cmd.Parameters.AddWithValue("@senha", Convert.ToBase64String(hashBytes));
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

    public Usuario Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM USUARIOS WHERE PESSOA_ID = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        Usuario usuario = new Usuario();

        while(reader.Read())
        {
            usuario.PessoaId = reader.GetGuid(0);
            usuario.Nome = reader.GetString(1);
            usuario.Senha = reader.GetString(2);
            usuario.Status = reader.GetInt32(3);
        }

        return usuario;
    }
    
    public Usuario ReadNomeSenha(string nome, string senha)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM USUARIOS WHERE NOME_USUARIO = @nome";
        cmd.Parameters.AddWithValue("@nome", nome);
    
        SqlDataReader reader = cmd.ExecuteReader();
    
        Usuario usuario = null;
    
        if (reader.Read())
        {
            usuario = new Usuario
            {
                PessoaId = reader.GetGuid(0),
                Nome = reader.GetString(1),
                Senha = reader.GetString(2),
                Status = reader.GetInt32(3)
            };
        }
    
        reader.Close();
    
        if (usuario == null)
        {
            return null; // Usuário não encontrado
        }
    
        // Converte a string base64 de volta para um array de bytes
        byte[] hashBytes = Convert.FromBase64String(usuario.Senha);
    
        // Extrai o salt (primeiros 16 bytes)
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
    
        // Gera o hash da senha fornecida usando o salt extraído
        var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);
    
        // Compara o hash gerado com o hash armazenado (os últimos 32 bytes)
        for (int i = 0; i < 32; i++)
        {
            if (hashBytes[i + 16] != hash[i])
            {
                return null; // Senha incorreta
            }
        }
    
        return usuario; // Senha correta
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