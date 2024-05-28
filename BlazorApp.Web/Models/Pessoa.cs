namespace BlazorApp.Web.Models;
public class Pessoa
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Status { get; set; } = 1;
}