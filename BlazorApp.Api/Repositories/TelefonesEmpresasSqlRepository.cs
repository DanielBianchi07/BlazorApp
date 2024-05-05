using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;

// Model = TelefoneEmpresa
// variavel do model = telefoneEmpresa
// variavel no plural = telefonesEmpresas


public class TelefoneEmpresaSqlRepository : DatabaseConnection, ITelefoneEmpresaRepository
{
    public void Create(TelefoneEmpresa telefoneEmpresa, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO EMPRESAS VALUES (@id, @cnpj, @razao_social, @email, @status)";

        cmd.Parameters.AddWithValue("@id", id);
    //    cmd.Parameters.AddWithValue("@cnpj", telefoneEmpresa.);
    //    cmd.Parameters.AddWithValue("@razao_social", telefoneEmpresa.RazaoSocial);
    //    cmd.Parameters.AddWithValue("@email", telefoneEmpresa.Email);
    //    cmd.Parameters.AddWithValue("@status", telefoneEmpresa.Status);

        cmd.ExecuteNonQuery();
    }
/*    
    public IEnumerable<TelefoneEmpresa> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM EMPRESAS";

        SqlDataReader reader = cmd.ExecuteReader();

        Dictionary<int, List<string>> empresasTelefones = new Dictionary<int, List<string>>();

        while(reader.Read())
        {
            TelefoneEmpresa telefoneEmpresa = new TelefoneEmpresa();
    //        telefoneEmpresa.Id = reader.GetGuid(0);
    //        telefoneEmpresa.CNPJ = reader.GetString(1);
    //        telefoneEmpresa.RazaoSocial = reader.GetString(2);
    //        telefoneEmpresa.Email = reader.GetString(3);
    //        telefoneEmpresa.Status = reader.GetInt32(4);

    //        telefonesEmpresas.Add(telefoneEmpresa);
        }

        return null;
    }
    */

    public void Update(TelefoneEmpresa telefoneEmpresa, Guid id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "UPDATE EMPRESAS SET CNPJ = @cnpj, RAZAO_SOCIAL = @razao_social, EMAIL = @email, STATUS = @status WHERE ID_EMPRESA = @id";

        cmd.Parameters.AddWithValue("@id", id);
    //    cmd.Parameters.AddWithValue("@cnpj", telefoneEmpresa.CNPJ);
    //    cmd.Parameters.AddWithValue("@razao_social", telefoneEmpresa.RazaoSocial);
    //    cmd.Parameters.AddWithValue("@email", telefoneEmpresa.Email);
    //    cmd.Parameters.AddWithValue("@status", telefoneEmpresa.Status);

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