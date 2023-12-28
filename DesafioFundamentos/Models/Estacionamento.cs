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
           /*Implementado - Treicho que solicita uma entrada da placa do veiculo 
           e inseri na lista de veiculos */

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);    
     
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            //Implementado - Treicho que solicita uma entrada da placa do veiculo
            string placa = Convert.ToString(Console.ReadLine());

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Implementado -  treicho que faz o calculo total do tempo do veiculo no estacionamento.
                int horas = 0;
                decimal valorTotal = 0; 

               horas = Convert.ToInt32(Console.ReadLine());

               valorTotal = precoInicial + (precoPorHora * horas);

               // Implementado - Trecho que remove o veiculo da lista pela placa
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
            //Console.WriteLine(veiculos.Count);
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                // Implementado - Trecho que faz a varredura na lista de veiculo por placa
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
