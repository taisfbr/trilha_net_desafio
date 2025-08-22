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
            Console.Write("Digite a placa do veículo: ");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nVeículo {placa} cadastrado com sucesso!");
            Console.ResetColor();
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo a ser removido: ");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas estacionadas: ");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placa);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nVeículo {placa} removido. Valor total: R$ {valorTotal:F2}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nVeículo não encontrado! Confira a placa digitada.");
                Console.ResetColor();
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Veículos atualmente estacionados:");
                Console.ResetColor();
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados no momento.");
            }
        }
    }
}
