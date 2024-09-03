namespace DesafioFundamentos
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
            string placaMaiuscula = string.Empty;
            // TODO: FAZER A VERIFICAÇÃO DOS CARACTERES DA PLACA && Se já existe!
            // *IMPLEMENTE AQUI*
            Console.Clear();
            Console.WriteLine($"Digite a placa do veículo para estacionar: \n");
            placaMaiuscula = Console.ReadLine();
            placaMaiuscula = placaMaiuscula.ToUpper();
            veiculos.Add(placaMaiuscula);
            int indice = veiculos.Count() - 1;  
            
            
            

            Console.Clear();
            Console.WriteLine($"\n\n\n\nVocê estacionou o seu Carro com a Placa: {veiculos[indice]}");


        }

        public void RemoverVeiculo()
        {
            string placa = string.Empty;


            Console.Clear();
            Console.WriteLine($"Digite a placa do veículo para remover: \n");
            placa = Console.ReadLine();
            placa = placa.ToUpper();
            
            
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
            
                int horas = 0;
                Console.Clear();
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas; 

                veiculos.Remove(placa);
                
                Console.Clear();
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine($"\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.Clear();
                Console.WriteLine("Os veículos estacionados são: \n");

                int cont = 0;
                
                foreach (string carro in veiculos)
                {
                    Console.WriteLine($"Você tem estacionado na VAGA Nº: {cont} - {carro}");
                    cont++;
                }
            }
            else
            {
                Console.WriteLine($"\nNão há veículos estacionados.");
            }
        }
    }
}
