using Exam.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        IQuizRepository Quizzes { get; }
        IQuestionRepository Questions { get; }

        Task<int> CommitAsync();
    }
}
