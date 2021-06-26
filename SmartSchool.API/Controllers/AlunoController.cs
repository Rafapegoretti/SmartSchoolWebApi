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
        private readonly DataContext _context;

        public AlunoController(DataContext context) 
        {
            _context = context;    
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //http://localhost:5000/api/aluno/byId?id=2
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno não encontrado ");

            return Ok(aluno);
        }


        //http://localhost:5000/api/aluno/byName?nome=rafa
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a =>
            a.Nome.ToUpper().Contains(nome.ToUpper()) && a.Sobrenome.ToUpper().Contains(sobrenome.ToUpper())

            );

            if (aluno == null) return BadRequest("Aluno não encontrado ");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);

        }

        [HttpPut("{id}")]
        public IActionResult Put(Aluno aluno, int id)
        {
            var alunoAtt = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunoAtt == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(Aluno aluno, int id)
        {
            var alunoAtt = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (alunoAtt == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok();
        }
    }
}
