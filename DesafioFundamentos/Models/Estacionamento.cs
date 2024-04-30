namespace DesafioFundamentos.Models

{
    using System.Text.RegularExpressions;

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        private static bool ValidarPlaca(string placa)
        {
            Regex regexPlaca = new Regex(@"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
            return regexPlaca.IsMatch((placa));
        }

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
            string veiculo = Console.ReadLine();
            veiculo = veiculo.ToUpper();

            if (ValidarPlaca(veiculo))
            {
                veiculos.Add(veiculo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("== Veículo estacionado com sucesso! ==");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("== Digite uma placa válida! ==");
                Console.ResetColor();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*

                decimal horas;
                while (!decimal.TryParse(Console.ReadLine(), out horas))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("== Hora inválida, para quantidades quebradas utilize a vírgula. Ex: 1h30 => 1,5 ");
                    Console.ResetColor();
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                Console.ResetColor();
            }


            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "== Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente! ==");
                Console.ResetColor();
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
                foreach (var veiculo in veiculos.Select((value, i) => (value, i)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"== Vaga nº {veiculo.i + 1}, placa -> {veiculo.value}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("== Não há veículos estacionados. ==");
                Console.ResetColor();
                
            }
        }
    }
}