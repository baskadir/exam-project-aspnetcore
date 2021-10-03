using Exam.Core.Repositories;
using Exam.Core.UnitOfWork;
using Exam.Data.Context;
using Exam.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamDbContext context;
        private ArticleRepository articleRepository;
        private QuestionRepository questionRepository;
        private QuizRepository quizRepository;
        public UnitOfWork(ExamDbContext _context)
        {
            this.context = _context;
        }
        public IArticleRepository Articles => articleRepository = articleRepository ?? new ArticleRepository(context);

        public IQuizRepository Quizzes => quizRepository = quizRepository ?? new QuizRepository(context);

        public IQuestionRepository Questions => questionRepository = questionRepository ?? new QuestionRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
