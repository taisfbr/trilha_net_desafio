using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private readonly decimal precoInicial = 0;
    private readonly decimal precoPorHora = 0;
    private readonly List<string> veiculos = new();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
      this.precoInicial = precoInicial;
      this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para estacionar:");
      string placa = Console.ReadLine();
      veiculos.Add(placa);
      Console.WriteLine($"Veículo com placa {placa} adicionado.");
    }

    public void RemoverVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");
      string placa = Console.ReadLine();

      if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
        {
          decimal valorTotal = precoInicial + precoPorHora * horas;
          veiculos.Remove(placa.ToUpper());
          Console.WriteLine($"O veículo com a placa {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
          Console.WriteLine("Quantidade de horas inválida. Tente novamente.");
        }
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
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
  }
  
}
