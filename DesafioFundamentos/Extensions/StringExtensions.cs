namespace DesafioFundamentos.Extensions
{
    using System;

    /// <summary>
    /// Classe contendo métodos de extensão  para manipulação de uma propriedade de tipo String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Verifica se o valor informado contém algum dado informado.
        /// </summary>
        /// <param name="value">Valor a ser verificado</param>
        /// <returns>O status de validação do valor informado</returns>
        public static Boolean ContainsValue(this String value)
        {
            if (String.IsNullOrEmpty(value)) return false;
            if (String.IsNullOrWhiteSpace(value)) return false;
            return true;
        }

        /// <summary>
        /// Verifica se o valor informado é um número inteiro de 32 bits
        /// </summary>
        /// <param name="value">Valor a ser validado</param>
        /// <param name="number">Valor inteiro que será retornado</param>
        /// <returns>O status de validação do valor informado</returns>
        public static Boolean ParseInt32(this String value, out Int32 number)
        {
            number = -1;
            var result = false;
            if (ContainsValue(value))
            {
                result = Int32.TryParse(value, out Int32 validation);
                if(result)
                {
                    number = validation;
                }
            }
            return result;
        }
    }
}
