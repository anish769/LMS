using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class AuthorService
    {
        LMSDBEntities context;

        public AuthorService()
        {
            context = new LMSDBEntities();
        }

        public void SaveData(AuthorModel authorModel)
        {
            var data = new Author()
            {
                AuthorID = authorModel.AuthorID,
                AuthorName = authorModel.AuthorName,
                Description = authorModel.Description
            };
            context.Authors.Add(data);
            context.SaveChanges();
        }
        public List<AuthorModel> DisplayData()
        {
            try
            {
                var data = context.Authors.Select(a => new AuthorModel()
                {
                    AuthorID = a.AuthorID,
                    AuthorName = a.AuthorName,
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
        public void UpdateData(AuthorModel model)
        {
            try
            {
                Author data = new Author();
                data = context.Authors.Where(a => a.AuthorID == model.AuthorID).FirstOrDefault();
                data.AuthorID = model.AuthorID;
                data.AuthorName = model.AuthorName;
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
                Author data = new Author();
                data = context.Authors.Where(a => a.AuthorID == id).FirstOrDefault();
                context.Authors.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AuthorModel GetData(int id)
        {
            try
            {
                var data = context.Authors.Where(a => a.AuthorID == id).Select(a => new AuthorModel()
                {
                    AuthorID = a.AuthorID,
                    AuthorName = a.AuthorName,
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