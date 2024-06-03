
namespace DesafioFundamentos.Utils {
    public class InvalidPlateFormatException : Exception
    {
        public InvalidPlateFormatException() : base() { }
        public InvalidPlateFormatException(string message) : base(message) { }
        public InvalidPlateFormatException(string message, Exception inner) : base(message, inner) { }
    }
}
