using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        //Atributos com readonly para garantir sua imutabilidade. Garante que os valores não sejam reatribuídos depois de inicializados.
        private readonly decimal precoInicial = precoInicial;
        private readonly decimal precoPorHora = precoPorHora;
        private readonly List<string> veiculos = [];

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();
            // Validando se Input é vazio:
            if (placa == null) {
                Console.WriteLine($"Valor vazio! Use o padrão Mercosul, exemplo ABC1D23.");
            } else {
                // Expressão regular para validar placa do Mercosul:
                string pattern = @"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$";
                bool isMatch = Regex.IsMatch(placa, pattern);
                if (!isMatch) {
                    Console.WriteLine($"Placa inválida! Valor fora do padrão Mercosul, exemplo ABC1D23.");
                } else {
                    //Confirmando valor da placa:
                    Console.WriteLine($"A placa está correta? *{placa}*. Digite 's'(sim) ou 'n'(não).");
                    string? response = Console.ReadLine();
                    if (response != null) {
                        response = response.ToLower();
                        switch (response) {
                            case "s":
                                if (veiculos.Contains(placa)) {
                                    Console.WriteLine($"Veículo com placa *{placa}* já estacionado! Placa clonada! A policia foi acionada!!!");
                                } else {
                                    veiculos.Add(placa.ToUpper());
                                    Console.WriteLine("Veículo estacionado com sucesso!");
                                }
                                break;

                            case "n":
                                break;

                            default:
                                Console.WriteLine("Opção inválida. Digite somente 's' ou 'n'.");
                                break;
                        }
                    } else {
                        Console.WriteLine("Valor vazio é inválido!");
                    }
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string? placa = Console.ReadLine();
            if (placa == null) {
                Console.WriteLine($"Placa inválida! Valor vazio, use o padrão Mercosul, exemplo ABC1D23.");
            } else {
                // Verifica se o veículo existe
                if (veiculos.Any(x => string.Equals(x, placa, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    decimal horas = Convert.ToDecimal(Console.ReadLine());
                    // calculando valor total do estacionamento:
                    decimal valorTotal = precoInicial + precoPorHora * horas; 

                    //Remover a placa digitada da lista de veículos
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:0.00}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (string item in veiculos) {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo estacionado!");
            }
        }
    }
}
