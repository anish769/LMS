using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Service
{
    public class SubjectService
    {
        LMSDBEntities context;

        public SubjectService()
        {
            context = new LMSDBEntities();
        }

        public void SaveData(SubjectModel subjectModel)
        {
            var data = new Subject()
            {
                SubjectID = subjectModel.SubjectID,
                SubjectName = subjectModel.SubjectName,
                Remarks = subjectModel.Remarks
            };
            context.Subjects.Add(data);
            context.SaveChanges();
        }
        public List<SubjectModel> DisplayData()
        {
            try
            {
                var data = context.Subjects.Select(a => new SubjectModel()
                {
                    SubjectID = a.SubjectID,
                    SubjectName = a.SubjectName,
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
        public void UpdateData(SubjectModel model)
        {
            try
            {
                Subject data = new Subject();
                data = context.Subjects.Where(a => a.SubjectID == model.SubjectID).FirstOrDefault();
                data.SubjectID = model.SubjectID;
                data.SubjectName = model.SubjectName;
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
                Subject data = new Subject();
                data = context.Subjects.Where(a => a.SubjectID == id).FirstOrDefault();
                context.Subjects.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SubjectModel GetData(int id)
        {
            try
            {
                var data = context.Subjects.Where(a => a.SubjectID == id).Select(a => new SubjectModel()
                {
                    SubjectID = a.SubjectID,
                    SubjectName = a.SubjectName,
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