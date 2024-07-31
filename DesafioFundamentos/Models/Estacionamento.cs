namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar:");
            Veiculo veiculo = new(Console.ReadLine());
            veiculos.Add(veiculo);
            veiculo.Entrada = DateTime.Now;

            Console.WriteLine(GerarTicketEntrada(veiculo));
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {

                Veiculo veiculo = veiculos.Find(x => x.Placa.ToUpper() == placa.ToUpper());
                veiculos.Remove(veiculo);
                veiculo.Saida = DateTime.Now;

                Console.WriteLine(GerarTicketSaida(veiculo));

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
                Horario Entrada: {veiculo.Entrada}
                Valor fixo de entrada: {precoInicial}
                Valor por hora: {precoPorHora}
                ";
        }

        private string GerarTicketSaida(Veiculo veiculo)
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            //decimal horas = (decimal)(veiculo.Saida - veiculo.Entrada).TotalHours;
            int horasMock = Convert.ToInt32(Console.ReadLine());
            decimal valorTotal;

            valorTotal = precoInicial + (precoPorHora * horasMock);

            return $@" 
                -------------------- TICKET ------------------------
                ----------------- Volte Sempre !--------------------
                ----------------------------------------------------
                Veiculo de placa: {veiculo.Placa} 
                Horario Entrada:{veiculo.Entrada}
                Horario Saida: {veiculo.Entrada.AddHours(horasMock)}
                Valor por hora: {precoPorHora}
                Valor Total: {valorTotal}
                ";
        }
    }
}
