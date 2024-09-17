using System.Runtime.Intrinsics.Arm;

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
            
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. A placa não pode ser vazia.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se a placa foi fornecida
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. A placa não pode ser vazia.");
                return;
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                // Lê a quantidade de horas
                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Deve ser um número não negativo.");
                    return;
                }

                // Calcula o valor total
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // Remove o veículo da lista
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos estacionados:");
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo estacionado.");
                return;
            }

            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }
    }
}