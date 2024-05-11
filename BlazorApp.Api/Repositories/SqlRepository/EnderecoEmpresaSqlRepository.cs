using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class EnderecoEmpresaSqlRepository : DatabaseConnection, IEnderecoEmpresaSqlRepository
{
    public void Create(EnderecoEmpresa enderecoEmpresa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO ENDERECOS_EMPRESAS VALUES (@idEndereco, @cep, @nomeRua, @numero, @bairro, @complemento, @idCidade, @idEmpresa)";

        cmd.Parameters.AddWithValue("@idEndereco", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@CEP", enderecoEmpresa.CEP);
        cmd.Parameters.AddWithValue("@nomeRua", enderecoEmpresa.NomeRua);
        cmd.Parameters.AddWithValue("@numero", enderecoEmpresa.Numero);
        cmd.Parameters.AddWithValue("@bairro", enderecoEmpresa.Bairro);
        cmd.Parameters.AddWithValue("@complemento", enderecoEmpresa.Complemento);
        cmd.Parameters.AddWithValue("@idCidade", enderecoEmpresa.CidadeId);
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
            enderecoEmpresa.NomeRua = reader.GetString(2);
            enderecoEmpresa.Numero = reader.GetInt32(3);
            enderecoEmpresa.Bairro = reader.GetString(4);
            enderecoEmpresa.Complemento = reader.IsDBNull(5) ? null : reader.GetString(5);
            enderecoEmpresa.CidadeId = reader.GetGuid(6);
            enderecoEmpresa.EmpresaId = reader.GetGuid(7);

            enderecoEmpresas.Add(enderecoEmpresa);
        }

        return enderecoEmpresas;
    }

    public IEnumerable<EnderecoEmpresa> Read(Guid idEndereco)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM ENDERECOS_EMPRESAS WHERE ID_ENDERECO = @idEndereco";

        cmd.Parameters.AddWithValue("@idEndereco", idEndereco);

        SqlDataReader reader = cmd.ExecuteReader();

        List<EnderecoEmpresa> enderecoEmpresas = new List<EnderecoEmpresa>();

        while(reader.Read())
        {
            EnderecoEmpresa enderecoEmpresa = new EnderecoEmpresa();
            enderecoEmpresa.Id = reader.GetGuid(0);
            enderecoEmpresa.CEP = reader.GetString(1);
            enderecoEmpresa.NomeRua = reader.GetString(2);
            enderecoEmpresa.Numero = reader.GetInt32(3);
            enderecoEmpresa.Bairro = reader.GetString(4);
            enderecoEmpresa.Complemento = reader.IsDBNull(5) ? null : reader.GetString(5);
            enderecoEmpresa.CidadeId = reader.GetGuid(6);
            enderecoEmpresa.EmpresaId = reader.GetGuid(7);

            enderecoEmpresas.Add(enderecoEmpresa);
        }

        return enderecoEmpresas;
    }

    public void Update(EnderecoEmpresa enderecoEmpresa, Guid idEndereco)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE ENDERECOS_EMPRESAS SET CEP = @CEP, NOME_RUA = @nomeRua, NUMERO = @numero, BAIRRO = @bairro, COMPLEMENTO = @complemento, CIDADE_ID = @idCidade, EMPRESA_ID = @idEmpresa WHERE ID_ENDERECO = @idEndereco";

        cmd.Parameters.AddWithValue("@idEndereco", idEndereco);
        cmd.Parameters.AddWithValue("@CEP", enderecoEmpresa.CEP);
        cmd.Parameters.AddWithValue("@nomeRua", enderecoEmpresa.NomeRua);
        cmd.Parameters.AddWithValue("@numero", enderecoEmpresa.Numero);
        cmd.Parameters.AddWithValue("@bairro", enderecoEmpresa.Bairro);
        cmd.Parameters.AddWithValue("@complemento", enderecoEmpresa.Complemento);
        cmd.Parameters.AddWithValue("@idCidade", enderecoEmpresa.CidadeId);
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