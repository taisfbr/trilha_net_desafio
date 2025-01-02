namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal initialPrice = 0;
        private decimal priceForHour = 0;
        private List<string> vehicles = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.initialPrice = precoInicial;
            this.priceForHour = precoPorHora;
        }

        public void AddNewVehicle()
        {
            // ===== GET NEW LICENSE PLATE
            Console.WriteLine("Type a plate to adding into the parking:");
            string newPlate = Console.ReadLine();

            // ===== ALREADY REGISTERED?
            if (AlreadyRegisteredVehicle(newPlate))
            {
                Console.WriteLine("This vehicle is already parked in our system. Make sure you've entered the license plate correctly!");
            }
            else
            {
                vehicles.Add(newPlate);
                Console.WriteLine("✅ New vehicle added into the system ✅");
            }



        }

        public void RemoverVeiculo()
        {

            if (vehicles.Count == 0) Console.WriteLine("There are no parked vehicles to remove");
            else
            {
                Console.WriteLine("Type a plate to remove into the parking:");
                // Pedir para o usuário digitar a placa e armazenar na variável placa
                string removeThisPlate = Console.ReadLine();

                if (!AlreadyRegisteredVehicle(removeThisPlate))
                {
                    Console.WriteLine("Make sure you've entered the license plate correctly! This plate was no found.");
                    return;
                }

                // ===== YOU STAY HOW MANY TIME?
                Console.WriteLine("How long you stayed in the parking lot? (Type hours)");
                string stayHours = Console.ReadLine();

                decimal totalValue = initialPrice + (Decimal.Parse(stayHours) * priceForHour);

                // ===== REMOVING THE VEHICLE
                vehicles = vehicles.FindAll(p => !p.Equals(removeThisPlate));
                
                // ===== SHOW THE VALUES AND THE PLACE IN TERMINAL
                Console.WriteLine($"All done! Vehicle {removeThisPlate} is removed. Total value for our service: {totalValue}!");

            }
        }

        public void SeeAllVehicles()
        {

            if (vehicles.Any())
            {
                Console.WriteLine("🔵 All vehicles Parking in our parking:\n");
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - Vehicle: {vehicles[i]}");
                }
                Console.WriteLine("-----------------");
            }
            else
            {
                Console.WriteLine("There are no parked vehicles.");
            }
        }


        /// <summary>
        /// Check if the new vehicle already added in our system
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        private bool AlreadyRegisteredVehicle(string plate)
        {
            bool registered = vehicles.Any(x => x.ToUpper() == plate.ToUpper());
            return registered;
        }
    }
}
