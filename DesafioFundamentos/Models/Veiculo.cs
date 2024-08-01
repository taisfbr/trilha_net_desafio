using System.Text.RegularExpressions;
using DesafioFundamentos.Exceptions;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        private string _placa;
        public string Placa
        {
            get => _placa;

            set
            {
                if (!ValidarPlaca(value))
                {
                    throw new InvalidArgumentException("Placa invalida o formato deve ser: (LLL-NNNN)!");
                }
                _placa = value.ToUpper();

            }
        }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        public Veiculo() { }
        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public static bool ValidarPlaca(string placa)
        {
            string padrao = @"^[A-Z]{3}-\d{4}$";
            Regex regex = new Regex(padrao);
            return regex.IsMatch(placa.ToUpper());
        }

        public static string FormatarPlaca(string placa)
        {
            return placa.Insert(3, "-");
        }

        public static Veiculo CriarVeiculo(string placa)
        {
            return new Veiculo(placa);
        }
    }
}