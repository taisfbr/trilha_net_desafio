namespace DesafioFundamentos.Domain;

public class Vehicle
{
    public string Model { get; set; }
    public string Plate { get; set; }

    public Vehicle( string model, string plate)
    {
        model = model;
        plate = plate;
    }

    public Vehicle()
    {
        
    }
}