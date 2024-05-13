using System;
using DesafioFundamentos.Models;

namespace Estacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variáveis para armazenar o preço inicial e o preço por hora
            decimal precoInicial;
            decimal precoPorHora;

            // Solicitar ao usuário o preço inicial
            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
            Console.WriteLine("Digite o preço inicial:");

            // Loop para garantir que o usuário insira um número válido para o preço inicial
            while (!decimal.TryParse(Console.ReadLine(), out precoInicial))
            {
                Console.WriteLine("Valor inválido. Digite novamente o preço inicial:");
            }

            // Solicitar ao usuário o preço por hora
            Console.WriteLine("Agora digite o preço por hora:");

            // Loop para garantir que o usuário insira um número válido para o preço por hora
            while (!decimal.TryParse(Console.ReadLine(), out precoPorHora))
            {
                Console.WriteLine("Valor inválido. Digite novamente o preço por hora:");
            }

            // Instanciar a classe Estacionamento com os valores fornecidos
            var estacionamento = new DesafioFundamentos.Models.Estacionamento(precoInicial, precoPorHora);

            bool exibirMenu = true;

            // Loop do menu principal
            while (exibirMenu)
            {
                // Limpar a tela e exibir as opções do menu
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                // Capturar a opção escolhida pelo usuário
                string opcao = Console.ReadLine();

                // Executar a ação correspondente à opção escolhida
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
                        Console.WriteLine("Opção inválida. Pressione uma tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }

            // Mensagem de encerramento do programa
            Console.WriteLine("O programa foi encerrado. Pressione uma tecla para sair.");
            Console.ReadKey();
        }
    }
}
