using Microsoft.Data.SqlClient;

public abstract class DatabaseConnection : IDisposable
{
    protected SqlConnection connection;

    public DatabaseConnection() 
    {
        Console.WriteLine("Abriu conexão");
        string strConn = @"Data Source=localhost; 
        Initial Catalog=BD_CERTIFICADOS; 
        Integrated Security=False;
        TrustServerCertificate=True;
        User=aluno;
        Password=dba";
        connection = new SqlConnection(strConn);
        connection.Open();
    }

    public void Dispose()
    {
        Console.WriteLine("Fechou conexão");
        connection.Close();
    }
}
