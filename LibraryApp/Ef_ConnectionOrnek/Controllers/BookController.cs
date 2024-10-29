using Ef_ConnectionOrnek.Context;
using Ef_ConnectionOrnek.Entity;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _db;



        public BookController(  LibraryContext db) {
            _db =db;
        }

        public IActionResult BookList ()
        {
            var viewmodel = _db.Books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                PageCount = x.PageCount,
                AuthorFirstName=x.Author.FirstName,
                AuthorLastName=x.Author.LastName,
                BookType = x.BookType.Name




            }).ToList();



            return View(viewmodel);
        }

        [HttpGet] 
        public IActionResult BookCreate () 
        {
            
           ViewBag.Authors=_db.Authors
                .Where(x=>x.IsDeleted==false)
                .OrderBy(x=>x.FirstName).ToList();

            ViewBag.BookTypes=_db.BookTypes
                .Where(x=>x.IsDeleted==false)
                .OrderBy(x=>x.Name).ToList();

            return View();
        }
        [HttpPost] 
        public IActionResult BookCreate( BookCreateViewModel formData)
        {
            var bookEntity = new BookEntity()
            {
                Name = formData.Name,
                PageCount = formData.PageCount,
                AuthorId = formData.AuthorId,
                BookTypeId = formData.BookTypeId,

            };
            _db.Books.Add(bookEntity);
            _db.SaveChanges();


            return RedirectToAction("BookList");
        }
        [HttpGet]
        public IActionResult BookUpdate(int id )
        {

            var entity = _db.Books.Find(id);

            var ViewModel = new BookUpdateViewModel()
            {
                Id=entity.Id,
                Name = entity.Name,
                AuthorId = entity.AuthorId,
                BookTypeId = entity.BookTypeId,
                PageCount = entity.PageCount

            };

            ViewBag.Authors = _db.Authors
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.FirstName).ToList();

            ViewBag.BookTypes = _db.BookTypes
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Name).ToList();



            return View(ViewModel);
        }

        [HttpPost]

        public IActionResult BookUpdate(BookUpdateViewModel formData)
        {
            var entity = _db.Books.Find(formData.Id);

            entity.AuthorId = formData.AuthorId;
            entity.BookTypeId = formData.BookTypeId;
            entity.Name = formData.Name;
            entity.PageCount = formData.PageCount;
            entity.ModifiedDate=DateTime.Now;

            _db.Books.Update(entity);
            _db.SaveChanges();

            return RedirectToAction("BookList");


        }

        [HttpGet] 
        public IActionResult BookDelete(int id) 
        {
            var entity=_db.Books.Find(id);
            entity.IsDeleted= true;
            entity.ModifiedDate= DateTime.Now;

            _db.Books.Update(entity);
            _db.SaveChanges();
            return RedirectToAction("BookList");


        }
            
    }

   
}
