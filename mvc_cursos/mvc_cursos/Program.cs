using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_cursos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            int opcao;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso");
                Console.WriteLine("3. Remover curso");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina");
                Console.WriteLine("6. Remover disciplina do curso");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("ID do curso: ");
                        int cursoId = int.Parse(Console.ReadLine());
                        Console.Write("Descrição do curso: ");
                        string cursoDesc = Console.ReadLine();
                        escola.AdicionarCurso(new Curso { Id = cursoId, Descricao = cursoDesc });
                        break;

                    case 2:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        var curso = escola.PesquisarCurso(cursoId);
                        if (curso != null)
                        {
                            Console.WriteLine($"Curso: {curso.Descricao}");
                            foreach (var disciplina in curso.Disciplinas)
                            {
                                if (disciplina != null)
                                    Console.WriteLine($"- {disciplina.Descricao}");
                            }
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 3:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        if (escola.RemoverCurso(cursoId))
                            Console.WriteLine("Curso removido com sucesso.");
                        else
                            Console.WriteLine("Não foi possível remover o curso.");
                        break;

                    case 4:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        curso = escola.PesquisarCurso(cursoId);
                        if (curso != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int disciplinaId = int.Parse(Console.ReadLine());
                            Console.Write("Descrição da disciplina: ");
                            string disciplinaDesc = Console.ReadLine();
                            curso.AdicionarDisciplina(new Disciplina { Id = disciplinaId, Descricao = disciplinaDesc });
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 5:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        curso = escola.PesquisarCurso(cursoId);
                        if (curso != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int disciplinaId = int.Parse(Console.ReadLine());
                            var disciplina = curso.PesquisarDisciplina(disciplinaId);
                            if (disciplina != null)
                            {
                                Console.WriteLine($"Disciplina: {disciplina.Descricao}");
                                foreach (var aluno in disciplina.Alunos)
                                {
                                    if (aluno != null)
                                        Console.WriteLine($"- {aluno.Nome}");
                                }
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 6:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        curso = escola.PesquisarCurso(cursoId);
                        if (curso != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int disciplinaId = int.Parse(Console.ReadLine());
                            if (curso.RemoverDisciplina(disciplinaId))
                                Console.WriteLine("Disciplina removida com sucesso.");
                            else
                                Console.WriteLine("Não foi possível remover a disciplina.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 7:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        curso = escola.PesquisarCurso(cursoId);
                        if (curso != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int disciplinaId = int.Parse(Console.ReadLine());
                            var disciplina = curso.PesquisarDisciplina(disciplinaId);
                            if (disciplina != null)
                            {
                                Console.Write("ID do aluno: ");
                                int alunoId = int.Parse(Console.ReadLine());
                                Console.Write("Nome do aluno: ");
                                string alunoNome = Console.ReadLine();
                                var aluno = new Aluno { Id = alunoId, Nome = alunoNome };
                                if (disciplina.MatricularAluno(aluno))
                                    Console.WriteLine("Aluno matriculado com sucesso.");
                                else
                                    Console.WriteLine("Não foi possível matricular o aluno.");
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 8:
                        Console.Write("ID do curso: ");
                        cursoId = int.Parse(Console.ReadLine());
                        curso = escola.PesquisarCurso(cursoId);
                        if (curso != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int disciplinaId = int.Parse(Console.ReadLine());
                            var disciplina = curso.PesquisarDisciplina(disciplinaId);
                            if (disciplina != null)
                            {
                                Console.Write("ID do aluno: ");
                                int alunoId = int.Parse(Console.ReadLine());
                                if (disciplina.DesmatricularAluno(new Aluno { Id = alunoId }))
                                    Console.WriteLine("Aluno desmatriculado com sucesso.");
                                else
                                    Console.WriteLine("Não foi possível desmatricular o aluno.");
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 9:
                        Console.Write("ID do aluno: ");
                        int alunoIdPesquisa = int.Parse(Console.ReadLine());
                        Aluno alunoEncontrado = null;

                        foreach (var cursoPesquisado in escola.Cursos)
                        {
                            if (cursoPesquisado != null)
                            {
                                foreach (var disciplinaPesquisada in cursoPesquisado.Disciplinas)
                                {
                                    if (disciplinaPesquisada != null)
                                    {
                                        foreach (var aluno in disciplinaPesquisada.Alunos)
                                        {
                                            if (aluno != null && aluno.Id == alunoIdPesquisa)
                                            {
                                                alunoEncontrado = aluno;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (alunoEncontrado != null)
                        {
                            Console.WriteLine($"Aluno: {alunoEncontrado.Nome}");
                            Console.WriteLine("Disciplinas matriculadas:");
                            foreach (var disciplina in alunoEncontrado.Disciplinas)
                            {
                                if (disciplina != null)
                                    Console.WriteLine($"- {disciplina.Descricao}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }
    }
}

