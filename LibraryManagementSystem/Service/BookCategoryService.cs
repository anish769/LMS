using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class BookCategoryService
    {
        LMSDBEntities1 context;

        public BookCategoryService()
        {
            context = new LMSDBEntities1();
        }

        public void SaveData(BookCategoryModel bookCategoryModel)
        {
            var data = new BookCategory()
            {
                BookCategoryID = bookCategoryModel.BookCategoryID,
                BookCategoryName = bookCategoryModel.BookCategoryName,
                Description = bookCategoryModel.Description
            };
            context.BookCategory.Add(data);
            context.SaveChanges();
        }
        public List<BookCategoryModel> DisplayData()
        {
            try
            {
                var data = context.BookCategory.Select(a => new BookCategoryModel()
                {
                    BookCategoryID = a.BookCategoryID,
                    BookCategoryName = a.BookCategoryName,
                    Description = a.Description
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void UpdateData(BookCategoryModel model)
        {
            try
            {
                BookCategory data = new BookCategory();
                data = context.BookCategories.Where(a => a.BookCategoryID == model.BookCategoryID).FirstOrDefault();
                data.BookCategoryID = model.BookCategoryID;
                data.BookCategoryName = model.BookCategoryName;
                data.Description = model.Description;
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
                BookCategory data = new BookCategory();
                data = context.BookCategories.Where(a => a.BookCategoryID == id).FirstOrDefault();
                context.BookCategories.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookCategoryModel GetData(int id)
        {
            try
            {
                var data = context.BookCategories.Where(a => a.BookCategoryID == id).Select(a => new BookCategoryModel()
                {
                    BookCategoryID = a.BookCategoryID,
                    BookCategoryName = a.BookCategoryName,
                    Description = a.Description
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