using Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<Quiz>> GetAll();
        Task<Quiz> GetById(int id);
        Task<Quiz> Create(Quiz newQuiz);
        Task Delete(Quiz quiz);
    }
}
