using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class EnderecoEmpresaSqlRepository : DatabaseConnection, IEnderecoEmpresaSqlRepository
{
    public void Create(EnderecoEmpresa enderecoEmpresa)
    {
        enderecoEmpresa.Id = Guid.NewGuid();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ENDERECOS_EMPRESAS VALUES (@idEndereco, @cep, @estado, @cidade, @bairro, @nomeRua, @numero, @complemento, @status, @idEmpresa)";

        cmd.Parameters.AddWithValue("@idEndereco", enderecoEmpresa.Id);
        cmd.Parameters.AddWithValue("@CEP", enderecoEmpresa.CEP);
        cmd.Parameters.AddWithValue("@estado", enderecoEmpresa.Estado);
        cmd.Parameters.AddWithValue("@cidade", enderecoEmpresa.Cidade);
        cmd.Parameters.AddWithValue("@bairro", enderecoEmpresa.Bairro);
        cmd.Parameters.AddWithValue("@nomeRua", enderecoEmpresa.NomeRua);
        cmd.Parameters.AddWithValue("@numero", enderecoEmpresa.Numero);
        cmd.Parameters.AddWithValue("@complemento", enderecoEmpresa.Complemento);
        cmd.Parameters.AddWithValue("@status", enderecoEmpresa.Status);
        cmd.Parameters.AddWithValue("@idEmpresa", enderecoEmpresa.EmpresaId);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<EnderecoEmpresa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ENDERECOS_EMPRESAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<EnderecoEmpresa> enderecoEmpresas = new List<EnderecoEmpresa>();

        while(reader.Read())
        {
            EnderecoEmpresa enderecoEmpresa = new EnderecoEmpresa();
            enderecoEmpresa.Id = reader.GetGuid(0);
            enderecoEmpresa.CEP = reader.GetString(1);
            enderecoEmpresa.Estado = reader.GetString(2);
            enderecoEmpresa.Cidade = reader.GetString(3);
            enderecoEmpresa.Bairro = reader.GetString(4);
            enderecoEmpresa.NomeRua = reader.GetString(5);
            enderecoEmpresa.Numero = reader.GetString(6);
            enderecoEmpresa.Complemento = reader.IsDBNull(7) ? null : reader.GetString(5);
            enderecoEmpresa.Status = reader.GetInt32(8);
            enderecoEmpresa.EmpresaId = reader.GetGuid(9);

            enderecoEmpresas.Add(enderecoEmpresa);
        }

        return enderecoEmpresas;
    }

    public EnderecoEmpresa Read(Guid idEmpresa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ENDERECOS_EMPRESAS WHERE EMPRESA_ID = @idEmpresa";

        cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

        SqlDataReader reader = cmd.ExecuteReader();

        EnderecoEmpresa enderecoEmpresa = new EnderecoEmpresa();

        while(reader.Read())
        {
            enderecoEmpresa.Id = reader.GetGuid(0);
            enderecoEmpresa.CEP = reader.GetString(1);
            enderecoEmpresa.Estado = reader.GetString(2);
            enderecoEmpresa.Cidade = reader.GetString(3);
            enderecoEmpresa.Bairro = reader.GetString(4);
            enderecoEmpresa.NomeRua = reader.GetString(5);
            enderecoEmpresa.Numero = reader.GetString(6);
            enderecoEmpresa.Complemento = reader.IsDBNull(7) ? null : reader.GetString(5);
            enderecoEmpresa.Status = reader.GetInt32(8);
            enderecoEmpresa.EmpresaId = reader.GetGuid(9);
        }

        return enderecoEmpresa;
    }

    public void Update(EnderecoEmpresa enderecoEmpresa, Guid idEndereco)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ENDERECOS_EMPRESAS SET CEP = @CEP, ESTADO = @estado, CIDADE = @cidade, BAIRRO = @bairro, NOME_RUA = @nomeRua, NUMERO = @numero, COMPLEMENTO = @complemento, STATUS = @status WHERE ID_ENDERECO = @idEndereco";

        cmd.Parameters.AddWithValue("@idEndereco", enderecoEmpresa.Id);
        cmd.Parameters.AddWithValue("@CEP", enderecoEmpresa.CEP);
        cmd.Parameters.AddWithValue("@estado", enderecoEmpresa.Estado);
        cmd.Parameters.AddWithValue("@cidade", enderecoEmpresa.Cidade);
        cmd.Parameters.AddWithValue("@bairro", enderecoEmpresa.Bairro);
        cmd.Parameters.AddWithValue("@nomeRua", enderecoEmpresa.NomeRua);
        cmd.Parameters.AddWithValue("@numero", enderecoEmpresa.Numero);
        cmd.Parameters.AddWithValue("@complemento", enderecoEmpresa.Complemento);
        cmd.Parameters.AddWithValue("@status", enderecoEmpresa.Status);
        cmd.Parameters.AddWithValue("@idEmpresa", enderecoEmpresa.EmpresaId);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM ENDERECOS_EMPRESAS WHERE ID_ENDERECO = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}