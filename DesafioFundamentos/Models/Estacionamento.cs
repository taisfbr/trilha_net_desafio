using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

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

        public void AdicionarVeiculo() // registra carro novo na lista veiculos
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Este veículo já está estacionado.");
                return;
            }
           
                veiculos.Add(placa);
                Console.WriteLine($"Veiculo placa {placa} foi adicionada ao estacionamento ");

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe (ignorando maiúsculas/minúsculas)
            string placaEncontrada = veiculos.FirstOrDefault(x => x.ToUpper() == placa.ToUpper());
            if (placaEncontrada == null)
            {
                Console.WriteLine("Erro: Veículo não encontrado no estacionamento.");
                return;
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
            {
                Console.WriteLine("Erro: Quantidade de horas inválida. Deve ser um número inteiro não negativo.");
                return;
            }

            decimal valorTotal = precoInicial + (precoPorHora * horas);

            veiculos.Remove(placaEncontrada);

            Console.WriteLine($"Veículo com placa {placaEncontrada} foi removido. Valor total cobrado: R${valorTotal:F2}");            

        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int indice = 1; 
                foreach (string placa in veiculos)
                {
                    Console.WriteLine($"{indice}. {placa}");
                    indice++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
