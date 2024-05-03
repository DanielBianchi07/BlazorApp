namespace BlazorApp.Api.Models;
public class CadernoResposta
{
    public Guid Id { get; set; }
    public int NroPergunta { get; set; }
    public string AltSelecionada { get; set; } = string.Empty;
    public Guid PessoaId { get; set; }
}