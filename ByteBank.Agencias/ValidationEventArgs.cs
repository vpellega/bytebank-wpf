namespace ByteBank.Agencias
{
    public class ValidacaoEventArgs : EventArgs
    {
        public string Texto { get; private set; }
        public bool EhValido {get; set;}

        public ValidacaoEventArgs(string texto)
        {
            Texto = texto; 
            EhValido = true;
        }
    }
}
