using System;

namespace AgenciaBancaria.Dominio
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente) : base(cliente) // base : construtor da class mãe
        {
            this.PercentualRendimento = 0.003M; // 0,30% - M para decimal
        }

        public decimal PercentualRendimento { get; private set; }
    }
}
