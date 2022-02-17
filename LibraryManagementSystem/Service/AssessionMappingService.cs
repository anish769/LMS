using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class AssessionMappingService
    {
        LMSDBEntities context;

        public AssessionMappingService()
        {
            context = new LMSDBEntities();
        }

        public List<AssessionMappingModel> DisplayData()
        {

            try
            {
                var data = context.AssessionMappings.Select(a => new AssessionMappingModel()
                {
                    AssessionID = a.AssessionID,
                    BookID = a.BookID,
                    Status = a.Status
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void SaveData(AssessionMappingModel assessionMappingModel)
        {
            var data = new AssessionMapping()
            {
                AssessionID = assessionMappingModel.AssessionID,
                BookID = assessionMappingModel.BookID
            };
            context.AssessionMappings.Add(data);
            context.SaveChanges();
        }
        public void UpdateData(AssessionMappingModel model)
        {
            try
            {
                AssessionMapping data = new AssessionMapping();
                data = context.AssessionMappings.Where(a => a.AssessionID == model.AssessionID).FirstOrDefault();
                data.AssessionID = model.AssessionID;
                data.BookID = model.BookID;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateBookStatus(int AccessionId,byte status)
        {
            try
            {
             var   data = context.AssessionMappings.Where(a => a.AssessionID == AccessionId).FirstOrDefault();
                data.Status = status;
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
                AssessionMapping data = new AssessionMapping();
                data = context.AssessionMappings.Where(a => a.AssessionID == id).FirstOrDefault();
                context.AssessionMappings.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AssessionMappingModel GetData(int id)
        {
            try
            {
                var data = context.AssessionMappings.Where(a => a.AssessionID == id).Select(a => new AssessionMappingModel()
                {
                    AssessionID = a.AssessionID,
                    BookID = a.BookID
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