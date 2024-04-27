namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> _veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            _veiculos.Add(Console.ReadLine());
        }

        public string RemoverVeiculo()
        {
            string placa = "";
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();
            if (_veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                _veiculos.Remove(placa);
                return placa;
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return "";
            }
        }
        public void RetirarVeiculo()
        {
            int horas = 0;
            decimal valorTotal = 0;
            string placa = "";

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            string input = Console.ReadLine();

            if (VerificarHora(input, out horas))
            {
                valorTotal = horas * _precoPorHora;
                placa = RemoverVeiculo();
                if (!string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }

            }

        }
        public void ListarVeiculos()
        {
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool VerificarHora(string input, out int inputParsed)
        {
            if (Int32.TryParse(input, out inputParsed) && inputParsed != 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Numero de Horas invalido");
                return false;
            }
        }
    }
}
