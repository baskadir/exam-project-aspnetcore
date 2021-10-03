using Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Services
{
    public interface IQuestionService
    {
        Task<Question> GetQuestion(int id);
        IEnumerable<Question> GetQuestionsByQuiz(int quizId);
    }
}
