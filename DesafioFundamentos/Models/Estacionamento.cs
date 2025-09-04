using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DesafioFundamentos.Client;

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

        public async Task AdicionarVeiculoComApi()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                return;
            }

            placa = placa.ToUpper().Trim();

            Console.WriteLine("Consultando placa na base de dados...");
            string? nomeVeiculo = await ApiClient.ConsultarPlaca(placa);
            
            if (nomeVeiculo != null)
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {nomeVeiculo} com a placa {placa} foi estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa não encontrada ou a consulta falhou. Veículo não cadastrado.");
            }
        }
        public Task AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                return Task.CompletedTask;
            } 
            if(veiculos.Contains(placa))
            {
                Console.WriteLine("Veículo já está estacionado. Por favor, tente novamente.");
                return Task.CompletedTask;
            }

            placa = placa.ToUpper().Trim();
            
            veiculos.Add(placa);
            return Task.CompletedTask;
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover: ");
            string? placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                return;
            }
            
            string placaValidada = placa.ToUpper().Trim();

            if (veiculos.Any(x => x.ToUpper() == placaValidada))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                string? inputHoras;
                bool entradaValida = false;

                while (!entradaValida)
                {
                    inputHoras = Console.ReadLine();
                    if (int.TryParse(inputHoras, out horas) && horas >= 0)
                    {
                        entradaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Digite um número inteiro positivo para as horas:");
                    }
                }
                
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placaValidada);
                Console.WriteLine($"O veículo {placaValidada} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
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