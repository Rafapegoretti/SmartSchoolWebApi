using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
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
        public readonly IRepository _repo;
        public AlunoController( IRepository repo) 
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        //http://localhost:5000/api/aluno/byId?id=2
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null) return BadRequest("Aluno não encontrado ");

            return Ok(aluno);
        } 

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges()){
                return Ok("Aluno Cadastrado");
            }

            return BadRequest("Aluno não cadastrado.");

        }

        [HttpPut("{id}")]
        public IActionResult Put(Aluno aluno, int id)
        {
            var alunoAtt = _repo.GetAlunoById(id, false);
            if (alunoAtt == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Atualizado");
            }

            return BadRequest("Aluno nao atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(Aluno aluno, int id)
        {
            var alunoAtt = _repo.GetAlunoById(id, false);
            if (alunoAtt == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Cadastrado");
            }

            return BadRequest("Aluno nao atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if(aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Deletado");
            }

            return BadRequest("Aluno nao Deletado .");
        }
    }
}
