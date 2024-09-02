using System;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private string[] veiculos;
        private int capacidadeAtual;
        private int capacidadeMaxima;
        private string ultimaPlacaAdicionada; // Variável para armazenar a última placa adicionada

        public Estacionamento(decimal precoInicial, decimal precoPorHora, int capacidadeInicial = 10)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new string[capacidadeInicial];
            this.capacidadeAtual = 0;
            this.capacidadeMaxima = capacidadeInicial;
            this.ultimaPlacaAdicionada = null;
        }

        private void GarantirCapacidade()
        {
            if (capacidadeAtual >= capacidadeMaxima)
            {
                capacidadeMaxima *= 2; // Dobra a capacidade do array
                string[] novoArray = new string[capacidadeMaxima];
                Array.Copy(veiculos, novoArray, veiculos.Length);
                veiculos = novoArray;
            }
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa inválida. A placa não pode estar vazia.");
                return;
            }

            string placaUpper = placa.ToUpper(); // Converte a placa para maiúsculas para garantir consistência

            // Verifica se o veículo já está no estacionamento
            if (Array.Exists(veiculos, v => v != null && v.Equals(placaUpper)))
            {
                Console.WriteLine("Veículo já está no estacionamento.");
                return;
            }

            // Garante que há capacidade suficiente para adicionar o novo veículo
            GarantirCapacidade();

            veiculos[capacidadeAtual] = placaUpper;
            capacidadeAtual++;
            ultimaPlacaAdicionada = placaUpper; // Armazena a última placa adicionada
            Console.WriteLine("Veículo adicionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa inválida. A placa não pode estar vazia.");
                return;
            }

            string placaUpper = placa.ToUpper(); // Converte a placa para maiúsculas para garantir consistência

            int index = Array.FindIndex(veiculos, v => v != null && v.Equals(placaUpper));

            if (index != -1)
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    decimal valorTotal = precoInicial + (precoPorHora * horas);
                    veiculos[index] = null; // Remove o veículo do array
                    // Move todos os veículos seguintes para preencher o espaço vazio
                    for (int i = index; i < capacidadeAtual - 1; i++)
                    {
                        veiculos[i] = veiculos[i + 1];
                    }
                    veiculos[capacidadeAtual - 1] = null; // Limpa a última posição
                    capacidadeAtual--;
                    Console.WriteLine($"O veículo {placaUpper} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Número de horas inválido. Certifique-se de digitar um número inteiro não negativo.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (capacidadeAtual > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < capacidadeAtual; i++)
                {
                    if (veiculos[i] != null)
                    {
                        Console.WriteLine(veiculos[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public string UltimaPlacaAdicionada => ultimaPlacaAdicionada; // Propriedade para acessar a última placa adicionada
    }
}
