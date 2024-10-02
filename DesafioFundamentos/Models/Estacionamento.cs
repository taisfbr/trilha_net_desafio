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

        public void AdicionarVeiculo()
        {
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placaVeiculo = Console.ReadLine();
               
            veiculos.Add(placaVeiculo);                    

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placaVeiculoRemover = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placaVeiculoRemover.ToUpper()))
            {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

          
            int horas;
            while (true) 
            {   
            string entradaHoras = Console.ReadLine();

            if (int.TryParse(entradaHoras, out horas) && horas >= 0)
                {
                break;
                }
            else
                {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido para as horas:");
                }
            }       
                decimal precoInicial = 5;   
                int precoPorHora = 2;
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                              
                veiculos.Remove(placaVeiculoRemover);
                Console.WriteLine($"O veículo {placaVeiculoRemover} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach(string item in veiculos)
                {
                    Console.WriteLine(item);
                }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
