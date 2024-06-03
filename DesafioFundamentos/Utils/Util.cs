using System.Text.RegularExpressions;

namespace DesafioFundamentos.Utils{
    public static class Util
    {
        public static bool ValidaPlaca(string placa)
        {
            var _placa = placa.Replace("-", "").Trim();

            if (string.IsNullOrEmpty(_placa)) { return false; }

            if (placa.Length != 7) { return false; }
            
            if (char.IsLetter(_placa, 4))
            {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(_placa);
            }
            else
            {
                var padraoAntigo = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoAntigo.IsMatch(_placa);
            }
        }
    }
}