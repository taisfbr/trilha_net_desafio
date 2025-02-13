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
            veiculos.Add(Console.ReadLine()); //Adiciona a placa do veículo na lista de veículos a partir da entrada do usuário
            Console.WriteLine($"Veículo placa {(veiculos.Last()).ToUpper()} adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo que irá deixar o estacionamento:");
            string placa = Console.ReadLine(); // Lê a placa do veículo a ser removido

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine($"Digite a quantidade de horas que o veículo de placa {placa.ToUpper()} permaneceu estacionado:");
                
                int horas;

                while (!int.TryParse(Console.ReadLine(), out horas))
                {
                    Console.WriteLine("Valor inválido. Digite um número inteiro para as horas:");
                }
                
                decimal valorTotal = precoInicial + precoPorHora * horas; // Calcula o valor total a ser pago

                veiculos.Remove(placa); // Remove o veículo da lista de veículos
                
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total cobrado foi de: R$ {valorTotal}");
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
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"O {veiculos.IndexOf(veiculo)+1}° veículo estacionado é o de placa {veiculo.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
