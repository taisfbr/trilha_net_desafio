using DesafioFundamentos.Helper;

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
            ConsoleHelper.LogInformacao("Digite a placa do veículo para estacionar:");

            var placaVeiculo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placaVeiculo))
            {
                ConsoleHelper.LogErro("Placa informada inválida!");
                return;
            }

            if (veiculos.Exists(_ => _.ToUpper() == placaVeiculo.ToUpper()))
                ConsoleHelper.LogAtencao("Placa do veículo ja registrada!");
            else
                veiculos.Add(placaVeiculo);
        }

        public void RemoverVeiculo()
        {
            ConsoleHelper.LogInformacao("Digite a placa do veículo para remover:");

            var placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                ConsoleHelper.LogErro("Placa informada inválida!");
                return;
            }

            var veiculo = veiculos.FirstOrDefault(_ => string.Equals(_ == placa, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(veiculo))
            {
                ConsoleHelper.LogInformacao("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (!int.TryParse(Console.ReadLine(), out var horas))
                {
                    ConsoleHelper.LogErro("Valor Inválido");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                ConsoleHelper.LogSucesso($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}\"");
            }

            else ConsoleHelper.LogAtencao("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                ConsoleHelper.LogInformacao("Os Veículos estacionados sao:");
                ConsoleHelper.LogInformacao("----------------------------------------------------");

                foreach (var veiculo in veiculos)
                    ConsoleHelper.LogInformacao(veiculo);

                ConsoleHelper.LogInformacao("----------------------------------------------------");
            }

            else ConsoleHelper.LogAtencao("Não ha Veículos estacionados.");
        }
    }
}
