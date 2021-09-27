using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Brilho", "31", "Belo Horizonte", "Minas Gerais");
                Cliente cliente = new Cliente("Scarlet", "789", "93", endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 100);

                Console.WriteLine($"Conta: {conta.SituacaoConta} - {conta.NumeroConta} - {conta.DigitoVerificador}");

                string senha = "abc12563";
                conta.Abrir(senha);

                Console.WriteLine($"Conta: {conta.SituacaoConta} - {conta.NumeroConta} - {conta.DigitoVerificador}");

                conta.Sacar(10, senha);

                Console.WriteLine($"Saldo: {conta.Saldo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
