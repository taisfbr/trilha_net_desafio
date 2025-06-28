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
            // *IMPLEMENTADO
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();
            veiculos.Add(placa);

            Console.WriteLine($"o Veículo com a placa {placa} foi adicionado");
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            // *IMPLEMENTADO

            string placa = Console.ReadLine();
           
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");                
                // *IMPLEMENTADO
                int horas = Convert.ToInt32(Console.ReadLine());;
                decimal valorTotal = precoInicial + (precoPorHora * horas);


                veiculos.Remove(placa);
                // *IMPLEMENTADO*

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
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (String n in veiculos)
                {
                    Console.WriteLine(n);
                 }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
