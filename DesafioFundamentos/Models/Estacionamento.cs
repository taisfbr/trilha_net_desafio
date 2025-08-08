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
            // Solicita ao usuário a placa e adiciona à lista de veículos
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            // Armazena a placa sempre em maiúsculas para padronização
            veiculos.Add(placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Solicita ao usuário a placa do veículo a ser removido
            string placa = Console.ReadLine();

            // Verifica se o veículo existe na lista (ignorando maiúsculas/minúsculas)
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                int horas = 0;
                decimal valorTotal = int.TryParse(Console.ReadLine(), out horas);
            //Verifica o valor total e impede que 0 seja um número válido
                if (!valorTotal || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Operação cancelada.");
                    return;
                }
                // Calcula o valor total a ser pago
                decimal valorTotal = precoInicial + precoPorHora * horas;
                // Remove a placa da lista de veículos
                veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Exibe todos os veículos estacionados, se houver
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
