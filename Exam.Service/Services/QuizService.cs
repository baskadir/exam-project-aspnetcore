using Exam.Core.Entities;
using Exam.Core.Services;
using Exam.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork unitOfWork;
        public QuizService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Quiz> Create(Quiz newQuiz)
        {
            await unitOfWork.Quizzes.Add(newQuiz);
            await unitOfWork.CommitAsync();
            return newQuiz;
        }

        public async Task Delete(Quiz quiz)
        {
            unitOfWork.Quizzes.Remove(quiz);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return await unitOfWork.Quizzes.GetAll();
        }

        public async Task<Quiz> GetById(int id)
        {
            return await unitOfWork.Quizzes.Get(id);
        }
    }
}
