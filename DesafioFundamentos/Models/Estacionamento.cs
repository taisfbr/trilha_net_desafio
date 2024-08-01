using DesafioFundamentos.Exceptions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly List<Veiculo> veiculos = new();
        public decimal PrecoInicial { get; private set; }
        private decimal PrecoPorHora { get; set; }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar:");
            try
            {
                string placa = Console.ReadLine();
                string placaFormatada = "";

                if (!placa.Contains('-'))
                {
                    placaFormatada = Veiculo.FormatarPlaca(placa);
                }

                Veiculo veiculo = Veiculo.CriarVeiculo(placaFormatada);
                veiculos.Add(veiculo);
                veiculo.Entrada = DateTime.Now;
                Console.WriteLine(GerarTicketEntrada(veiculo));
            }
            catch (InvalidArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover: (LLL-NNNN)");
            string placa = Console.ReadLine();
            string placaFormatada = "";

            if (!placa.Contains('-'))
            {
                placaFormatada = Veiculo.FormatarPlaca(placa);
            }
            if (!Veiculo.ValidarPlaca(placaFormatada.ToUpper()))
            {
                Console.WriteLine("Placa inválida. O formato deve ser: LLL-NNNN!");
                return;
            }
            Veiculo veiculo = veiculos.FirstOrDefault(x => x.Placa.Equals(placaFormatada, StringComparison.OrdinalIgnoreCase));

            if (veiculo != null)
            {
                veiculo.Saida = DateTime.Now;
                //decimal horas = (decimal)(veiculo.Saida - veiculo.Entrada).TotalHours;
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string horasInput = Console.ReadLine();

                if (!int.TryParse(horasInput, out int horasMock) || horasMock < 0)
                {
                    Console.WriteLine("Entrada inválida para horas. Por favor, insira um número inteiro positivo.");
                    return;
                }

                Console.WriteLine(GerarTicketSaida(veiculo, horasMock));
                veiculos.Remove(veiculo);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos Estacionados: ");
                foreach (Veiculo carro in veiculos)
                {
                    Console.WriteLine($"placa: {carro.Placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string GerarTicketEntrada(Veiculo veiculo)
        {
            return $@" 
                -------------------- TICKET ------------------------
                ---------- Veiculo Cadastrado Com Sucesso ----------
                ----------------------------------------------------
                Veiculo de placa: {veiculo.Placa}  
                Data: {veiculo.Entrada.ToShortDateString()}
                Horario Entrada: {veiculo.Entrada.ToShortTimeString()}
                Valor fixo de entrada: {PrecoInicial:C}
                Valor por hora: {PrecoPorHora:C}
                ";
        }

        private string GerarTicketSaida(Veiculo veiculo, int horas)
        {
            decimal valorTotal = PrecoInicial + (PrecoPorHora * horas);

            return $@" 
                -------------------- TICKET ------------------------
                ----------------- Volte Sempre !--------------------
                ----------------------------------------------------
                Veiculo de placa: {veiculo.Placa} 
                Data: {veiculo.Entrada.ToShortDateString()}
                Horario Entrada:{veiculo.Entrada.ToShortTimeString()}
                Horario Saida: {veiculo.Entrada.AddHours(horas).ToShortTimeString()}
                Valor por hora: {PrecoPorHora:C}
                Valor Total: {valorTotal:C}
                ";
        }
    }
}
