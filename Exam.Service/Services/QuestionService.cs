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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;
        public QuestionService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await unitOfWork.Questions.Get(id);
        }

        public IEnumerable<Question> GetQuestionsByQuiz(int quizId)
        {
            return unitOfWork.Questions.Find(x => x.QuizId == quizId);
        }
    }
}
