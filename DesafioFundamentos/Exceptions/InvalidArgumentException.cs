
namespace DesafioFundamentos.Exceptions
{
    public class InvalidArgumentException : FormatException
    {
        public InvalidArgumentException() { }
        public InvalidArgumentException(string msg) : base(msg) { }
        public InvalidArgumentException(string msg, Exception e) : base(msg, e) { }

    }
}