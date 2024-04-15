using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");

Console.Write("Digite o preço inicial: ");
decimal precoInicial = Convert.ToDecimal(Console.ReadLine()!);

Console.Write("Agora digite o preço por hora: ");
decimal precoPorHora = Convert.ToDecimal(Console.ReadLine()!);

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento estacionamento = new(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Menu de opções: \n");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    Console.Write("\nPor favor, digite sua opção: ");
    string opcao = Console.ReadLine()!;

    switch (opcao)
    {
        case "1":
            estacionamento.AdicionarVeiculo();
            break;

        case "2":
            estacionamento.RemoverVeiculo();
            break;

        case "3":
            estacionamento.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar...");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
