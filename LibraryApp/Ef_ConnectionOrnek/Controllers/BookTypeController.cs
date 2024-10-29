using Ef_ConnectionOrnek.Context;
using Ef_ConnectionOrnek.Entity;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookTypeController : Controller
    {
       



        private readonly LibraryContext _db;
        public BookTypeController(LibraryContext db)
        {
            _db = db;
        }

      

      

        [HttpGet]
        public IActionResult List()
        {
            

            var bookTypes = _db.BookTypes.Where(x => x.IsDeleted == false);

           


            var viewModel=bookTypes.Select(x=> new BookTypeListViewModel()
            {
               Id = x.Id,
               Name = x.Name,
            }).ToList();
          

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateForm");
        }

        [HttpPost] 

        public IActionResult Create(BookTypeCreateViewModel formData)  
        {
           

            var entity = new BookTypeEntity()
            {
                Name = formData.Name,
            };

            _db.BookTypes.Add(entity);
            _db.SaveChanges();

            return RedirectToAction("List"); 
        }

        [HttpGet]

        public IActionResult Update(int Id )
        {
            
            var entity = _db.BookTypes.Find(Id);

            var updateViewModel = new BookTypeUpdateViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
           


            return View("UpdateForm",updateViewModel);
        }

        [HttpPost]
        public IActionResult Update(BookTypeUpdateViewModel formData)
        {
            var entity=_db.BookTypes.Find(formData.Id);
             
            entity.Name = formData.Name;
            entity.ModifiedDate= DateTime.Now;
            _db.SaveChanges();

            return RedirectToAction("List");

            
        }

        public IActionResult Delete(int Id)
        {
            var entity = _db.BookTypes.Find(Id);

            

           
            entity.IsDeleted= true; 
           
            entity.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(entity);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
