using System;

namespace AgenciaBancaria.Dominio
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, string rg, Endereco endereco)
        {
            this.Nome = nome.ValidarStringVazia();
            this.CPF = cpf.ValidarStringVazia();
            this.RG = rg.ValidarStringVazia();
            this.Endereco = endereco ?? throw new Exception("Endereço deve ser informado");
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
