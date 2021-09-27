using System;

namespace AgenciaBancaria.Dominio
{
    public static class Validacoes // Não pode ser instanciada
    {
        public static string ValidarStringVazia(this string texto) // Método de extensão
        {
            return string.IsNullOrWhiteSpace(texto) ? throw new Exception("Propriedade deve estar preenchida.") : texto;
        }
    }
}
