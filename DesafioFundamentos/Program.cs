// See https://aka.ms/new-console-template for more information
using DesafioFundamentos.Models;
using DesafioFundamentos.Models;

using System.Text;

// Configura UTF8 para acentuação
Console.OutputEncoding = Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("=======================================");
Console.WriteLine("   Bem-vindo ao Sistema de Estacionamento");
Console.WriteLine("=======================================\n");

Console.Write("Digite o preço inicial: R$ ");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.Write("Digite o preço por hora: R$ ");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia da classe Estacionamento
Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

string opcao;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("=======================================");
    Console.WriteLine("           MENU PRINCIPAL");
    Console.WriteLine("=======================================");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.WriteLine("=======================================");
    Console.Write("Escolha uma opção: ");
    opcao = Console.ReadLine();

    Console.Clear();

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
            Console.WriteLine("Encerrando o sistema...");
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida! Tente novamente.");
            Console.ResetColor();
            break;
    }

    if (exibirMenu)
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}

Console.WriteLine("Sistema encerrado. Até logo!");

