using Microsoft.Data.SqlClient;
using BlazorApp.Api.Models;

public class EmpresaSqlRepository : DatabaseConnection, IEmpresaRepository
{
    public void Create(Empresa empresa)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO EMPRESAS VALUES (@id, @cnpj, @razao_social, @email, @status)";

        cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
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
        cmd.CommandText = "SELECT EMP.ID_EMPRESA, EMP.CNPJ, EMP.RAZAO_SOCIAL, TEMP.NRO_TELEFONE, EMP.STATUS FROM EMPRESAS AS EMP LEFT JOIN TELEFONES_EMPRESAS AS TEMP ON EMP.ID_EMPRESA = TEMP.EMPRESA_ID GROUP BY EMP.ID_EMPRESA, EMP.CNPJ, EMP.RAZAO_SOCIAL, TEMP.NRO_TELEFONE, EMP.STATUS";

        SqlDataReader reader = cmd.ExecuteReader();

        Dictionary<Guid, Empresa> empresasDict = new Dictionary<Guid, Empresa>();

    while (reader.Read())
    {
        Guid idEmpresa = reader.GetGuid(0);

        // Verifica se a empresa já existe no dicionário
        if (!empresasDict.ContainsKey(idEmpresa))
        {
            Empresa empresa = new Empresa();
            empresa.Id = reader.GetGuid(0);
            empresa.CNPJ = reader.GetString(1);
            empresa.RazaoSocial = reader.GetString(2);
            empresa.Telefones = new List<string>(); // Inicializa a lista de telefones
            empresa.Status = reader.GetInt32(5);

            empresasDict.Add(idEmpresa, empresa);
        }

        // Adiciona o número de telefone à empresa correspondente no dicionário
        string numeroTelefone = reader.IsDBNull(4) ? null : reader.GetString(4);
        if (!string.IsNullOrEmpty(numeroTelefone))
        {
            empresasDict[idEmpresa].Telefones.Add(numeroTelefone);
        }
    }

    // Agora, converta o dicionário para uma coleção de empresas e retorne
    return empresasDict.Values;
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
