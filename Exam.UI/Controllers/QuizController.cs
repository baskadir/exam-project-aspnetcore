using Exam.Core.Entities;
using Exam.Core.Services;
using Exam.UI.Helpers;
using Exam.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.UI.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IQuizService quizService;
        private readonly IQuestionService questionService;
        public QuizController(IArticleService _articleService, IQuizService _quizService, IQuestionService _questionService)
        {
            this.articleService = _articleService;
            this.quizService = _quizService;
            this.questionService = _questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var quizzes = await quizService.GetAll();
            return View(quizzes);
        }

        const string url = "https://www.wired.com";
        public async Task<IActionResult> CreateQuiz()
        {
            var articles = await ArticleScrap.GetArticlesAsync(url);
            await articleService.Truncate();
            foreach (var item in articles)
            {
                await articleService.Create(item);
            }
            var existingArticles = await articleService.GetAll();
            TempData["articles"] = articles;
            return View();
        }

        public async Task<IActionResult> GetArticle(Guid id)
        {
            var article = await articleService.GetById(id);
            return Json(article);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(QuizVM quizVM)
        {
            if (ModelState.IsValid)
            {
                await quizService.Create(quizVM.Quiz);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen boş alan bırakmayın");
                return View(quizVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var quiz = await quizService.GetById(id);
            await quizService.Delete(quiz);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await quizService.GetById(id);
            quiz.Questions = questionService.GetQuestionsByQuiz(id).ToList();
            return View(quiz);
        }

        public async Task<IActionResult> CheckQuiz(string[] answers)
        {
            List<int> correctAnswers = new List<int>();
            foreach (var item in answers)
            {
                int index = item.IndexOf('-');
                var question = await questionService.GetQuestion(Convert.ToInt32(item.Substring(0,index)));
                if (question.CorrectAnswer == item.Substring(index+1,1))
                    correctAnswers.Add(Convert.ToInt32(item.Substring(0, index)));
            }
            return Json(correctAnswers);
        }
    }
}
