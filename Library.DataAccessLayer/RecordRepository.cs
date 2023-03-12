using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class RecordRepository : IRecordRepository
    {
        private osc_centerContext _context;

        public RecordRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Update(Record model)
        {
            try
            {
                Record _model = _context.Records.FirstOrDefault(r => r.RecordId == model.RecordId);
                _model.StudentId = model.StudentId;
                _model.Major = model.Major;
                _model.SchoolName = model.SchoolName;
                _model.SchoolAddress = model.SchoolAddress;
                _model.CourseId = model.CourseId;
                _model.Status = model.Status;
                _model.SubmitDate = model.SubmitDate;
                _model.RegisterDate = model.RegisterDate;
                _model.AdmissionDate = model.AdmissionDate;
                _model.LastContact = model.LastContact;
                _model.NextContact = model.NextContact;
                _model.Email1 = model.Email1;
                _model.Email2 = model.Email2;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Create(Record model)
        {
            try
            {
                //Record _model = new Record
                //{
                //    StudentId = model.StudentID,
                //    Major = model.Major,
                //    SchoolName = model.SchoolName,
                //    SchoolAddress = model.SchoolAddress,
                //    CourseId = model.CourseId,
                //    Status = model.Status,
                //    SubmitDate = model.SubmitDate,
                //    RegisterDate = model.RegisterDate,
                //    AdmissionDate = model.AdmissionDate,
                //    LastContact = model.LastContact,
                //    NextContact = model.NextContact,
                //    Email1 = model.EmailP,
                //    Email2 = model.EmailF
                //};
                _context.Records.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public RecordCustom GetByID(int id)
        {
            try
            {
                Record _rec = _context.Records.FirstOrDefault(r => r.StudentId == id);
                if (_rec == null)
                    _rec = new Record();
                Student _stu = _context.Students.FirstOrDefault(s => s.StudentId == id);
                if (_stu == null)
                    _stu = new Student();
                Course _cou = _context.Courses.FirstOrDefault(c => c.CourseId == _rec.CourseId);
                if (_cou == null)
                    _cou = new Course();


                List<Course> lstCourse = _context.Courses.ToList();

                RecordCustom recordCustom = new RecordCustom
                {
                    RecordId = _rec.RecordId,
                    StudentID = id,
                    Major = _rec.Major,
                    SchoolName = _rec.SchoolName,
                    SchoolAddress = _rec.SchoolAddress,
                    CourseId = _rec.CourseId,
                    CourseName = _cou.Name,
                    Status = _rec.Status,
                    LstCourse = lstCourse,
                    SubmitDate = _rec.SubmitDate,
                    RegisterDate = _rec.RegisterDate,
                    AdmissionDate = _rec.AdmissionDate,
                    LastContact = _rec.LastContact,
                    NextContact = _rec.NextContact,
                    EmailP = _rec.Email1,
                    EmailF = _rec.Email2

                };

                return recordCustom;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //public List<Record> Search(int pageIndex, int pageSize, out long total, string Record_name, string cccd)
        //{
        //    total = 0;
        //    try
        //    {
        //        var result = new List<Record>();
        //        //var result = _context.Records.
        //        //    Where(s => s.RecordName.Contains(Record_name) && s.RecordCccd.Contains(cccd)).
        //        //    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
        //        //    ToList();

        //        //total = _context.Records.Count();

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
