using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_cursos
{
    internal class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Disciplina[] Disciplinas = new Disciplina[6];

        public bool PodeMatricular(Curso curso)
        {
            int count = 0;
            foreach (var disciplina in Disciplinas)
            {
                if (disciplina != null)
                    count++;
            }
            return count < 6;
        }
    }
}
