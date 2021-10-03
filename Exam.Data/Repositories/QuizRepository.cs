using Exam.Core.Entities;
using Exam.Core.Repositories;
using Exam.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(ExamDbContext context) : base(context)
        {

        }
    }
}
