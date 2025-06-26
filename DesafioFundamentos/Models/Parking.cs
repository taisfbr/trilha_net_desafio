using DesafioFundamentos.Domain;
using DesafioFundamentos.Tools;

namespace DesafioFundamentos.Models
{
    public class Parking
    {
        private decimal startingPrice = 0;
        private decimal pricePerHour = 0;
        public Dictionary<string, string> vehicles = new Dictionary<string, string>();
        private string plate = "";

        public Parking(decimal startingPrice, decimal priceForHour)
        {
            this.startingPrice = startingPrice;
            this.pricePerHour = priceForHour;
        }

        public void AddVehicle()
        {
            var car = new Vehicle();
            Console.WriteLine("Digite a modelo do veículo para estacionar:");
            car.Model = Console.ReadLine();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            car.Plate = Console.ReadLine();
            if (!ValidateLicensePlate.IsValid(car.Plate))
            {
                Console.WriteLine("Placa inválida. A placa deve seguir o formato: AAA00AA");
                return;
            }
            vehicles.Add(car.Plate, car.Model);
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            plate = Console.ReadLine();
            if (!ValidateLicensePlate.IsValid(plate))
            {
                Console.WriteLine("Placa inválida. A placa deve seguir o formato: AAA00AA");
            }
            try
            {
                var car = vehicles[plate];
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                var hoursOfStay = Console.ReadLine();
                var amountToPay = CalculatePricePerHour(hoursOfStay);
                Console.WriteLine($"O veículo {plate} foi removido e o preço total foi de: R$ {amountToPay}");
                vehicles.Remove(plate);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Console.WriteLine($"[LOG] Erro ao remover veículo: {e.Message}");
                return;
            }
        }

        private decimal CalculatePricePerHour(string hoursOfStay)
        {
            return startingPrice + (pricePerHour * Convert.ToDecimal(hoursOfStay));
        }
        
        public void GetAllvehicles()
        {
            if (vehicles.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var car in vehicles)
                {
                   Console.WriteLine($" Modelo:{car.Value}  -  Placa: {car.Key}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
