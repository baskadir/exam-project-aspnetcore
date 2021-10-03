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
    public class ArticleRepository:GenericRepository<Article>,IArticleRepository
    {
        public ArticleRepository(ExamDbContext context):base(context)
        {

        }

        private ExamDbContext ExamDbContext
        {
            get { return context as ExamDbContext; }
        }

        public void RemoveRange(IEnumerable<Article> articles)
        {
            context.Set<Article>().RemoveRange(articles);
        }

        public async Task<Article> Get(Guid id)
        {
            return await context.Set<Article>().FindAsync(id);
        }
    }
}
