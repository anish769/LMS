using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class MemberCategoryService
    {
        LMSDBEntities context;

        public MemberCategoryService()
        {
            context = new LMSDBEntities();
        }

        public void SaveData(MemberCategoryModel memberCategoryModel)
        {
            var data = new MemberCategory()
            {
                MemberCategoryID = memberCategoryModel.MemberCategoryID,
                MemberCategoryName = memberCategoryModel.MemberCategoryName,
                Remarks = memberCategoryModel.Remarks
            };
            context.MemberCategories.Add(data);
            context.SaveChanges();
        }
        public List<MemberCategoryModel> DisplayData()
        {
            try
            {
                var data = context.MemberCategories.Select(a => new MemberCategoryModel()
                {
                    MemberCategoryID = a.MemberCategoryID,
                    MemberCategoryName = a.MemberCategoryName,
                    Remarks = a.Remarks
                }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void UpdateData(MemberCategoryModel model)
        {
            try
            {
                MemberCategory data = new MemberCategory();
                data = context.MemberCategories.Where(a => a.MemberCategoryID == model.MemberCategoryID).FirstOrDefault();
                data.MemberCategoryID = model.MemberCategoryID;
                data.MemberCategoryName = model.MemberCategoryName;
                data.Remarks = model.Remarks;
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
                MemberCategory data = new MemberCategory();
                data = context.MemberCategories.Where(a => a.MemberCategoryID == id).FirstOrDefault();
                context.MemberCategories.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MemberCategoryModel GetData(int id)
        {
            try
            {
                var data = context.MemberCategories.Where(a => a.MemberCategoryID == id).Select(a => new MemberCategoryModel()
                {
                    MemberCategoryID = a.MemberCategoryID,
                    MemberCategoryName = a.MemberCategoryName,
                    Remarks = a.Remarks
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