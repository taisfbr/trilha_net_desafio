using DesafioFundamentos.Models;

namespace ParkingTestes;

public class ParkingTests
{
    [Fact]
    public void AdicionarVeiculo_ShouldAddVehicle_WhenPlateIsValid()
    {
        var parking = new Parking(5, 2);
        Console.SetIn(new StringReader("Carro\nAAA00AA"));
        
        parking.AddVehicle();
        
        Assert.True(parking.vehicles.ContainsKey("AAA00AA"));
        Assert.Equal("Carro", parking.vehicles["AAA00AA"]);
    }

    [Fact]
    public void AdicionarVeiculo_ShouldNotAddVehicle_WhenPlateIsInvalid()
    {
        var parking = new Parking(5, 2);
        Console.SetIn(new StringReader("Carro\nINVALID"));
        
        parking.AddVehicle();
        
        Assert.False(parking.vehicles.ContainsKey("INVALID"));
    }

    [Fact]
    public void RemoverVeiculo_ShouldRemoveVehicle_WhenPlateExists()
    {
        var parking = new Parking(5, 2);
        parking.vehicles.Add("AAA00AA", "Carro");
        Console.SetIn(new StringReader("AAA00AA\n2"));
        
        parking.RemoveVehicle();
        
        Assert.False(parking.vehicles.ContainsKey("AAA00AA"));
    }

    [Fact]
    public void RemoverVeiculo_ShouldNotRemoveVehicle_WhenPlateDoesNotExist()
    {
        var parking = new Parking(5, 2);
        Console.SetIn(new StringReader("AAA00AA\n2"));
        
        parking.RemoveVehicle();
        
        Assert.Empty(parking.vehicles);
    }

    [Fact]
    public void ListarVeiculos_ShouldListVehicles_WhenVehiclesExist()
    {
        var parking = new Parking(5, 2);
        parking.vehicles.Add("AAA00AA", "Carro");
        parking.vehicles.Add("BBB11BB", "Moto");
        
        var output = new StringWriter();
        Console.SetOut(output);
        
        parking.GetAllvehicles();
        
        var result = output.ToString();
        Assert.Contains("Modelo:Carro  -  Placa: AAA00AA", result);
        Assert.Contains("Modelo:Moto  -  Placa: BBB11BB", result);
    }

    [Fact]
    public void ListarVeiculos_ShouldDisplayNoVehicles_WhenNoVehiclesExist()
    {
        var parking = new Parking(5, 2);
        
        var output = new StringWriter();
        Console.SetOut(output);
        
        parking.GetAllvehicles();
        
        var result = output.ToString();
        Assert.Contains("Não há veículos estacionados.", result);
    }
}