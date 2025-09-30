using DAL1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.InterfaceRepos
{
    public interface IBookRepos
    {
        Task<List<BookDetail>> ViewAllBooks();
        Task<BookDetail> ViewAllBooksById(int Id);
        Task<bool> AddBook(BookDetail obj);
        Task<bool> UpdateBook(BookDetail obj);
        Task<bool> RemoveBook(int Id);
    }
}
