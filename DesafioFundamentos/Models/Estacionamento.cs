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
            string placa = Console.ReadLine().Trim();
            placa = placa.ToUpper();

            if (!PlacaValida(placa))
            {
                Console.WriteLine("Placa inválida, tente novamente");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Desculpe, esse veículo já está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }

            veiculos.Add(placa);

            Console.WriteLine($"O veículo {placa} foi estacionado com sucesso!");
        }

        static bool PlacaValida(string placa)
        {
            if (placa.Length != 8)
            {
                return false;
            }

            if (placa[3] != '-')
            {
                return false;
            }

            if (!char.IsLetter(placa[0]) || !char.IsLetter(placa[1]) || !char.IsLetter(placa[2]))
            {
                return false;
            }

            if (!char.IsDigit(placa[4]) || !char.IsDigit(placa[6]))
            {
                return false;
            }

            return true;
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().Trim();

            if (!PlacaValida(placa))
            {
                Console.WriteLine("Placa inválida, tente novamente");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string tempo = Console.ReadLine().Trim();

                if (!int.TryParse(tempo, out int horas))
                {
                    Console.WriteLine("Horas inválidas, tente novamente");
                    return;
                }

                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    horas = int.Parse(tempo);
                    decimal valorTotal = (horas * precoPorHora) + precoInicial;

                    veiculos.Remove(placa.ToUpper());

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:C}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
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
