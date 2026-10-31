using System;//Biblioteca base do C#.

public class Cliente
{
    public string Nome { get; set; } ="";
    public string Cpf { get; set; } ="";
    public string Celular { get; set; } = "";
    public string Email { get; set; } = ""; 
    public string Senha { get; set; } = "";
    /*
      A classe 'Cliente' tem uma viagem escolhida.
      'Associação' É quando uma classe possui referência a outra classe.
      A classe 'Cliente' -> possui referência -> ao objeto 'Viagem'.
    */
    public Viagem? ViagemEscolhida { get; set; } 
    public void ExibirDados()
    {
        //'$' é a interpolação de string,graças a ele é permitido exibir o valor de
        //uma variável diretamente dentro do texto.
        Console.WriteLine($"\nNome: {Nome}");
        // Remove pontos e traços antes de formatar o CPF para exibição.
        string cpfLimpo = Cpf.Replace(".", "").Replace("-", "");
        Console.WriteLine($"\nCpf: {long.Parse(cpfLimpo):000\\.000\\.000-00}");
        Console.WriteLine($"\nCelular: {Celular}");
        Console.WriteLine($"\nEmail: {Email}");
        Console.WriteLine($"\nSenha: {Senha}");

    }
}
