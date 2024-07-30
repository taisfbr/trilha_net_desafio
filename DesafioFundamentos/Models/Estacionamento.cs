using trilha_net_fundamentos_desafio.DesafioFundamentos.Models;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Carro> veiculos = new List<Carro>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(new Carro(placa));
            Console.WriteLine("Registrado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Selecione a placa do veículo para remover:");

            ListarVeiculos();

            int index = Convert.ToInt32(Console.ReadLine());

            var placa = BuscarPlaca(index);

            SetSaidaDoVeiculo(placa);

            var horas = veiculos[index].Saida.Subtract(veiculos[index].Entrada).TotalMinutes;
            horas = Math.Round(horas, 0);
            var valorTotal = precoInicial + precoPorHora * (decimal)horas;

            veiculos.RemoveAt(index);
            
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        private string BuscarPlaca(int indexDaPlaca)
        {
            var veiculoDesejado = veiculos[indexDaPlaca].Placa;        
            return veiculoDesejado;
        }

        private void SetSaidaDoVeiculo(string placa)
        {
            veiculos.Find(x => x.Placa == placa).Saida = DateTime.Now;
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i} - {veiculos[i].Placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
