using DAL1.InterfaceRepos;
using DAL1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HON1.Controllers
{
    public class BookController : Controller
    {
        public readonly DAL1.InterfaceRepos.IBookRepos _bookRepo;
        public BookController(IBookRepos bookRepos) {  _bookRepo = bookRepos; }
        public async Task<IActionResult> Index()
        {
            var res = await _bookRepo.ViewAllBooks();
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookDetail obj)
        {
            if (ModelState.IsValid)
            {
                bool res = await _bookRepo.AddBook(obj);
                if (res)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var res = await _bookRepo.ViewAllBooksById(Id);
            return View(res);
        }
        [HttpPost]
        public IActionResult Edit(BookDetail obj)
        {
            if (ModelState.IsValid) { 
            bool res = _bookRepo.UpdateBook(obj).Result;
                if (res)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var res = _bookRepo.ViewAllBooksById(Id).Result;
            return View(res);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var res = _bookRepo.ViewAllBooksById(Id).Result;
            return View(res);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            bool res = _bookRepo.RemoveBook(Id).Result;
            return RedirectToAction("Index");
        }
        
    }
}
