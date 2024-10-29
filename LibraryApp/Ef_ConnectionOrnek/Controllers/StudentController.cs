using Ef_ConnectionOrnek.Context;
using Ef_ConnectionOrnek.Entity;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace LibraryApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly LibraryContext _db;

        public StudentController(LibraryContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult StudentList()

          
        {

            var students = _db.Students.Where(x => x.IsDeleted == false);
           
            var viewModel=students.Select(x=>new StudentListViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SchoolNumber = x.SchoolNumber,
                Gender = x.Gender,
                PhoneNumber = x.PhoneNumber,
                BirthDay = x.BirthDay,
             

                     

            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult StudentCreate() 
        {
           
            return View();
        }
        [HttpPost]

        public IActionResult StudentCreate(StudentCreateViewModel formData)
        {
            var entity = new StudentEntity()
            {
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                SchoolNumber = formData.SchoolNumber,
                Gender =formData.Gender,
                PhoneNumber = formData.PhoneNumber,
                BirthDay = formData.BirthDay,

            };
            _db.Students.Add(entity);
            _db.SaveChanges();
            return RedirectToAction("StudentList");


        }
        [HttpGet]
        public IActionResult StudentUpdate(int Id)
        {
            var entity = _db.Students.Find(Id);

            var UpdateViewModel = new StudentUpdateViewModel()
            {
                
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                SchoolNumber = entity.SchoolNumber,
                Gender = entity.Gender,
                PhoneNumber = entity.PhoneNumber,
                BirthDay = entity.BirthDay,
                

                

            };



            return View(UpdateViewModel);
        }
        [HttpPost]

        public IActionResult StudentUpdate(StudentUpdateViewModel formData)
        {
            var entity=_db.Students.Find(formData.Id);
            entity.FirstName = formData.FirstName;
            entity.LastName = formData.LastName;
            entity.SchoolNumber = formData.SchoolNumber;
            entity.Gender = formData.Gender;
            entity.PhoneNumber = formData.PhoneNumber;
            entity.BirthDay = formData.BirthDay;
            entity.ModifiedDate= DateTime.Now;

            _db.Students.Update(entity);
            _db.SaveChanges();
            return RedirectToAction("StudentList");
        }
      
        public IActionResult StudentDelete(int Id) // Ne ile Silmek İstiyorsan onu yaz örnek Id.Name
        {
            var entity = _db.Students.Find(Id);

            // Soft Dlete 
            entity.IsDeleted= true;
            entity.ModifiedDate = DateTime.Now;

            _db.Students.Update(entity);
            _db.SaveChanges();

            return RedirectToAction("StudentList");

        }
       

    }
}
