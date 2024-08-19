using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placaDigitada = Console.ReadLine();

            if (!string.IsNullOrEmpty(placaDigitada))
            {
                veiculos.Add(placaDigitada);
                Console.WriteLine($"Veículo '{placaDigitada}' adicionado à lista.");
            }
            else
            {
                Console.WriteLine("Placa não pode ser nula ou vazia.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string? placa = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa))
            {
                if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    string? horasString = Console.ReadLine();

                    if (int.TryParse(horasString, out int horasQuePermaneceuEstacionado))
                    {
                        decimal valorTotal = precoInicial + precoPorHora * horasQuePermaneceuEstacionado;
                        veiculos.Remove(placa);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de horas inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
            else
            {
                Console.WriteLine("Placa não pode ser nula ou vazia.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
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
