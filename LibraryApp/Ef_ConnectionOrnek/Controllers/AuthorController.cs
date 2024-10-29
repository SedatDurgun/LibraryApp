
using Ef_ConnectionOrnek.Context;
using Ef_ConnectionOrnek.Entity;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _db;

        public AuthorController(LibraryContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult List()
        {
            var authors = _db.Authors.Where(x => x.IsDeleted == false);

            var viewModel = authors.Select(x => new AuthorListViewModel()
            {
              Id = x.Id,
              Name=x.FirstName,
              Surname=x.LastName,
               
            }).ToList();

           


            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create (AuthorUpdateViewModel formData)
        {
            var entity = new AuthorEntity()
            {
                FirstName = formData.FirstName,
                LastName = formData.LastName,
            };
            _db.Authors.Add(entity);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update(int Id) 
        {
            var entity = _db.Authors.Find(Id);

            var updateViewModel = new AuthourUpdateViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,

            };
            return View(updateViewModel);
        }
        [HttpPost]
        public IActionResult Update(AuthorUpdateViewModel formData)
        {
            var entity = _db.Authors.Find(formData.Id);
            entity.FirstName = formData.FirstName;
            entity.LastName = formData.LastName;
            entity.ModifiedDate= DateTime.Now;

            _db.Authors.Update(entity);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            var entity = _db.Authors.Find(id);
            entity.IsDeleted= true;
            entity.ModifiedDate= DateTime.Now;
            _db.Authors.Update(entity);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
