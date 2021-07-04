using System.Collections.Generic;
using System.Threading.Tasks;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();


        Task<PageList<Aluno>> GetAllAlunosAsync(PageParameters pageParams, bool includeProfessor = false);
        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllAlunosByDIsciplinaId(int disciplinaId, bool includeProfessor);
        Aluno GetAlunoById(int alunoId, bool includeProfessor);

        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDIsciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);
    }
}