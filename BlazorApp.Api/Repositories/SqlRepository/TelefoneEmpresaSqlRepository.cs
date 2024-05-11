using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TelefoneEmpresaSqlRepository : DatabaseConnection, ITelefoneEmpresaSqlRepository
{
    public void Create(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TELEFONES_EMPRESAS VALUES (@idTelefone, @idEmpresa, @nroTelefone)";

        cmd.Parameters.AddWithValue("@idTelefone", Guid.NewGuid());
        cmd.Parameters.AddWithValue("@idEmpresa", telefoneEmpresa.EmpresaId);
        cmd.Parameters.AddWithValue("@nroTelefone", telefoneEmpresa.NroTelefone);

        cmd.ExecuteNonQuery();
    }
    public IEnumerable<TelefoneEmpresa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TELEFONES_EMPRESAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<TelefoneEmpresa> telefonesEmpresas = new List<TelefoneEmpresa>();

        while(reader.Read())
        {
            TelefoneEmpresa telefoneEmpresa = new TelefoneEmpresa();
            telefoneEmpresa.Id = reader.GetGuid(0);
            telefoneEmpresa.EmpresaId = reader.GetGuid(1);
            telefoneEmpresa.NroTelefone = reader.GetString(2);

            telefonesEmpresas.Add(telefoneEmpresa);
        }

        return telefonesEmpresas;
    }

    public IEnumerable<TelefoneEmpresa> Read(Guid idEmpresa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TELEFONES_EMPRESAS WHERE ID_EMPRESA = @id AND ID_TELEFONE_EMP = @idTelefone";

        cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);

        SqlDataReader reader = cmd.ExecuteReader();

        List<TelefoneEmpresa> telefonesEmpresas = new List<TelefoneEmpresa>();

        while(reader.Read())
        {
            TelefoneEmpresa telefoneEmpresa = new TelefoneEmpresa();
            telefoneEmpresa.Id = reader.GetGuid(0);
            telefoneEmpresa.EmpresaId = reader.GetGuid(1);
            telefoneEmpresa.NroTelefone = reader.GetString(2);

            telefonesEmpresas.Add(telefoneEmpresa);
        }

        return telefonesEmpresas;
    }

    public void Update(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE EMPRESAS SET CNPJ = @cnpj, RAZAO_SOCIAL = @razao_social, EMAIL = @email, STATUS = @status WHERE ID_EMPRESA = @idEmpresa AND ID_TELEFONE_EMP = @idTelefone";

        cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.Parameters.AddWithValue("@cnpj", telefoneEmpresa.EmpresaId);
        cmd.Parameters.AddWithValue("@razao_social", telefoneEmpresa.NroTelefone);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idEmpresa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM TELEFONES_EMPRESAS WHERE ID_EMPRESA = @id AND ID_TELEFONE_EMP = @idTelefone";

        cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.ExecuteNonQuery();
    }
}