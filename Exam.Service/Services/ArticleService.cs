using Exam.Core.Entities;
using Exam.Core.Services;
using Exam.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service.Services
{
    public class ArticleService : IArticleService
    {
        private IUnitOfWork unitOfWork;
        public ArticleService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Article> Create(Article newArticle)
        {
            await unitOfWork.Articles.Add(newArticle);
            await unitOfWork.CommitAsync();
            return newArticle;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await unitOfWork.Articles.GetAll();
        }

        public async Task<Article> GetById(Guid id)
        {
            return await unitOfWork.Articles.Get(id);
        }

        public async Task Truncate()
        {
            var olderArticles = await unitOfWork.Articles.GetAll();
            unitOfWork.Articles.RemoveRange(olderArticles);
            await unitOfWork.CommitAsync();
        }
    }
}
