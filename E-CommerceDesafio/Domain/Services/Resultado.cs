namespace E_CommerceDesafio.Domain.Services
{
    public class Resultado
    {
        public bool Sucesso { get; }
        public string Mensagem { get; }

        protected Resultado(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public static Resultado Exito()
        {
            return new Resultado(true, string.Empty);
        }

        public static Resultado<T> ExitoComValor<T>(T valor)
        {
            return new Resultado<T>(true, valor, string.Empty);
        }

        public static Resultado Falha(string mensagem)
        {
            return new Resultado(false, mensagem);
        }

        public static Resultado<T> FalhaComValor<T>(string mensagem)
        {
            return new Resultado<T>(false, default, mensagem);
        }
    }

    public class Resultado<T> : Resultado
    {
        public T Valor { get; }

        internal Resultado(bool sucesso, T valor, string mensagem)
            : base(sucesso, mensagem)
        {
            Valor = valor;
        }
    }
}
