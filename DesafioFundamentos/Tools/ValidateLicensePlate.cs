namespace DesafioFundamentos.Tools;

public class ValidateLicensePlate
{
    public static bool IsValid(string plate)
    {
        // Verifica se a placa tem o formato correto: 3 letras, 2 números, 2 letras
        if (plate.Length != 7 || !System.Text.RegularExpressions.Regex.IsMatch(plate, @"^[A-Z]{3}\d{2}[A-Z]{2}$"))
        {
            return false;
        }

        // Verifica se as letras estão em maiúsculas
        if (!plate.Substring(0, 3).All(char.IsUpper) || !plate.Substring(5, 2).All(char.IsUpper))
        {
            return false;
        }

        // Verifica se os números estão entre 0 e 9
        if (!plate.Substring(3, 2).All(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}