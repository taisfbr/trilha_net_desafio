//log Atualizado: 18/07/2025 01:49 AM


using DesafioFundamentos.Models;
using System;

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
            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");//Valor não pode ser NULL
                placa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(placa)) //É responsavel por verificar se o valor é null ou se tem espaços vazios
                {
                    Console.WriteLine("Placa Digitada está em branco, Digite Novamente");
                }
            } while (string.IsNullOrWhiteSpace(placa));

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())) // Deixa valores la lista veiculos e placa digitada em maiusculo e compara se ja existe cadastro
            {
                Console.WriteLine($"O veiculo com a placa:{placa} já está estacionada"); //caso a placa digitada ja estiver estacionada exibe essa mensagemm
            }
            else
            {
                veiculos.Add(placa.ToUpper());// adiciona a placa a lista veiculos
                Console.WriteLine($"Veiculo de placa: {placa.ToUpper()} adicionado com Sucesso!!");
            }
        }

        public void RemoverVeiculo()
        {
            string placa;

            Console.WriteLine("Digite a placa do veículo para remover:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("| Placas Estacionadas |");
            Console.WriteLine("-----------------------");
            foreach (string veiculo in veiculos)
            {
                Console.WriteLine($"|  Placa - {veiculo}  |");
            }
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            do
            {
                Console.WriteLine("\n Qual veiculo deseja Remover? ");
                placa = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(placa))
                {
                    Console.WriteLine("A placa digitada esta em branco,por favor tente novamente");
                }
            } while (string.IsNullOrWhiteSpace(placa));
            

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                string inputHoras;
                bool entradaHorasValida = false;
                decimal valorTotal = 0;

                do //achei melhor tentar uma maneira de validar a entrada de horas
                {
                    Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");
                    inputHoras = Console.ReadLine();
                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    //validar entrada de horas
                    entradaHorasValida = int.TryParse(inputHoras, out horas);

                    //validar se valor é = 0 ou menor, para que o sistem consiga barrar esses valores
                    if (!entradaHorasValida || horas <= 0)
                    {
                        Console.WriteLine("a quantidade de horas Digitada não pode ser vazia, 0 ou negativo, Tente novamente");
                    }

                } while (!entradaHorasValida || horas <= 0);//Continuara o loop até o valor digitado ser superior a 0

                    

                

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*  
                decimal valorHorasParadas = horas * precoPorHora;
                valorTotal = precoInicial + horas * precoPorHora;


                Console.WriteLine($"\nDetalhes Valor Cobrado ");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Preço Inicial: R$ {precoInicial}");
                Console.WriteLine($"{horas} Horas X R${precoPorHora} Por Hora : R$ {valorHorasParadas}");
                Console.WriteLine($"\nTotal Cobrado: R${valorTotal}");
                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"\nO veículo {placa.ToUpper()} foi removido ");
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
                Console.WriteLine("------------------------");
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine("------------------------");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                int Contador = 0;

                foreach (string veiculo in veiculos)
                {

                    Console.WriteLine($"Placa - {veiculo} \nLocal nº - {Contador} ");
                    Console.WriteLine("=======================");
                    Contador++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
