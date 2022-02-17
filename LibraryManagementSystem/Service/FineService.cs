using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class FineService
    {
        LMSDBEntities context;

        public FineService()
        {
            context = new LMSDBEntities();
        }

        public void SaveData(FineModel fineModel)
        {
            var data = new Fine()
            {
                FineID = fineModel.FineID,
                LateDays = fineModel.LateDays,
                MemberCategoryID = fineModel.MemberCategoryID,
                Amount = fineModel.Amount,
                Remarks = fineModel.Remarks
            };
            context.Fines.Add(data);
            context.SaveChanges();
        }
        public List<FineModel> DisplayData()
        {
            try
            {
                var data = context.Fines.Select(a => new FineModel()
                {
                    FineID = a.FineID,
                    LateDays = a.LateDays,
                    MemberCategoryID = a.MemberCategoryID,
                    Amount = a.Amount,
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
        public void UpdateData(FineModel model)
        {
            try
            {
                Fine data = new Fine();
                data = context.Fines.Where(a => a.FineID == model.FineID).FirstOrDefault();
                data.FineID = model.FineID;
                data.LateDays = model.LateDays;
                data.MemberCategoryID = model.MemberCategoryID;
                data.Amount = model.Amount;
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
                Fine data = new Fine();
                data = context.Fines.Where(a => a.FineID == id).FirstOrDefault();
                context.Fines.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public FineModel GetData(int? id)
        {
            try
            {
                var data = context.Fines.Where(a => a.FineID == id).Select(a => new FineModel()
                {
                    FineID = a.FineID,
                    LateDays = a.LateDays,
                    MemberCategoryID = a.MemberCategoryID,
                    Amount = a.Amount,
                    Remarks = a.Remarks
                }).FirstOrDefault();

                if (data == null)
                {
                    data = new FineModel()
                    {
                        Amount = 1000
                    };
                    return data;
                } 
                else
                {
                    return data;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}