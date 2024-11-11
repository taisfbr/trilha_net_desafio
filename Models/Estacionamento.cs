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
            //CHECK
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string tempcheck = Console.ReadLine().Trim(); //Trim para remover espaços

            if (string.IsNullOrEmpty(tempcheck) || string.IsNullOrWhiteSpace(tempcheck)) //Verifica se a placa e Null ou esta Vazia
            {
                Console.WriteLine("Placa inválida ou vazia!");
            }
            else if (veiculos.Contains(tempcheck)) //Verifica se a placa ja existe
            {
                Console.WriteLine("Essa placa ja existe!");
            }
            else
            {
                veiculos.Add(tempcheck);
            }
            //Não tenho suficiente experiência com o "Switch case" mais tenho certeza que esse código pode usar uma coisa mais eficiente do que "If, else if, else"
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            //CHECK
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                //CHECK

                try //Se o úsuario coloca um espaço ou letras no input o programa da erro
                {
                    int horas = Convert.ToInt32(Console.ReadLine());
                    if(horas >= 0) //O único carro que pode voltar ao passado é o Delorean, mais todos os carros podem ficar "0" horas no lote.
                    {
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    veiculos.Remove(placa);
                    }
                    else
                    {
                    Console.WriteLine("Só aceitamos números positivos, tente novamente.");
                    }
                }
                catch
                {
                    Console.WriteLine("Ups! Entrada inválida, por favor tente novamente."); //Erro génerico
                }
                finally
                {
                    Console.WriteLine("Voltando ao menu principal...");
                }
                // Prévia iteração, aqui cometí o erro de colocar espaço no input e me di conta da unhandled exception
                /*int horas = Convert.ToInt32(Console.ReadLine());
                if(horas > 0)
                {
                decimal valorTotal = precoInicial + precoPorHora * horas;
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                veiculos.Remove(placa);
                }
                else
                {
                    Console.WriteLine("Ups! Número inválido, tente novamente.\n Voltando ao menu principal...");
                }*/

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                // MOVIDO PARA CIMA DEVIDO A "UNHANDLED EXCEPTION" SE O USUÁRIO COLOCA ESPAÇO E PARA NAO PERMITIR NÚMEROS NEGATIVOS

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
                foreach(string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
