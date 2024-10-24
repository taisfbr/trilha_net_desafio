namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        // O metodo contrutor e responsavel por inicializar os atributos da classe toda vez que e instanciada ou criado um objeto da classe
        /// <summary>
        /// Metodo Construtor da Classe Estacionamento
        /// </summary>
        /// <param name="precoInicial"></param>
        /// <param name="precoPorHora"></param>
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }


        /// <summary>
        /// Metodo Responsavel por adicionar um veiculo na lista de veiculos estacionados
        /// </summary>
        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaInput = Console.ReadLine();
            veiculos.Add(placaInput);
        }

        /// <summary>
        /// Metodo Responsavel por remover o veiculo da realação de veiculos estacionados
        /// </summary>
        public void RemoverVeiculo()
        {
            int horas = 0;
            decimal valorTotal = 0;


            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");

                //OK // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                while (true)
                {
                    // Verifica se o valor digitado é um número
                    if (int.TryParse(Console.ReadLine(), out horas))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite um valor válido");
                    }
                }


                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                valorTotal = (precoInicial + precoPorHora) * horas;

                // TODO: Remover a placa digitada da lista de veículos
                /* Exitem duas opções para remoção de um item de uma lista 
                 * 1 E utilizar o metodo herdado do LINQ que e o Remove() passando o objeto que deseja remover como parametro
                 * 2 Ou Porcorrer com o laço de repetição e remover o item que deseja utilizando o metodo RemoveAt() passando a posição do item como parametro no metodo
                 */
                //veiculos.Remove(placa);
                for (int i=0;veiculos.Count()>i;i++)
                {
                    if (veiculos[i] == placa)
                    {
                        veiculos.RemoveAt(i);
                    }

                }

                Console.WriteLine($"\nO veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        /// <summary>
        /// Metodo Responsavel por listar os veiculos estacionados
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("\nOs veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // Nesse caso e so utilizar o foreach para percorrer a lista de veiculos e exibir cada item
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"\n - {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}
