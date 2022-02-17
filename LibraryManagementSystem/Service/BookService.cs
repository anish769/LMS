using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Service
{
    public class BookService
    {
        LMSDBEntities context;

        public BookService()
        {
            context = new LMSDBEntities();
        }

        public void SaveData(BookModel bookModel)
        {
            var data = new Book()
            {
                BookID = bookModel.BookID,
                BookName = bookModel.BookName,
                BookCategoryID = bookModel.BookCategoryID,
                AuthorID = bookModel.AuthorID,
                SubjectID = bookModel.SubjectID
            };
            context.Books.Add(data);
            context.SaveChanges();
        }
        public List<BookModel> DisplayData()
        {
            try
            {
                var data = context.Books.Select(a => new BookModel()
                {
                    BookID = a.BookID,
                    BookName = a.BookName,
                    BookCategoryID = a.BookCategoryID,
                    AuthorID = a.AuthorID,
                    SubjectID = a.SubjectID
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    
    public List<SelectListItem> DisplayDataComboList()
        {
            try
            {
                var data=(from b in  context.Books
                         join a in context.AssessionMappings 
                         on b.BookID equals a.BookID
                         where a.Status==0
                                         select new SelectListItem()
                                         {
                                             Value = a.AssessionID.ToString(),
                                             Text = b.BookName+"-"+a.AssessionID
                                         }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void UpdateData(BookModel model)
        {
            try
            {
                Book data = new Book();
                data = context.Books.Where(a => a.BookID == model.BookID).FirstOrDefault();
                data.BookID = model.BookID;
                data.BookName = model.BookName;
                data.BookCategoryID = model.BookCategoryID;
                data.AuthorID = model.AuthorID;
                data.SubjectID = model.SubjectID;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteData(int id)
        {
            try
            {
                Book data = new Book();
                data = context.Books.Where(a => a.BookID == id).FirstOrDefault();
                context.Books.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookModel GetData(int id)
        {
            try
            {
                var data = context.Books.Where(a => a.BookID == id).Select(a => new BookModel()
                {
                    BookID = a.BookID,
                    BookName = a.BookName,
                    BookCategoryID = a.BookCategoryID,
                    AuthorID = a.AuthorID,
                    SubjectID = a.SubjectID
                }).FirstOrDefault();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}