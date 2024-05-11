namespace BlazorApp.Api.Models;

public class EnderecoEmpresa
{
    public Guid Id { get; set; }
    public string CEP { get; set; } = string.Empty;
    public string NomeRua { get; set; } = string.Empty;
    public int Numero { get; set; }
    public string Bairro { get; set; } = string.Empty;
    public string? Complemento { get; set; } = string.Empty;
    public Guid CidadeId { get; set; }
    public Guid EmpresaId { get; set; }
}