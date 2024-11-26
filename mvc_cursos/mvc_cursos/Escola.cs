using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_cursos
{
    internal class Escola
    {
        public Curso[] Cursos = new Curso[5];

        public bool AdicionarCurso(Curso curso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] == null)
                {
                    Cursos[i] = curso;
                    return true;
                }
            }
            return false;
        }

        public Curso PesquisarCurso(int id)
        {
            foreach (var curso in Cursos)
            {
                if (curso != null && curso.Id == id)
                    return curso;
            }
            return null;
        }

        public bool RemoverCurso(int id)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == id)
                {
                    foreach (var disciplina in Cursos[i].Disciplinas)
                    {
                        if (disciplina != null)
                            return false;
                    }
                    Cursos[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
