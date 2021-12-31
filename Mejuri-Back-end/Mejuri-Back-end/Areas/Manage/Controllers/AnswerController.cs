using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class AnswerController : Controller
    {
        private readonly AppDbContext _context;

        public AnswerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Question> questions = _context.Questions.ToList();

            return View(questions);

        }
        public IActionResult Text(int id)
        {
            Question question = _context.Questions
               .Include(x => x.AppUser)
               .FirstOrDefault(x => x.Id == id);

            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [HttpPost]
        public IActionResult Text(Question question,int id)
        {
            Question existQuestion = _context.Questions
                .Include(x=>x.AppUser)
                .FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Answers.Add(new Answer
            {
                QuestionId=id,
                Date = DateTime.UtcNow,
                Text = question.Answer
            });
            existQuestion.Accept = true;
            _context.SaveChanges();

            return RedirectToAction("index", "product");
        }
    }
}
