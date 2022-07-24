using InterviewWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AnswerController : ControllerBase
    {
        [HttpPost]
        public Guid Create([FromBody] CreateAnswerModel model)
        {
            var db = new InterviewAppDbContext();
            var newAnswer = new Answer()
            {
                QuestionId = model.QuestionId,
                Text = model.Text
            };

            db.Answers.Add(newAnswer);
            db.SaveChanges();
            return newAnswer.Id;
        }

        [HttpGet]
        public Answer Get([FromQuery] Guid id)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Answers.FirstOrDefault(c => c.Id == id);
            return entity;
        }

        [HttpPut]
        public ActionResult Update([FromBody] Answer question)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Answers.FirstOrDefault(c => c.Id == question.Id);
            entity.Text = question.Text;

            db.Update(entity);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete([FromQuery] Guid id)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Answers.FirstOrDefault(c => c.Id == id);
            db.Answers.Remove(entity);
        }
    }
}