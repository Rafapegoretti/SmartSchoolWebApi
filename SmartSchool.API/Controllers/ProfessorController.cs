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
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        //http://localhost:5000/api/aluno/byId?id=2
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);

            if (professor == null) return BadRequest("Professor não encontrado ");

            return Ok(professor);
        }


        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);

        }

        [HttpPut("{id}")]
        public IActionResult Put(Professor professor, int id)
        {
            var professorAtt = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (professorAtt == null) return BadRequest("Aluno não encontrado");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(Professor professor, int id)
        {
            var professorAtt = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (professorAtt == null) return BadRequest("Aluno não encontrado");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);

            if (professor == null) return BadRequest("Aluno não encontrado");

            _context.Remove(professor);
            _context.SaveChanges();

            return Ok();
        }

    }
}
