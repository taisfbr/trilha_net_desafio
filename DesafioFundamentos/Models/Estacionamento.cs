using System.Security.Cryptography.X509Certificates;
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
            // *IMPLEMENTE AQUI
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Replace("-","").Trim();
            // transforma o - em sem espaço para facilitar a validação

            if(ValidarPlaca(placa))// chama o metodo ValidarPlaca() e faz a verificação com Regex
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa}, foi adicionado com sucesso.");
            }else
            {
                Console.WriteLine("Placa inválida");
            } 
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine(" Digite a placa do veículo para remover:");
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // FEITO!!
                int cont = 0;
                foreach (string carro in veiculos)
                {
                    Console.WriteLine($"| Veiculo N:{cont} - {carro}         |");
                    cont++;
                }
             string placa = Console.ReadLine();


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // FEITO!!
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = 0; 
                valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos
                // FEITO!!
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
                // FEITO!!
                int cont = 0;
                foreach (string carro in veiculos)
                {
                    Console.WriteLine($"| Veiculo N:{cont} - {carro}         |");
                    cont++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool  ValidarPlaca(string placa)
        {
            
            if (string.IsNullOrWhiteSpace(placa)) return false;// verifica se os caracteres são null, vazio ou espaços
            
            var placaNormal = new Regex("^[a-zA-Z]{3}[0-9]{4}$"); // conjunto de caracteres para verificar
            return placaNormal.IsMatch(placa); // não entendi direito, aparentemente ele verifica se o que foi digitado está corespondente com o regex


        }
 }
}
