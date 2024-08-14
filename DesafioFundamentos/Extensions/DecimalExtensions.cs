namespace DesafioFundamentos.Extensions
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Classe contendo métodos de extensão para manipulação de uma propriedade de tipo Decimal
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Representação do valor informado no formato monetário
        /// referência: https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        /// </summary>
        /// <param name="value">Valor a ser formatado</param>
        /// <returns>O valor formatado</returns>
        ///
        public static String FormatCurrency(this Decimal value)
        {
            return value.ToString("C2", CultureInfo.CurrentCulture);
        }
    }
}
