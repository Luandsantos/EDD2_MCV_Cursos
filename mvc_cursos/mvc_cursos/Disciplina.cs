using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_cursos
{
    internal class Disciplina
    {
        private const int MaxAlunos = 15;
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Aluno[] Alunos = new Aluno[MaxAlunos];

        public bool MatricularAluno(Aluno aluno)
        {
            if (!aluno.PodeMatricular(null)) return false;

            for (int i = 0; i < MaxAlunos; i++)
            {
                if (Alunos[i] == null)
                {
                    Alunos[i] = aluno;
                    for (int j = 0; j < aluno.Disciplinas.Length; j++)
                    {
                        if (aluno.Disciplinas[j] == null)
                        {
                            aluno.Disciplinas[j] = this;
                            break;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < MaxAlunos; i++)
            {
                if (Alunos[i] != null && Alunos[i].Id == aluno.Id)
                {
                    Alunos[i] = null;

                    for (int j = 0; j < aluno.Disciplinas.Length; j++)
                    {
                        if (aluno.Disciplinas[j] != null && aluno.Disciplinas[j].Id == this.Id)
                        {
                            aluno.Disciplinas[j] = null;
                            break;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
