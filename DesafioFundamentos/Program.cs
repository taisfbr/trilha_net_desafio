using System;
using DesafioFundamentos.Models;

class Program
{
    static void Main()
    {
        decimal precoInicial = 5.00m;
        decimal precoPorHora = 2.00m;
        int capacidadeInicial = 10;

        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora, capacidadeInicial);

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Cadastrar veículo");
            Console.WriteLine("2. Remover veículo");
            Console.WriteLine("3. Listar veículos");
            Console.WriteLine("4. Mostrar última placa adicionada");
            Console.WriteLine("5. Encerrar");
            Console.Write("Digite a opção desejada: ");

            string opcao = Console.ReadLine();

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
                    Console.WriteLine($"Última placa adicionada: {estacionamento.UltimaPlacaAdicionada ?? "Nenhuma placa adicionada ainda."}");
                    break;

                case "5":
                    continuar = false;
                    Console.WriteLine("Encerrando o sistema.");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
