using System.Text.RegularExpressions;

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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = "";

            while (placa != "0")
            {
                placa = Console.ReadLine();
                if (placa == "0")
                    break;
                placa = placa.Trim().Replace("-", "").ToUpper();
                if (ValidarPlaca(placa))
                {
                    veiculos.Add(placa);
                    break;
                }
            }
            bool ValidarPlaca(string placa)
            {
                if (veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Placa já inclusa, digite uma nova placa, ou '0' para voltar.");
                    return false;
                }
                Regex regex = new Regex(@"^[A-Z]{3}[0-9]{4}$|^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$");
                if (!regex.IsMatch(placa))
                {
                    Console.WriteLine("Placa inválida, digite novamente a placa correta, ou '0' para voltar.");
                    return false;
                }
                return true;
            }
        }
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();
            placa = placa.Trim().Replace("-", "").ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos                
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {FormatarPlaca(placa)} foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
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
                foreach (var veiculo in veiculos)
                    Console.WriteLine(FormatarPlaca(veiculo));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }            
        }
        public string FormatarPlaca(string placa)
        {
            // TODO: caso for uma placa normal coloca hifen,se não "espaço"
            if (Char.IsDigit(placa[4]))
                return $"{placa.Substring(0, 3)}-{placa.Substring(3, 4)}";
            else
                return $"{placa.Substring(0, 3)} {placa.Substring(3, 4)}";
        }
    }
}
