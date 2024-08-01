using DesafioFundamentos.Exceptions;
using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial;
decimal precoPorHora;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

while (true)
{
    Console.WriteLine("Digite o preço inicial:");
    string inputInicial = Console.ReadLine();
    if (decimal.TryParse(inputInicial, out precoInicial) && precoInicial >= 0)
    {
        break;
    }
    else
    {
        Console.WriteLine("Valor inválido. Por favor, digite um número decimal não negativo.");
    }
}

while (true)
{
    Console.WriteLine("Agora digite o preço por hora:");
    string inputPorHora = Console.ReadLine();
    if (decimal.TryParse(inputPorHora, out precoPorHora) && precoPorHora >= 0)
    {
        break;
    }
    else
    {
        Console.WriteLine("Valor inválido. Por favor, digite um número decimal não negativo.");
    }
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);


bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
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
            Console.WriteLine("Opção inválida");
            break;
    }


    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
