using System;
using System.Text.RegularExpressions;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria // Abstrada não pode ser instanciada mas pode ser herdada
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            this.NumeroConta = random.Next(5000, 10000);
            this.SituacaoConta = SituacaoConta.Criada;
            this.DigitoVerificador = random.Next(0, 9);
            this.Cliente = cliente ?? throw new Exception("Cliente deve ser informado");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);
            this.SituacaoConta = SituacaoConta.Aberta;
            this.DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            senha = senha.ValidarStringVazia();

            if (!Regex.IsMatch(senha, @"^(?=. *?[a-z])(?=.*?[0-9]).{8,}$")) // Verifica se contém letra, número e se a senha contém 8 caracters
            {
                throw new Exception("Senha Inválida");
            }

            this.Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha) // Permitir sobreescrever
        {
            if (Senha != senha)
            {
                throw new Exception("Senha Inválida");
            }

            if (Saldo < valor)
            {
                throw new Exception("Saldo Insuficiente");
            }

            Saldo -= valor;
        }

        public int NumeroConta { get; init; } // init : só posso setar no contrutor
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; } // Alguns tipos não permite o valor nulo, para permitir adicione ? 
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta SituacaoConta { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }
    }
}
