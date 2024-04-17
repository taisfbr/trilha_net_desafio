
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

        public void AdicionarVeiculo(){
            Console.WriteLine("Por favor, digite a placa do veículo que deseja estacionar:");
            string placa = Console.ReadLine();
            if(ValidarPlacaBrasil(placa)){
                Console.WriteLine("Carro autorizado a estacionar!");
                veiculos.Add(placa);
            }
            else{
                Console.WriteLine("Placa inválida para estacionamento no Brasil!");
            }
        }
        static bool ValidarPlacaBrasil(string placa){
            if(placa.Length != 7){
                return false;
            }
            
            for (int i = 0; i < 3; i++){
                if (!char.IsLetter(placa[i])){
                    return false;
                }
            }
            for (int i = 3; i < 7; i++){
                if (!char.IsDigit(placa[i])){
                    return false;
                }
            }
            return true;
    }

        public void RemoverVeiculo(){
            Console.WriteLine("Por favor, digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())){
                Console.WriteLine("Por favor, digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                int index = veiculos.IndexOf(placa);
                veiculos.RemoveAt(index);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else{
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos(){
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()){
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string v in veiculos){
                    Console.WriteLine(v);
                }
            }
            else{
                Console.WriteLine("Não há veículos estacionados!");
            }
        }

        //Funcao que verifique qual a vaga que o carro esta estacionado
        public void VerificarVaga(string placa){
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())){
                int index = veiculos.IndexOf(placa);
                Console.WriteLine($"O veículo {placa} está na vaga {index + 1}");
            }
            else{
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }
    }
}
