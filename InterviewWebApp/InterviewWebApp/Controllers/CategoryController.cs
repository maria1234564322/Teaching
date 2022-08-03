using InterviewWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public Guid Create([FromBody] CreateCategoryModel model)
        {
            var db = new InterviewAppDbContext();
            var newCategory = new Category()
            {
                Name = model.Name
            };

            db.Categorys.Add(newCategory);
            db.SaveChanges();
            return newCategory.Id;
        }

        [HttpGet]
        public Category Get([FromQuery] Guid id)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Categorys.FirstOrDefault(c => c.Id == id);
            return entity;
        }

        [HttpPut]
        public ActionResult Update([FromBody] Category question)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Categorys.FirstOrDefault(c => c.Id == question.Id);
            entity.Name = question.Name;

            db.Update(entity);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete([FromQuery] Guid id)
        {
            var db = new InterviewAppDbContext();
            var entity = db.Categorys.FirstOrDefault(c => c.Id == id);
            db.Categorys.Remove(entity);
        }
    }
}