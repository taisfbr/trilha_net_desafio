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
            // Pede para o usuário digitar a placa do veículo e já armazena com todas as letras maiúsculas
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            if(placa.Length != 7 || string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Quantidade de digitos digitados é menor ou mais que 7 ou possui espaços, tente novamente");
            }

            else
            {
                if(veiculos.Contains(placa))
                {
                    Console.WriteLine("Veículo já está estacionado");
                }

                else
                {
                    veiculos.Add(placa);
                }
            }
                

            
        }

        public void RemoverVeiculo()
        {
            // Pede para o usuário digitar a placa do veículo que deseja remover, transformando em Upper evitando erro de digitação
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();
            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                // Pede para o usuário digitar quantas horas o veículo permaneceu no estácionamento
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                // Converte o que for digitado de String para Int e realiza o calculo do valor total
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

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
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Laço para listar os veículos estacionados
                foreach(string veiculo in veiculos)
                {
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
