using AspCoreWebApi.Data;
using AspCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [Route("GetEmp")]
        [HttpGet]
        public IActionResult GetEmp(Emp e)
        {
            var d = db.emps.ToList();
            return Ok(d);
        }

        [HttpGet]
        [Route("GetById/{Id}")]

        public IActionResult GetById(int Id)
        {
            var d = db.emps.Find(Id);
            return Ok(d);
        }

        [HttpDelete]
        [Route("DeleteById/{Id}")]
        public IActionResult DeleteById(int Id)
        {
            var del = db.emps.Find(Id);
            var del1 = db.emps.Remove(del);
            db.SaveChanges();
            return Ok("Emp Deleted Successfully");

        }

        [HttpPatch]
        [Route("UpdateEmp")]
        public IActionResult UpdateEmp(Emp e)
        {
            db.emps.Update(e);
            db.SaveChanges();
            return Ok("Updated Successfully");
        }

        [HttpPost]
        [Route("AddMultipleEmp")]
        public IActionResult AddMultipleEmp(List<Emp> e)
        {
            db.emps.AddRange(e);
            db.SaveChanges();
            return Ok("Multiple Emp Added");
        }

        [Route("DeleteMultipleEmp")]
        [HttpDelete]
        public IActionResult DeleteMultipleEmp(List<int> e)
        {
            var data = db.emps.Where(x => e.Contains(x.Id)).ToList();
            db.RemoveRange(data);
            db.SaveChanges();
            return Ok("Deleted Multiple");
        }



        [Route("UploadFile")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile e)
        {
            //var path = env.WebRootPath;
            var filepath = "Images/" + e.FileName;
            //var fullpath=Path.Combine(path,filepath);
            FileStream stream = new FileStream(filepath, FileMode.Create);
            e.CopyTo(stream);


            return Ok("Image Uploaded Successfully");
        }
    }
}

