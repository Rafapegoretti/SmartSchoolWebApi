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
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        //http://localhost:5000/api/aluno/byId?id=2
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);

            if (professor == null) return BadRequest("Professor não encontrado ");

            return Ok(professor);
        }


        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Cadastrado");
            }

            return BadRequest("Professor não cadastrado.");

        }

        [HttpPut("{id}")]
        public IActionResult Put(Professor professor, int id)
        {
            var professorAtt = _repo.GetProfessorById(id, false);
            if (professorAtt == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            _repo.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(Professor professor, int id)
        {
            var professorAtt = _repo.GetProfessorById(id, false);

            if (professorAtt == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            _repo.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id, false);

            if (professor == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(professor);
            _repo.SaveChanges();

            return Ok();
        }

    }
}
