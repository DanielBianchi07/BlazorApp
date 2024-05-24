using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Models;

public class Empresa
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
    [StringLength(18, ErrorMessage = "Limite de caracteres atingido.")]
    public string CNPJ { get; set; } = string.Empty;
//-------------------------------------------------------------------------    
    [Required(ErrorMessage = "A Razão Social é obrigatória")]
    [StringLength(128, ErrorMessage = "Limite de caracteres atingido.")]
    public string RazaoSocial { get; set; } = string.Empty;
//-------------------------------------------------------------------------
    [Required(ErrorMessage = "Coloque seu endereço de Email")]
    [StringLength(128, ErrorMessage = "Limite de caracteres atingido")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "O campo deve ser um Email")]
    public string Email { get; set; } = string.Empty;
    public int Status { get; set; }
}