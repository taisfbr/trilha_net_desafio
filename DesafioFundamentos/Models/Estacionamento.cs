using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Models
{
    public class Estacionamento
    {
        // private decimal valorFixo = 0;
        // private decimal valorVariavel = 0;
        private List<string> veiculos = new List<string>();

        private string placa;
      

        // public Estacionamento (decimal valorFixo, decimal valorVariavel){
        //     this.valorFixo = valorFixo;
        //     this.valorVariavel = valorVariavel;
        // }

        public void AdicionarVeiculo(){
            Console.WriteLine ("Digite a placa do veiculo para adiciona-la ao estacionamento: ");
            placa = Console.ReadLine();
            veiculos.Add(placa);
        }

        public void RemoverVeiculo(){
            Console.WriteLine ("Digite a placa do veiculo que vc deseja remover: ");
            string placaRemove = Console.ReadLine();
    

            if (veiculos.Any(x => x.ToUpper() == placaRemove.ToUpper())){

                    int horas = 0;
                    int valorTotal = 5;
                    
                    Console.WriteLine ("Digite a quantidade de horas que o veiculo permaneceu estacionado: ");
                    horas = Convert.ToInt32(Console.ReadLine());

                    valorTotal += horas;


                    veiculos.Remove(placaRemove);
                    Console.WriteLine ($"O veiculo da placa: {placaRemove} foi removido e o preço total foi de R${valorTotal}");
            }
            else{
                Console.WriteLine ("Desculpe, esse veiculo nao esta estacinado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos (){
            if (veiculos.Any()){
                Console.WriteLine ("Os veiculos estacionados são: ");

                for (int i = 0; i < veiculos.Count; i++){
                    Console.WriteLine ($"{i}º Veiculo a entrar no estacionamento é o {veiculos[i]}");
                }
               
            } else {
                    Console.WriteLine ("Nao ha veiculos estacionados");
                }
        }
    }
}