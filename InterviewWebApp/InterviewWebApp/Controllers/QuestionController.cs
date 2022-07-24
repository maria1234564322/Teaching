using InterviewWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuestionController : ControllerBase
    {
        [HttpPost]
        public Guid Create([FromBody] CreateQuestionModel model)
        {
            var db = new InterviewAppDbContext();
            var newQuestion = new Question()
            {
                Text = model.Text
            };

            db.Questions.Add(newQuestion);
            db.SaveChanges();
            return newQuestion.Id;
        }

        [HttpGet]
        public Question Get([FromQuery] Guid id)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Questions.FirstOrDefault(c => c.Id == id);
            return entity;
        }

        [HttpPut]
        public ActionResult Update([FromBody] Question question)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Questions.FirstOrDefault(c => c.Id == question.Id);
            entity.Text = question.Text;

            db.Update(entity);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete([FromQuery] Guid id)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Questions.FirstOrDefault(c => c.Id == id);
            db.Questions.Remove(entity);
        }
    }
}