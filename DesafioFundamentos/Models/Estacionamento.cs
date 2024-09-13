namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private readonly decimal precoInicial = precoInicial;
        private readonly decimal precoPorHora = precoPorHora;
        private readonly List<string> veiculos = [];

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaVeiculo = "";

            while(string.IsNullOrEmpty(placaVeiculo)) {
                placaVeiculo = Console.ReadLine();

                if (string.IsNullOrEmpty(placaVeiculo)) {
                    Console.WriteLine("Por favor, digite a placa do veículo!");
                }
            }

            veiculos.Add(placaVeiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            while(string.IsNullOrEmpty(placa)) {
                placa = Console.ReadLine();

                if (string.IsNullOrEmpty(placa)) {
                    Console.WriteLine("Por favor, digite a placa do veículo!");
                }
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int horasEstacionado = 0;
                horasEstacionado = Convert.ToInt32(Console.ReadLine());
                
                decimal valorTotal = 0;
                valorTotal = precoInicial + precoPorHora * horasEstacionado;

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
            // Verifica se há veículos no estacionamento
            if (veiculos.Count != 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos) {
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
