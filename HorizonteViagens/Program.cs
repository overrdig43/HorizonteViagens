using System; //Biblioteca base do C#.
using System.Linq; //Biblioteca utilizada para verificar se o usuário responderá apenas com números nos campos cpf e cadastro do celular.
using System.Text.RegularExpressions; //Biblioteca capaz de filtrar e verificar se as informações digitadas pelo usuário são validas.

public class Program
{
    
    static void Main()
    {
        ClienteNegocio negocio = new ClienteNegocio();

        bool programaRodando = true;
        while (programaRodando)
        {
            /*
              'Console.Clear();' Serve para deixar o código mais limpo no momento em que estiver sendo executado,
              pois tudoo que foi digitado no menu será apagado toda vez que repetir.
            */
            Console.Clear();

            Console.WriteLine("Selecione uma das opções:\n ");
            Console.WriteLine("1 - Pacotes de Luxo");
            Console.WriteLine("2 - Pacotes Econômicos");
            Console.WriteLine("3 - Cadastre-se");
            Console.WriteLine("0 - Sair\n");

            string Menu = Console.ReadLine() ?? "";

            switch (Menu)
            {

                case "0":
                    programaRodando = false;
                    break;

                case "1":
                    Console.WriteLine("===PACOTES DE LUXO===\n");

                    //Instanciando objetos das classes filhas.
                    PacoteLuxo pacote1 = new PacoteLuxo("Paris - França", 15000.00, 15, "Torre Eiffel");
                    PacoteLuxo pacote2 = new PacoteLuxo("Tokyo - Japão", 18000.00, 20, "Monte Fuji");
                    PacoteLuxo pacote3 = new PacoteLuxo("Nova York - EUA", 12000.00, 10, "Central Park");

                    /*
                    Polimorfismo, estamos buscando o método 'ExibirDetalhes'. 
                    E estamos atribuindo os diferentes possiveis resultados, dependendo do valor.
                    No caso 'pacote1', 'pacote2' e ´pacote3'.
                    */
                    pacote1.ExibirDetalhes();
                    pacote2.ExibirDetalhes();
                    pacote3.ExibirDetalhes();

                    Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu..");
                    //'Console.ReadKey();' necessário para freiar o programa até que o usuário insira qualquer comando.
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("===PACOTES ECONÔMICOS===\n");

                    //Adicionando instancia as classes filhas.
                    PacoteEconomico economico1 = new PacoteEconomico("Porto Seguro - Brasil", 4500.00, 10, "Trancoso");
                    PacoteEconomico economico2 = new PacoteEconomico("Ubatuba - Brasil", 3200.00, 7, "Praia de Itamambuca");
                    PacoteEconomico economico3 = new PacoteEconomico("Florianópolis - Brasil", 5500.00, 8, "Praia dos Açores");

                    /*
                    Polimorfismo, estamos buscando o método 'ExibirDetalhes'. 
                    E estamos atribuindo os diferentes possiveis resultados, dependendo do valor.
                    No caso 'economico1', 'economico2' e ´economico3'.
                    */
                    economico1.ExibirDetalhes();
                    economico2.ExibirDetalhes();
                    economico3.ExibirDetalhes();

                    Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu..");
                    //'Console.ReadKey();' necessário para freiar o programa até que o usuário insira qualquer comando.
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("\n===CADASTRO===\n");
                    /*
                    'List<Viagem>' cria uma lista do tipo 'Viagem', armazenando objetos do tipo 'PacoteLuxo' e 'PacoteEconomico'.
                    Pois ambos herdam da classe mãe 'Viagem'.
                    */
                    List<Viagem> PacotesLuxo = new List<Viagem>
                    {
                        //Instanciando os objetos 'PacoteLuxo' dentro da lista.
                        new PacoteLuxo("Paris - França", 15000.00, 15, "Torre Eiffel"),
                        new PacoteLuxo("Tokyo - Japão", 18000.00, 20, "Monte Fuji"),
                        new PacoteLuxo("Nova York - EUA", 12000.00, 10, "Central Park")
                    };

                    List<Viagem> PacotesEconomicos = new List<Viagem>
                    {
                        //Instanciando os objetos 'PacoteEconomico' dentro da lista.
                        new PacoteEconomico("Porto Seguro - Brasil", 4500.00, 10, "Trancoso"),
                        new PacoteEconomico("Ubatuba - Brasil", 3200.00, 7, "Praia de Itamambuca"),
                        new PacoteEconomico("Florianópolis - Brasil", 5500.00, 8, "Praia dos Açores")
                    };

                    // 'Viagem viagemSelecionada = null' aguarda o usuário escolher um pacote para ser preenchida.
                    Viagem? viagemSelecionada = null;
                    // 'pacoteEscolhido' controla o loop, impedindo que o programa avance antes que o usuário selecione o pacote desejado.
                    bool pacoteEscolhido = false;
                    while (!pacoteEscolhido)
                    {
                        Console.WriteLine("Escolha a categoria do pacote\n");
                        Console.WriteLine("1 - Pacotes de Luxo");
                        Console.WriteLine("2 - Pacotes Econômicos");

                        // Armazena a categoria escolhida pelo usuário.
                        string categoria = Console.ReadLine() ?? "";
                        // 'pacotesCategoria = null' aguarda a escolha do usuário para receber a lista correspondente a escolha do usuário.
                        List<Viagem>? pacotesCategoria = null;

                        // Se o usuário escolher '1', a lista 'PacotesLuxo' será atribuída a 'pacotesCategoria'.
                        if (categoria == "1")
                        {
                            pacotesCategoria = PacotesLuxo;
                            Console.WriteLine("\n=== PACOTE DE LUXO ===\n");
                        }
                        // Se o usuário escolher '2', a lista 'PacotesEconomicos' será atribuída a 'pacotesCategoria'.
                        else if (categoria == "2")
                        {
                            pacotesCategoria = PacotesEconomicos;
                            Console.WriteLine("\n=== PACOTE ECONÔMICO ===\n");
                        }
                        //Se o usuário digitar qualquer outro valor será impresso uma mensagem de erro.
                        else
                        {
                            Console.WriteLine("ERRO: Opção inválida! Digite apenas '1' ou '2'");
                            //'Continue' serve para voltar no início do 'while'.
                            continue;
                        }
                        /* 
                          O 'for' foi utilizado pois o usuário irá escolher o pacote de viagem por meio de uma escolha numérica.
                          Caso o objetivo fosse apenas apresentar o pacote de viagem o mais ideal seria usar o 'foreach'.
                        */
                        for (int i = 0; i < pacotesCategoria.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {pacotesCategoria[i].Destino}");
                            pacotesCategoria[i].ExibirDetalhes();
                            Console.WriteLine();
                        }

                        bool destinoEscolhido = false;
                        while (!destinoEscolhido)
                        {
                            Console.WriteLine("\nDigite o número do pacote desejado");
                            string escolha = Console.ReadLine() ?? "";

                            if (int.TryParse(escolha, out int indice) && indice >= 1 && indice <= pacotesCategoria.Count)
                            {
                                // A lista começa no índice 0, mas exibimos para o usuário começando em 1.
                                // Por isso subtraímos 1 para buscar o item correto na lista.
                                viagemSelecionada = pacotesCategoria[indice - 1];
                                destinoEscolhido = true;
                                pacoteEscolhido = true;

                                Console.WriteLine("\nPacote Selecionado: ");
                                viagemSelecionada.ExibirDetalhes();

                            }

                            else
                            {
                                Console.WriteLine($"ERRO: Opção inválida! Digite apenas um número entre 1 e {pacotesCategoria.Count}.");
                            }
                        }
                    }

                    Console.WriteLine("\n===CADASTRO DE CLIENTE===");
                    //Novo objeto 'Cliente', será responsável pelo armazenamento de dados digitados pelo cliente.
                    Cliente novoCliente = new Cliente();

                    //Repete o processo até que o usuário digite um valor valido.
                    bool NomeValido = false;
                    while (!NomeValido)
                    {
                        Console.WriteLine("Nome: ");
                        string nomeInput = Console.ReadLine() ?? "";


                        /* Filtro duplo de segurança:
                        '!string.IsNullOrWhiteSpace' verifica se o campo não está vazio ou em branco.
                        'ApenasLetras()' chama o método auxiliar que valida se o nome contém apenas letras.
                        */
                        if (negocio.NomeValido(nomeInput))

                        {
                            // Nome aprovado, armazena o valor no objeto 'novoCliente' e encerra o loop.
                            novoCliente.Nome = nomeInput;
                            NomeValido = true;
                        }

                        else
                        {
                            Console.WriteLine("ERRO: O Nome deverá conter apenas letras e não pode estar vazio.");
                        }
                    }

                    bool CpfValido = false;
                    while (!CpfValido)
                    {
                        Console.WriteLine("\nCpf: ");
                        string cpfInput = Console.ReadLine() ?? "";
                        //Caso o usuário digite ponto e traço o programa irá reconhecer da mesma forma, desde que possua 11 digitos.
                        string cpfLimpo = cpfInput.Replace(".", "").Replace("-", "");
                        /*Filtro de segurança triplo.
                        '!string.IsNullOrWhiteSpace(cpfLimpo)' Verifica se não está vazio nem em branco.
                        'cpfLimpo.Length == 11' Valida se possui 11 digitos.
                        'cpfLimpo.All(char.IsDigit)' Valida cada caractere da string e valida se é um número de 0 a 9
                        */
                        if (negocio.CpfValido(cpfInput))
                        {

                            novoCliente.Cpf = cpfLimpo;
                            //'long.Parse(cpfLimpo)' é necessário usar para que o  C# consiga entender que os dados digitados deverão ser tratados como números,
                            //mesmo se tratando de uma 'string'.
                            //'ToString(@"000\.000\.000\-00")' é usado para delimitar a forma com que os dados inseridos serão separados através das barras.
                            string cpfFormatado = long.Parse(novoCliente.Cpf).ToString(@"000\.000\.000\-00");
                            CpfValido = true;
                            Console.WriteLine($"CPF registrado: {cpfFormatado}");
                        }

                        else
                        {
                            Console.WriteLine("ERRO: O Cpf deveráconter apenas 11 números e não pode estar vazio.");
                        }
                    }

                    bool celularValido = false;
                    while (!celularValido)
                    {
                        Console.WriteLine("\nCelular (EX = 16988994455): ");
                        string input = Console.ReadLine() ?? "";

                        //Limpa os caracteres especiais
                        string apenasNumeros = input.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                        //Filtro de segurança triplo.
                        //'!string.IsNullOrWhiteSpace(apenasNumeros)' Verifica se não está vazio nem em branco.
                        //'apenasNumeros.Length == 11' Valida se possui 11 digitos.
                        //'apenasNumeros.All(char.IsDigit)' Valida cada caractere da string e valida se é um número de 0 a 9
                        if (negocio.CelularValido(input))
                        {
                            //A forma que o usuário digitar, o programa irá aceitar
                            novoCliente.Celular = apenasNumeros;

                            //'long.Parse(Celular)' é necessário usar para que o  C# consiga entender que os dados digitados deverão ser tratados como números,
                            //mesmo se tratando de uma 'string'.
                            //'ToString(@"\(00\)\ 0\.0000\-0000")' é usado para delimitar a forma com que os dados inseridos serão separados através das barras.
                            celularValido = true;
                            Console.WriteLine($"\nContato: {long.Parse(novoCliente.Celular).ToString(@"\(00\)\ 0\.0000\-0000")}");
                        }
                        else
                        {
                            Console.WriteLine("ERRO: Número do celular inválido!");
                        }
                    }

                    bool emailValido = false;
                    while (!emailValido) //Enquantonão for valido
                    {
                        Console.WriteLine("\nDigite seu e-mail: ");
                        string emailInput = Console.ReadLine() ?? "";

                        //Filtro de segurança triplo.
                        //'!string.IsNullOrWhiteSpace(Email)' Verifica se não está vazio nem em branco.
                        //'Email.Contains("@")' Deverá conter '@'.
                        //'Email.Contains(".")' Deverá conter '.' (ponto).
                        if (negocio.EmailValido(emailInput))
                        {
                            novoCliente.Email = emailInput;
                            emailValido = true;
                        }

                        else
                        {
                            Console.WriteLine("ERRO: Endereço de E-mail inválido");
                        }
                    }

                    bool senhaValido = false;
                    while (!senhaValido)
                    {
                        Console.WriteLine("\nCrie uma senha forte: ");
                        Console.WriteLine("A senha deverá possuir:");
                        Console.WriteLine("\n*** Minimo 8 dígitos ***");
                        Console.WriteLine("\n*** Letra maíuscula ***");
                        Console.WriteLine("\n*** Letra minúscula ***");
                        Console.WriteLine("\n*** Número ***");
                        Console.WriteLine("\n*** Caracterer especial***");
                        Console.WriteLine("\nSenha: ");

                        string senhaInput = Console.ReadLine() ?? "";
                        //'Regex' está sendo usado para verificar.
                        // 'IsMatch' é responsavél por recer parâmetros e e verificar se é verdadeiro ou falso.
                     
                        if (negocio.SenhaForte(senhaInput))

                        {
                            novoCliente.Senha = senhaInput;
                            senhaValido = true;
                            Console.WriteLine("Senha aprovada");
                        }
                        else
                        {
                            Console.WriteLine("ERRO: A senha não atende os requisitos de segurança!");
                        }
                    }

                    Console.WriteLine("\n---VERIFICAÇÃO DE DADOS---");

                    //'ExibirDados()' exibe todas as informações digitadas pelo usuário para conferência antes de confirmar o cadastro.
                    novoCliente.ExibirDados();

                    // 'confirmacaoFinalizada' controla o loop, impedindo que o programa avance antes que o usuário confirme ou cancele o cadastro.
                    bool confirmacaoFinalizada = false;

                    while (!confirmacaoFinalizada)
                    {
                        Console.WriteLine("\n---CONFIRMAR CADASTRO---\n");
                        Console.WriteLine("Confirmar cadastro 'S' -> SIM");
                        Console.WriteLine("Cancelar cadastro 'N' -> NÃO");
                        //'ToUpper' é usado para transformar tudo aquilo que o usuário digitar na string em maiúsculo.
                        string confirmar = Console.ReadLine()?.ToUpper() ?? "";

                        if (confirmar == "S")
                        {
                            // Associação: o pacote selecionado é atribuído ao objeto 'novoCliente'.
                            novoCliente.ViagemEscolhida = viagemSelecionada!;
                            Console.WriteLine("Dados salvos com sucesso!");
                            Console.WriteLine("===PACOTE CONTRATADO===");
                            novoCliente.ViagemEscolhida.ExibirDetalhes();

                            //'Console.ReadKey();' necessário para freiar o programa até que o usuário insira qualquer comando.
                            Console.ReadKey();
                            confirmacaoFinalizada = true;
                        }

                        else if (confirmar == "N")
                        {
                            Console.WriteLine("Dados cancelados!");
                            Console.WriteLine("Precione qualquer tecla para voltar ao menu inicial");
                            //'Console.ReadKey();' necessário para freiar o programa até que o usuário insira qualquer comando.
                            Console.ReadKey();
                            confirmacaoFinalizada = true;
                            // Limpa o console e retorna ao menu principal.
                            Console.Clear();
                        }

                        else
                        {
                            // Caso o usuário digite qualquer valor diferente de 'S' ou 'N', o loop se repete.
                            Console.WriteLine("ERRO: Opção invalida!");
                            Console.WriteLine("Confirmar cadastro 'S' -> SIM");
                            Console.WriteLine("Cancelar cadastro 'N' -> NÃO");
                        }
                    }
                    // 'break' encerra o case "3" e retorna ao menu principal.
                    break;

                // 'default' é acionado quando o usuário digita uma opção que não existe no switch.
                default:
                    Console.WriteLine("Opção Invalida!");

                    break;
             
            }
            
        }

       
    }
}