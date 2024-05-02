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
            var placa = ObterValorTexto("Digite a placa do veículo para estacionar:");
            
            if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo {placa} adicionado com sucesso");
            }
            else
            {
                Console.WriteLine($"Desculpe, não foi possível adicionar esse veículo. Motivo: já existe um veículo com a placa {placa} estacionado.");
            }            
        }

        public void RemoverVeiculo()
        {
            var placa = ObterValorTexto("Digite a placa do veículo para remover:");

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = ObterValorNumerico("Digite a quantidade de horas que o veículo permaneceu estacionado:");
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
                foreach (string veiculo in veiculos) 
                {
                    Console.WriteLine($"Placa: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string ObterValorTexto(string mensagemExibicaoUsuario)
        {
            bool entradaValida = false;
            string valor = string.Empty;
            
            while (!entradaValida)
            {
                Console.WriteLine(mensagemExibicaoUsuario);
                valor = Console.ReadLine();

                if(!String.IsNullOrEmpty(valor))
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Valor inválido, digite um novo valor");
                }
            }
            return valor;
        }

        private int ObterValorNumerico(string mensagemExibicaoUsuario)
        {
            bool entradaValida = false;
            int valor = 0;

            while (!entradaValida)
            {
                Console.WriteLine(mensagemExibicaoUsuario);
                
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Valor inválido, digite um novo valor");
                }
            }
            return valor;
        }
    }
}
