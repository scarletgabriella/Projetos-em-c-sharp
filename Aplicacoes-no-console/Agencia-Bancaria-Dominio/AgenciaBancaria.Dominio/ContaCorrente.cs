using System;

namespace AgenciaBancaria.Dominio
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(Cliente cliente, decimal limite) : base(cliente)
        {
            this.ValorTaxaManutancao = 0.05M;
            this.Limite = limite;
        }

        public override void Sacar(decimal valor, string senha) // Sobreescrevendo o método
        {
            if (Senha != senha)
            {
                throw new Exception("Senha Inválida");
            }

            if ((Saldo + Limite) < valor)
            {
                throw new Exception("Saldo Insuficiente");
            }

            Saldo -= valor;
        }

        public decimal Limite { get; private set; }
        public decimal  ValorTaxaManutancao { get; private set; }
    }
}
