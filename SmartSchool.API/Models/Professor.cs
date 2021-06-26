using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Professor
    {
        public Professor() { }

        public Professor(int id, string nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }

        public int Id { get; set; }
        public String Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }

}
