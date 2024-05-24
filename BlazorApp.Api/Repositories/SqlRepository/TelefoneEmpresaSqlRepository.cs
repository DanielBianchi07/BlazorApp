using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class TelefoneEmpresaSqlRepository : DatabaseConnection, ITelefoneEmpresaSqlRepository
{
    public void Create(TelefoneEmpresa telefoneEmpresa, Guid idEmpresa)
    {
        telefoneEmpresa.Id = Guid.NewGuid();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO TELEFONES_EMPRESAS VALUES (@idTelefone, @idEmpresa, @nroTelefone, @status)";

        cmd.Parameters.AddWithValue("@idTelefone", telefoneEmpresa.Id);
        cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
        cmd.Parameters.AddWithValue("@nroTelefone", telefoneEmpresa.NroTelefone);
        cmd.Parameters.AddWithValue("@status", telefoneEmpresa.Status);

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
            telefoneEmpresa.Status = reader.GetInt32(3);

            telefonesEmpresas.Add(telefoneEmpresa);
        }

        return telefonesEmpresas;
    }

    public IEnumerable<TelefoneEmpresa> Read(Guid idEmpresa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM TELEFONES_EMPRESAS WHERE EMPRESA_ID = @idEmpresa";

        cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

        SqlDataReader reader = cmd.ExecuteReader();

        List<TelefoneEmpresa> telefonesEmpresas = new List<TelefoneEmpresa>();

        while(reader.Read())
        {
            TelefoneEmpresa telefoneEmpresa = new TelefoneEmpresa();
            telefoneEmpresa.Id = reader.GetGuid(0);
            telefoneEmpresa.EmpresaId = reader.GetGuid(1);
            telefoneEmpresa.NroTelefone = reader.GetString(2);
            telefoneEmpresa.Status = reader.GetInt32(3);

            telefonesEmpresas.Add(telefoneEmpresa);
        }

        return telefonesEmpresas;
    }

    public void Update(TelefoneEmpresa telefoneEmpresa, Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE TELEFONES_EMPRESAS SET NRO_TELEFONE = @nroTelefone, STATUS = @status WHERE ID_TELEFONE_EMP = @idTelefone";

        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.Parameters.AddWithValue("@nroTelefone", telefoneEmpresa.NroTelefone);
        cmd.Parameters.AddWithValue("@status", telefoneEmpresa.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid idTelefone)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM TELEFONES_EMPRESAS WHERE ID_TELEFONE_EMP = @idTelefone";

        cmd.Parameters.AddWithValue("@idTelefone", idTelefone);
        cmd.ExecuteNonQuery();
    }
}