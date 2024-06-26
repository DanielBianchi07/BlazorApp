using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;
using BlazorApp.Api.Repositories.Interface;

namespace BlazorApp.Api.Repositories.SqlRepository;

public class EmpresaSqlRepository : DatabaseConnection, IEmpresaSqlRepository
{
    public void Create(Empresa empresa)
    {
        empresa.Id = Guid.NewGuid();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO EMPRESAS VALUES (@id, @cnpj, @razao_social, @email, @status)";

        cmd.Parameters.AddWithValue("@id", empresa.Id);
        cmd.Parameters.AddWithValue("@cnpj", empresa.CNPJ);
        cmd.Parameters.AddWithValue("@razao_social", empresa.RazaoSocial);
        cmd.Parameters.AddWithValue("@email", empresa.Email);
        cmd.Parameters.AddWithValue("@status", empresa.Status);

        cmd.ExecuteNonQuery();
    }

    public IEnumerable<Empresa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM EMPRESAS";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Empresa> empresas = new List<Empresa>();

        while(reader.Read())
        {
            Empresa empresa = new Empresa();
            empresa.Id = reader.GetGuid(0);
            empresa.CNPJ = reader.GetString(1);
            empresa.RazaoSocial = reader.GetString(2);
            empresa.Email = reader.GetString(3);
            empresa.Status = reader.GetInt32(4);

            empresas.Add(empresa);
        }

        return empresas;
    }

    public Empresa Read(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM EMPRESAS WHERE ID_EMPRESA = @id";

        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        Empresa empresa = new Empresa();
        while(reader.Read())
        {
            empresa.Id = reader.GetGuid(0);
            empresa.CNPJ = reader.GetString(1);
            empresa.RazaoSocial = reader.GetString(2);
            empresa.Email = reader.GetString(3);
            empresa.Status = reader.GetInt32(4);
        }

        return empresa;
    }

    public void Update(Empresa empresa, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE EMPRESAS SET CNPJ = @cnpj, RAZAO_SOCIAL = @razao_social, EMAIL = @email, STATUS = @status WHERE ID_EMPRESA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@cnpj", empresa.CNPJ);
        cmd.Parameters.AddWithValue("@razao_social", empresa.RazaoSocial);
        cmd.Parameters.AddWithValue("@email", empresa.Email);
        cmd.Parameters.AddWithValue("@status", empresa.Status);

        cmd.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM EMPRESAS WHERE ID_EMPRESA = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
