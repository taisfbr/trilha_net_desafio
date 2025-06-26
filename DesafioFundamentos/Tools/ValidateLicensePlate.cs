namespace DesafioFundamentos.Tools;

public class ValidateLicensePlate
{
    public static bool IsValid(string plate)
    {
        // Checks if the license plate has the correct format: 3 letters, 2 numbers, 2 letters
        if (plate.Length != 7 || !System.Text.RegularExpressions.Regex.IsMatch(plate, @"^[A-Z]{3}\d{2}[A-Z]{2}$"))
        {
            return false;
        }

        // // Checks if the letters are uppercase
        if (!plate.Substring(0, 3).All(char.IsUpper) || !plate.Substring(5, 2).All(char.IsUpper))
        {
            return false;
        }

        // // Checks if the numbers are between 0 and 9
        if (!plate.Substring(3, 2).All(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}