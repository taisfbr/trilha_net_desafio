namespace DesafioFundamentos.Models
{
    public class ParkingModel
    {
        private decimal initialPrice = 0;
        private decimal pricePerHour = 0;
        private List<VehicleModel> vehicles = new List<VehicleModel>();

        public ParkingModel(decimal precoInicial, decimal precoPorHora)
        {
            this.initialPrice = precoInicial;
            this.pricePerHour = precoPorHora;
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
                vehicles.Add(new VehicleModel(newPlate));
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

                decimal totalValue = initialPrice + (Decimal.Parse(stayHours) * pricePerHour);

                // ===== REMOVING THE VEHICLE
                var removedVehicle = vehicles.Find(v => v.Plate.ToUpper().Equals(removeThisPlate));
                vehicles = vehicles.FindAll(p => !p.Plate.Equals(removeThisPlate));

                // ===== SHOW THE VALUES AND THE PLACE IN TERMINAL
                Console.WriteLine($"DETAILS -----.\n🔵 Serial Plate: {removedVehicle.Plate}\n🔵 Total $:{totalValue}\n🔵 Start in: {removedVehicle.RegistedAt.ToString("yyyy-MM-dd HH:mm")}\n✅ Vehicle is removed");

            }
        }

        public void SeeAllVehicles()
        {

            if (vehicles.Any())
            {
                Console.WriteLine("🔵 All vehicles Parking in our parking:\n");
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - Vehicle: {vehicles[i].Plate}");
                }
                Console.WriteLine("-----------------");
            }
            else
            {
                Console.WriteLine("There are no parked vehicles.");
            }
        }


        public void GetAnalysis()
        {
            Console.WriteLine(" 📊 PARKING REPORT 📊");
            Console.WriteLine($" 🔵 Total Vehicles: {vehicles.Count}");
            Console.WriteLine($" 🔵 Price per Hour: ${pricePerHour}");
            Console.WriteLine($" 🔵 Starting Price: ${initialPrice}");
            Console.WriteLine($" 🚘 VEHICLES");
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i+1} - Vehicle: {vehicles[i].Plate} | Register At: ${vehicles[i].RegistedAt.ToString("yyyy-MM-dd HH:mm")}");
            }
            Console.WriteLine(" -----------------------");
        }


        /// <summary>
        /// Check if the new vehicle already added in our system
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        private bool AlreadyRegisteredVehicle(string plate)
        {
            bool registered = vehicles.FindIndex(x => x.Plate.ToUpper() == plate.ToUpper()) != -1; // != -1 meaning that exist
            return registered;
        }
    }
}
