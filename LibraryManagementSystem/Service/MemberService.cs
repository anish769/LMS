using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class MemberService
    {
        LMSDBEntities context;

        public MemberService()
        {
            context = new LMSDBEntities();
        }

        public void SaveData(MemberModel memberModel)
        {
            var data = new Member()
            {
                MemberID = memberModel.MemberID,
                MemberName = memberModel.MemberName,
                MemberCategoryID = memberModel.MemberCategoryID,
                MemberAddress = memberModel.MemberAddress,
                ContactNo = memberModel.ContactNo,
                EmailAddress = memberModel.EmailAddress,
                UserName = memberModel.UserName,
                Password = memberModel.Password,
                Remarks = memberModel.Remarks,
                Status = memberModel.Status
            };
            context.Members.Add(data);
            context.SaveChanges();
        }
        public List<MemberModel> DisplayData()
        {
            try
            {
                var data = context.Members.Select(a => new MemberModel()
                {
                    MemberID = a.MemberID,
                    MemberName = a.MemberName,
                    MemberCategoryID = a.MemberCategoryID,
                    MemberAddress = a.MemberAddress,
                    ContactNo = a.ContactNo,
                    EmailAddress = a.EmailAddress,
                    UserName = a.UserName,
                    Password = a.Password,
                    Remarks = a.Remarks,
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
        public void UpdateData(MemberModel model)
        {
            try
            {
                Member data = new Member();
                data = context.Members.Where(a => a.MemberID == model.MemberID).FirstOrDefault();
                data.MemberID = model.MemberID;
                data.MemberName = model.MemberName;
                data.MemberCategoryID = model.MemberCategoryID;
                data.MemberAddress = model.MemberAddress;
                data.ContactNo = model.ContactNo;
                data.EmailAddress = model.EmailAddress;
                data.UserName = model.UserName;
                data.Password = model.Password;
                data.Remarks = model.Remarks;
                data.Status = model.Status;
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
                Member data = new Member();
                data = context.Members.Where(a => a.MemberID == id).FirstOrDefault();
                context.Members.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MemberModel GetData(int id)
        {
            try
            {
                var data = context.Members.Where(a => a.MemberID == id).Select(a => new MemberModel()
                {
                    MemberID = a.MemberID,
                    MemberName = a.MemberName,
                    MemberCategoryID = a.MemberCategoryID,
                    MemberAddress = a.MemberAddress,
                    ContactNo = a.ContactNo,
                    EmailAddress = a.EmailAddress,
                    UserName = a.UserName,
                    Password = a.Password,
                    Remarks = a.Remarks,
                    Status = a.Status
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