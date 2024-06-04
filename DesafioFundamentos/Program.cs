using DesafioFundamentos.Helper;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoPorHora = 0;
decimal precoInicial = 0;

ConsoleHelper.LogInformacao("----------------------------------------------------");
ConsoleHelper.LogInformacao("Seja bem vindo ao sistema de estacionamento!");
ConsoleHelper.LogInformacao("----------------------------------------------------");

ConsoleHelper.LogInformacao("Digite o preço inicial:");
while (!decimal.TryParse(Console.ReadLine(), out precoInicial))
{
    ConsoleHelper.LogErro($"Preço inicial informado inválido!");
    ConsoleHelper.LogInformacao("Digite o preço inicial:");
}

ConsoleHelper.LogInformacao("Agora digite o preço por hora:");
while (!decimal.TryParse(Console.ReadLine(), out precoPorHora)) ;
{
    ConsoleHelper.LogErro($"Preço por hora informado inválido!");
    ConsoleHelper.LogInformacao("Agora digite o preço por hora:");
}

var es = new Estacionamento(precoInicial, precoPorHora);

var opcao = string.Empty;

var exibirMenu = true;
while (exibirMenu)
{
    ConsoleHelper.Clear();
    ConsoleHelper.LogInformacao("Digite a sua opção:");
    ConsoleHelper.LogInformacao("1 - Cadastrar veículo");
    ConsoleHelper.LogInformacao("2 - Remover veículo");
    ConsoleHelper.LogInformacao("3 - Listar veículos");
    ConsoleHelper.LogInformacao("4 - Encerrar");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            ConsoleHelper.LogErro("Opção inválida");
            break;
    }

    ConsoleHelper.LogInformacao("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
