using DAL1.InterfaceRepos;
using DAL1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.ClassRepos
{
    public class BookRepo : IBookRepos
    {
        public readonly AppDb _context;
        public BookRepo(AppDb context) { _context = context; }

        public async Task<List<BookDetail>> ViewAllBooks()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception)
            {
                return new List<BookDetail>();
            }
        }

        public async Task<BookDetail> ViewAllBooksById(int Id)
        {
            try
            {
                return await _context.Books.FirstOrDefaultAsync(x => x.ID == Id);
            }
            catch (Exception) { return null; }
        }
        public async Task<bool> AddBook(BookDetail obj)
        {
            try
            {
                await _context.Books.AddAsync(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }
        public async Task<bool> UpdateBook(BookDetail obj)
        {
            try
            {
                _context.Books.Update(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }
        public async Task<bool> RemoveBook(int Id)
        {
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == Id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
    }
}
