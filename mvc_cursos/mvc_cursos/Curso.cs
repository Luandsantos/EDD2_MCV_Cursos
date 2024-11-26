using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_cursos
{
    internal class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Disciplina[] Disciplinas = new Disciplina[12];

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] == null)
                {
                    Disciplinas[i] = disciplina;
                    return true;
                }
            }
            return false;
        }

        public Disciplina PesquisarDisciplina(int id)
        {
            foreach (var disciplina in Disciplinas)
            {
                if (disciplina != null && disciplina.Id == id)
                    return disciplina;
            }
            return null;
        }

        public bool RemoverDisciplina(int id)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == id && Disciplinas[i].Alunos[0] == null)
                {
                    Disciplinas[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
