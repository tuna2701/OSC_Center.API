using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class ConsultancyRepository : IConsultancyRepository
    {
        private osc_centerContext _context;

        public ConsultancyRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Create(ConsultancyCustom model)
        {
            try
            {
                Consultancy _model = new Consultancy
                {
                    StudentId = model.StudentID,
                    Status = model.Status,
                    Content = model.Content,
                    LastContact = model.LastContact,
                    NextContact = model.NextContact
                };
                
                _context.Consultancies.Add(_model);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public ConsultancyCustom GetByID(int id)
        {
            try
            {
                Consultancy _con = _context.Consultancies.OrderByDescending(c => c.LastContact).FirstOrDefault(c => c.StudentId == id);
                if (_con == null)
                    _con = new Consultancy();
                Student _stu = _context.Students.FirstOrDefault(s => s.StudentId == id);
                if (_stu == null)
                    _stu = new Student();
                Record _rec = _context.Records.FirstOrDefault(r => r.StudentId == id);
                if (_rec == null)
                    _rec = new Record();


                ConsultancyCustom ConsultancyCustom = new ConsultancyCustom
                {
                    ConsultancyId = _con.Id,
                    StudentID = id,
                    Status = _con.Status,
                    Content = _con.Content,
                    Email = _rec.Email1,
                    LastContact = _con.LastContact,
                    NextContact = _con.NextContact
                };
                return ConsultancyCustom;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Consultancy> Search(int pageIndex, int pageSize, out long total, int student_id)
        {
            total = 0;
            try
            {
                var result = new List<Consultancy>();
                if(student_id == 0)
                {
                    result = _context.Consultancies.
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();

                    total = _context.Consultancies.Count();
                }
                else
                {
                    result = _context.Consultancies.
                    Where(s => s.StudentId == student_id).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();

                    total = _context.Consultancies.Where(s => s.StudentId == student_id).Count();
                }
                

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
