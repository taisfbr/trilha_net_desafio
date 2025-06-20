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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string novaPlaca = Console.ReadLine();
            veiculos.Add(novaPlaca);
            Console.WriteLine($"Veiculo com placa '{novaPlaca}' adicionado com sucesso");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaParaRemover = Console.ReadLine();
            // Pedir para o usuário digitar a placa e armazenar na variável placa
           


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placaParaRemover.ToUpper()))
            {

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {

                   

                    decimal valorTotal = (precoInicial + (precoPorHora * horas));


                    
                    veiculos.Remove(placaParaRemover);

                    Console.WriteLine($"O veículo {placaParaRemover} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Percorre a lista e exibe cada veículo
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Veículo {i + 1}: {veiculos[i]}");
                }
                // Outra forma de percorrer a lista (mais comum para Listas):
                // foreach (string veiculo in veiculos)
                // {
                //     Console.WriteLine($"- {veiculo}");
                // }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
