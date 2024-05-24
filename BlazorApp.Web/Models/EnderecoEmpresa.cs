using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Models;
public class EnderecoEmpresa
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo CEP é obrigatório")]
    [StringLength(16, ErrorMessage = "Limite de caracteres atingido.")]
    public string CEP { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo Estado é obrigatório")]
    public string Estado { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo Cidade é obrigatório")]
    public string Cidade { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo Bairro é obrigatório")]
    [StringLength(128, ErrorMessage = "Limite de caracteres atingido.")]
    public string Bairro { get; set; } = string.Empty;
    [Required(ErrorMessage = "O Nome da rua é obrigatório")]
    [StringLength(128, ErrorMessage = "Limite de caracteres atingido.")]
    public string NomeRua { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O campo Número é obrigatório")]
    [StringLength(5 ,ErrorMessage = "Número inválido")]    
    public string? Numero { get; set; }
    public string? Complemento { get; set; } = string.Empty;
    public int Status { get; set; }
    public Guid EmpresaId { get; set; }
}