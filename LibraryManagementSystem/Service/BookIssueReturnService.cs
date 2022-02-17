using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class BookIssueReturnService
    {
        LMSDBEntities context;
        FineService fineService; 


        public BookIssueReturnService()
        {
            context = new LMSDBEntities();
            fineService = new FineService();
        }

        public void SaveData(BookIssueReturnModel bookIssueReturnModel)
        {
            var data = new BookIssueReturn()
            {
                BookIssueReturnID = bookIssueReturnModel.BookIssueReturnID,
                MemberID = bookIssueReturnModel.MemberID,
                AssessionID = bookIssueReturnModel.AssessionID,
                IssueDate = bookIssueReturnModel.IssueDate,
                DueDate = bookIssueReturnModel.DueDate,
                ReturnDate = bookIssueReturnModel.ReturnDate,
                LateDays = bookIssueReturnModel.LateDays,
                FineAmount = bookIssueReturnModel.FineAmount,
                Status = bookIssueReturnModel.Status,
                StaffMemberID = bookIssueReturnModel.StaffMemberID,
                Remarks = bookIssueReturnModel.Remarks
            };
            context.BookIssueReturns.Add(data);
            context.SaveChanges();
        }

        
        public List<BookIssueReturnModel> DisplayDataByMemberId(int? id)
        {
            try
            {
                var data1=(from a in context.AssessionMappings
                          join  b in context.Books on a.BookID equals b.BookID
                          join bk in context.BookIssueReturns on a.AssessionID equals bk.AssessionID
                          where bk.MemberID==id && bk.Status==1
               select new BookIssueReturnModel()
                {
                   BookDescription=b.BookName+" ("+b.BookID+"-"+bk.AssessionID+")",
                    BookIssueReturnID = bk.BookIssueReturnID,
                    MemberID = bk.MemberID,
                    AssessionID = a.AssessionID,
                    IssueDate = bk.IssueDate,
                    DueDate = bk.DueDate,
                   ReturnDate = DateTime.Now,
                  // LateDays =Convert.ToInt32( DateTime.Now-bk.DueDate),
                   // FineAmount = fineService.GetData(bk.LateDays).Amount,
                    Status = bk.Status,
                    StaffMemberID = bk.StaffMemberID,
                    Remarks = bk.Remarks
                }).ToList();

                foreach (var item in data1)
                {
                    TimeSpan temp= DateTime.Now - (DateTime)item.DueDate;

                    item.LateDays = temp.Days;

                    if(item.LateDays>0)
                    {
                        item.FineAmount = fineService.GetData(item.LateDays).Amount;
                    }
                    else
                    {
                        item.FineAmount = 0;
                        item.LateDays = 0;
                    }


                }


                return data1;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public void UpdateReturnBookData(int accessionId,int  memberID)
        {
            try
            {
                BookIssueReturn data = new BookIssueReturn();
                data = context.BookIssueReturns.Where(a => a.AssessionID == accessionId && a.MemberID==memberID && a.Status==1).FirstOrDefault();
                data.ReturnDate = DateTime.Now;
                TimeSpan temp= DateTime.Now -(DateTime) data.DueDate;
                data.LateDays = temp.Days;
                data.FineAmount = fineService.GetData(data.LateDays).Amount;
                data.Status = 2;
                data.StaffMemberID =1;
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
                BookIssueReturn data = new BookIssueReturn();
                data = context.BookIssueReturns.Where(a => a.BookIssueReturnID == id).FirstOrDefault();
                context.BookIssueReturns.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookIssueReturnModel GetData(int id)
        {
            try
            {
                var data = context.BookIssueReturns.Where(a => a.BookIssueReturnID == id).Select(a => new BookIssueReturnModel()
                {
                    BookIssueReturnID = a.BookIssueReturnID,
                    MemberID = a.MemberID,
                    AssessionID = a.AssessionID,
                    IssueDate = a.IssueDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate,
                    LateDays = a.LateDays,
                    FineAmount = a.FineAmount,
                    Status = a.Status,
                    StaffMemberID = a.StaffMemberID,
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