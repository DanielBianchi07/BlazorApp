namespace BlazorApp.Api.Models;

public class EnderecoEmpresa
{
    public Guid Id { get; set; }
    public string CEP { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string NomeRua { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string? Complemento { get; set; } = string.Empty;
    public int Status { get; set; }
    public Guid EmpresaId { get; set; }
}