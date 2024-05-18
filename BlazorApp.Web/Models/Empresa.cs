using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Models;

public class Empresa
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(18)]
    public string CNPJ { get; set; } = string.Empty;
    [Required]
    [StringLength(128)]
    public string RazaoSocial { get; set; } = string.Empty;
    [Required]
    [StringLength(320)]
    public string Email { get; set; } = string.Empty;
    public int Status { get; set; }
}