namespace DesafioFundamentos.Models
{
    
    using System.Text.RegularExpressions;

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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()!.ToUpper();
            if (VerificarSeVeiculoCadastrado(placa))
            {
                Console.WriteLine("Veículo já está cadastrado no sistema.");
            }
            else
            {
                ValidarPlacaMercoSul(placa);
            }
        }


    public void RemoverVeiculo()
        {
            bool exibirSubMenu = true;
            while (exibirSubMenu)
            {
                Console.Clear();
                Console.WriteLine("1 - Exibir Veículos que estão no estacionamento");
                Console.WriteLine("2 - Remover Veículo");
                Console.WriteLine("3 - Voltar ao Menu Principal");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListarVeiculos();
                        break;
                    case "2":

                        ListarVeiculosComIndice();

                        Console.WriteLine("Digite o número do veículo que deseja remover:");
                        int indice = int.Parse(Console.ReadLine()!) - 1;

                        if (indice >= 0 && indice < veiculos.Count)
                        {
                            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                            int horas = int.Parse(Console.ReadLine()!);
                            string veiculoRemovido = veiculos[indice];
                            veiculos.RemoveAt(indice);
               
                            decimal valorTotal = precoInicial + (precoPorHora * horas);
                            Console.WriteLine($"O veículo {veiculoRemovido} foi removido e o preço total foi de: R$ {valorTotal}");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido.");
                        }
                        break;
                    case "3":
                        exibirSubMenu = false;
                        continue;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ListarVeiculosComIndice()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos no estacionamento.");
                return;
            }

            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {veiculos[i]}");
            }
        }

        public bool VerificarSeVeiculoCadastrado(String placa)
        {
            if (veiculos.Contains(placa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ValidarPlacaMercoSul(string placa)
        {
            string padraoPlaca = @"^[A-Z]{3}-?\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$";
            if (!Regex.IsMatch(placa, padraoPlaca))
            {
                Console.WriteLine("Placa inválida! Digite uma placa no formato ABC-1234 ou ABC1D23.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo {placa} adicionado com sucesso!");
            }
        }

    }
}
