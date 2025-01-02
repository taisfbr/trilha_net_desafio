using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Welcome to the parking system:\nEnter the starting price:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Type the hourly rate:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
var es = new ParkingModel(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Type one of this options:");
    Console.WriteLine("1 - Add new vehicle");
    Console.WriteLine("2 - Remove vehicle");
    Console.WriteLine("3 - List all vehicles");
    Console.WriteLine("4 - Report System");
    Console.WriteLine("5 - Logout");

    switch (Console.ReadLine())
    {
        case "1":
            es.AddNewVehicle();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.SeeAllVehicles();
            break;

        case "4":
            es.GetAnalysis();
            break;

        case "5":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Invalid Option!");
            break;
    }

    Console.WriteLine("Press [ENTER] to continue");
    Console.ReadLine();
}

Console.WriteLine(" --- PARKING SYSTEM IS OVER ---");
