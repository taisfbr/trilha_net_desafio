using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class ValidarPlaca
    {
        private static readonly Regex placaRegex = new("^[A-Z]{3}[0-9]{4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public bool Validator(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            placa = placa.Replace("-", "");

            return placaRegex.IsMatch(placa);
        }
    }
}