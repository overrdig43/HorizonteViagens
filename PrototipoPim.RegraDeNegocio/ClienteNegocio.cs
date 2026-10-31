using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using PrototipoPim.Modelos;
using PrototipoPim.Modelos.Dtos;
using PrototipoPim.Repositorio.Interfaces;

namespace PrototipoPim.RegraDeNegocio;

/// <summary>Aplica validações e coordena o cadastro do cliente.</summary>
public sealed class ClienteNegocio(IClienteRepositorio clientes, IViagemRepositorio viagens)
{
    public IReadOnlyList<Viagem> ListarViagens() => viagens.Listar();

    public ClienteDto Cadastrar(ClienteCadastroDto dados)
    {
        var nome = dados.Nome.Trim();
        if (!Regex.IsMatch(nome, @"^[\p{L} ]{3,120}$"))
            throw new RegraDeNegocioException("Informe um nome com pelo menos três letras.");

        var cpf = Regex.Replace(dados.Cpf, @"\D", "");
        if (!CpfValido(cpf))
            throw new RegraDeNegocioException("O CPF informado é inválido.");

        var celular = Regex.Replace(dados.Celular, @"\D", "");
        if (celular.Length != 11)
            throw new RegraDeNegocioException("O celular deve conter DDD e 9 dígitos.");

        var email = dados.Email.Trim();
        if (clientes.EmailJaCadastrado(email))
            throw new RegraDeNegocioException("Já existe um cadastro com este e-mail.");

        if (!SenhaForte(dados.Senha))
            throw new RegraDeNegocioException("A senha precisa ter 8 caracteres, maiúscula, minúscula, número e símbolo.");

        if (viagens.BuscarPorId(dados.ViagemId) is null)
            throw new RegraDeNegocioException("O pacote escolhido não existe.");

        // PBKDF2 evita gravar a senha em texto puro; o salt aleatório acompanha o hash salvo.
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(dados.Senha, salt, 100_000, HashAlgorithmName.SHA256, 32);
        var cliente = clientes.Adicionar(new Cliente
        {
            Nome = nome,
            Cpf = cpf,
            Celular = celular,
            Email = email,
            SenhaHash = Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash),
            ViagemId = dados.ViagemId
        });

        return ParaDto(cliente);
    }

    public IReadOnlyList<ClienteDto> ListarClientes() => clientes.Listar().Select(ParaDto).ToList();

    private static ClienteDto ParaDto(Cliente cliente) =>
        new(cliente.Id, cliente.Nome, cliente.Cpf, cliente.Celular, cliente.Email, cliente.ViagemId);

    private static bool SenhaForte(string senha) => senha.Length >= 8
        && Regex.IsMatch(senha, @"[A-Z]") && Regex.IsMatch(senha, @"[a-z]")
        && Regex.IsMatch(senha, @"\d") && Regex.IsMatch(senha, @"[^a-zA-Z0-9]");

    // Valida os dígitos verificadores do CPF e rejeita sequências repetidas.
    private static bool CpfValido(string cpf)
    {
        if (cpf.Length != 11 || cpf.Distinct().Count() == 1 || !cpf.All(char.IsDigit)) return false;
        static int Digito(string trecho, int pesoInicial)
        {
            var soma = trecho.Select((digito, indice) => (digito - '0') * (pesoInicial - indice)).Sum();
            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
        return Digito(cpf[..9], 10) == cpf[9] - '0' && Digito(cpf[..10], 11) == cpf[10] - '0';
    }
}

/// <summary>Erro esperado de validação que a API transforma em resposta HTTP 400.</summary>
public sealed class RegraDeNegocioException(string message) : Exception(message);
