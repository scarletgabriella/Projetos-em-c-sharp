using System;
using System.Collections.Generic;

namespace CalculoNotaAluno
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> alunos = new List<Aluno>();

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":

                        Console.WriteLine("Digite o nome do aluno: \n");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Digite a nota do aluno: \n");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        alunos.Add(aluno);
                        break;

                    case "2":

                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} NOTA: {a.Nota}");
                            }
                        }
                        break;

                    case "3":

                        decimal notaTotal = 0;
                        var nAlunos = 0;

                        for (int i = 0; i < alunos.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nAlunos;
                        Nota(mediaGeral);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }  
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine();

            return opcaoUser;
        }

        private static void Nota(decimal mediaGeral)
        {
            Conceito conceitoGeral;

            if (mediaGeral < 2)
            {
                conceitoGeral = Conceito.E;
            }
            else if (mediaGeral < 4)
            {
                conceitoGeral = Conceito.D;
            }
            else if (mediaGeral < 6)
            {
                conceitoGeral = Conceito.C;
            }
            else if (mediaGeral < 8)
            {
                conceitoGeral = Conceito.B;
            }
            else
            {
                conceitoGeral = Conceito.A;
            }

            Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
        }
    }
}
