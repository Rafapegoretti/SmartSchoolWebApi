using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "Rafael",
                Sobrenome = "Pegoretti",
                Telefone = "99999"
            },
            new Aluno(){
                Id = 2,
                Nome = "Oswaldo",
                Sobrenome = "Pegoretti",
                Telefone = "88888"
            },
            new Aluno(){
                Id = 3,
                Nome = "Simone",
                Sobrenome = "Pegoretti",
                Telefone = "777777"
            }
        };

        public AlunoController() {}


        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(Alunos);
        }


        //http://localhost:5000/api/aluno/byId?id=2
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null) return BadRequest("Aluno não encontrado ");

            return Ok(aluno);
        }


        //http://localhost:5000/api/aluno/byName?nome=rafa
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
            a.Nome.ToUpper().Contains(nome.ToUpper()) && a.Sobrenome.ToUpper().Contains(sobrenome.ToUpper()) 
            
            );

            if (aluno == null) return BadRequest("Aluno não encontrado ");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            if(aluno == null) return BadRequest("Passe os parametros corretos.");

            var novoAluno = new Aluno
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                Telefone = aluno.Telefone
            };

            Alunos.Add(novoAluno);

            return Ok(Alunos);

        }

        [HttpPut("{id}")]
        public IActionResult Put (Aluno aluno, int id)
        {
            if (aluno == null) return BadRequest("Passe os parametros corretos.");

            var alunoAtt = Alunos.FirstOrDefault(a => a.Id == id);

            alunoAtt.Nome = aluno.Nome;
            alunoAtt.Sobrenome = aluno.Sobrenome;
            alunoAtt.Telefone = aluno.Telefone;

            return Ok(Alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Passe os parametros corretos.");

            Alunos.Remove(aluno);

            return Ok(Alunos);
        }
    }
}
