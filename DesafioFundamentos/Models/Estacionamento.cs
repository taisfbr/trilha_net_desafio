using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Por favor, insira uma placa válida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe na lista
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Lê a quantidade de horas e realiza a validação
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    // Calcula o valor total
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa);

                    // Exibe o valor total
                    Console.WriteLine($"O veículo com placa {placa} foi removido e o preço total a pagar é: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, insira um número válido.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Realiza um laço de repetição para exibir cada veículo
                foreach (string veiculo in veiculos)
                {
                Console.WriteLine(veiculo);
                }
                }
                else
                {
                Console.WriteLine("Não há veículos estacionados.");
                }
        }
    }
}
