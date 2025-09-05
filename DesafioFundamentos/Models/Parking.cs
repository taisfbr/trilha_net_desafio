namespace DesafioFundamentos.Models
{
    public class Parking
    {
        private decimal initialPrice = 0;
        private decimal pricePerHour = 0;
        private List<string> vehicles = new List<string>();

        public Parking(decimal initialPrice, decimal pricePerHour)
        {
            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
        }

        public void AddVehicle()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Enter the vehicle license plate number to park:");
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Enter the vehicle license plate to remove:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string plate = "";

            // Verifica se o veículo existe
            if (vehicles.Any(x => x.ToUpper() == plate.ToUpper()))
            {
                Console.WriteLine("Enter the number of hours the vehicle was parked:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int hours = 0;
                decimal totalValue = 0; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"The vehicle {plate} was removed and the total price was: R$ {totalValue}");
            }
            else
            {
                Console.WriteLine("Sorry, this vehicle is not parked here. Please check that you have entered the license plate number correctly.");
            }
        }

        public void ListVehicles()
        {
            // Verifica se há veículos no estacionamento
            if (vehicles.Any())
            {
                Console.WriteLine("Parked vehicles are:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("There are no parked vehicles.");
            }
        }
    }
}
