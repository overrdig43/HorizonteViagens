using System.Linq;
using System.Text.RegularExpressions;

public class ClienteNegocio
{
    public bool NomeValido(string nome) =>
        !string.IsNullOrWhiteSpace(nome) && ApenasLetras(nome);

    public bool CpfValido(string cpf)
    {
        string cpfLimpo = cpf.Replace(".", "").Replace("-", "");
        return !string.IsNullOrWhiteSpace(cpfLimpo)
            && cpfLimpo.Length == 11
            && cpfLimpo.All(char.IsDigit);
    }

    public bool CelularValido(string celular)
    {
        string limpo = celular.Replace(" ", "").Replace("-", "");
        return !string.IsNullOrWhiteSpace(limpo)
            && limpo.All(char.IsDigit)
            && limpo.Length >= 10;
    }

    public bool EmailValido(string email) =>
        !string.IsNullOrWhiteSpace(email)
        && email.Contains('@')
        && email.Contains('.');

    public bool SenhaForte(string senha) =>
        Regex.IsMatch(senha, @"[A-Z]") &&
        Regex.IsMatch(senha, @"[a-z]") &&
        Regex.IsMatch(senha, @"[0-9]") &&
        Regex.IsMatch(senha, @"[\W_]") &&
        senha.Length >= 8;

    private bool ApenasLetras(string texto) =>
        Regex.IsMatch(texto, @"^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ\s]+$");
}
