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
            // *IMPLEMENTE AQUI*

            string? resultado;
            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = (Console.ReadLine() ?? "").ToUpper().Replace("-", "").Trim();
                resultado = VerificarPlaca(placa);
                Console.WriteLine(resultado);

                if (resultado != "Placa Válida")
                {
                    Console.WriteLine("Precione qualquer tecla e tente novamente");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    veiculos.Add(placa);
                }
            } while (resultado != "Placa Válida");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = (Console.ReadLine() ?? "").ToUpper().Replace("-", "").Trim();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0;

                while (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0)
                    Console.WriteLine("Entrada inválida! Digite um número inteiro positivo maior que zero.");

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                valorTotal = precoInicial + precoPorHora * horas;
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
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        
        public string VerificarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return "A placa não pode ser nula ou vazia.";

            if (placa.Length != 7)
                return "A placa deve conter exatamente 7 caracteres.";


            // Formato novo (Mercosul): ABC1D23
            int[] letras = new int[] { 0, 1, 2, 4 };
            int[] digitos = new int[] { 3, 5, 6 };

            bool formatoNovo = letras.All(i => char.IsLetter(placa[i])) &&
                            digitos.All(i => char.IsDigit(placa[i]));

            // Formato antigo: ABC1234
            bool formatoAntigo = placa.Substring(0, 3).All(char.IsLetter) &&
                                placa.Substring(3, 4).All(char.IsDigit);

            if (formatoNovo || formatoAntigo)
                return "Placa válida";

            return "Formato inválido. Use o padrão: ABC1234 ou ABC1D23";
        }
    }
}
