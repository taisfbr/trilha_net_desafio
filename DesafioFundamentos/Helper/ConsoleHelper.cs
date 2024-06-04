namespace DesafioFundamentos.Helper
{
    public static class ConsoleHelper
    {
        public static void Clear() => Console.Clear();

        public static void LogInformacao(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(mensagem);
        }

        public static void LogSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
        }

        public static void LogAtencao(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(mensagem);
        }

        public static void LogErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
        }
    }
}
