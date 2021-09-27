namespace AgenciaBancaria.Dominio
{
    public class Endereco
    {
        public Endereco(string longradouro, string cp, string cidade, string estado)
        {
            this.Logradouro = longradouro.ValidarStringVazia();
            this.CP = cp.ValidarStringVazia();
            this.Cidade = cidade.ValidarStringVazia();
            this.Estado = estado.ValidarStringVazia();
        }
        public string Logradouro { get; private set; }
        public string CP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
