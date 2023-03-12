using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class PlanRepository : IPlanRepository
    {
        private osc_centerContext _context;

        public PlanRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Create(EducationPlan model)
        {
            try
            {
                EducationPlan plan = new EducationPlan
                {
                    Name = model.Name,
                    StudentId = model.StudentId,
                    EDate = model.EDate,
                    Resolve = model.Resolve,
                    Status = model.Status
                };
                _context.EducationPlans.Add(plan);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EducationPlan model)
        {
            try
            {
                EducationPlan _model = _context.EducationPlans.FirstOrDefault(p => p.Id == model.Id);
                _model.Name = model.Name;
                _model.StudentId = model.StudentId;
                _model.EDate = model.EDate;
                _model.Resolve = model.Resolve;
                _model.Status = model.Status;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public EducationPlan GetByID(int id)
        {
            try
            {
                EducationPlan _plan = _context.EducationPlans.FirstOrDefault(p => p.StudentId == id);
                if( _plan == null )
                    return new EducationPlan();
                return _plan;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
         
        public bool Complete(int id, string status)
        {
            try
            {
                var planInfo = _context.EducationPlans.FirstOrDefault(s => s.Id == id);
                planInfo.Status = status;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<EducationPlanCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string status)
        {
            total = 0;
            try
            {
                List<EducationPlanCustom> result = new List<EducationPlanCustom>();
                if(student_id == 0)
                {
                    var result_tmp = _context.EducationPlans.
                    Where(s => s.Status.Contains(status)).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    OrderByDescending(s => s.EDate).
                    ToList();
                    foreach(var item in result_tmp) {
                        var studentName = _context.Students.FirstOrDefault(s => s.StudentId == item.StudentId).StudentName;
                        EducationPlanCustom educationPlanCustom = new EducationPlanCustom
                        {
                            Id = item.Id,
                            Name = item.Name,
                            StudentId = item.StudentId,
                            StudentName = studentName,
                            EDate = item.EDate,
                            Status = item.Status,
                            Resolve = item.Resolve
                        };
                        result.Add(educationPlanCustom);
                    }
                    total = _context.EducationPlans.Count();

                }
                else
                {
                    var result_tmp = _context.EducationPlans.
                    Where(s => s.StudentId == student_id && s.Status.Contains(status)).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    OrderByDescending(s => s.EDate).
                    ToList();
                    var studentName = _context.Students.FirstOrDefault(s => s.StudentId == student_id).StudentName;
                    foreach (var item in result_tmp)
                    {
                        EducationPlanCustom educationPlanCustom = new EducationPlanCustom
                        {
                            Id = item.Id,
                            Name = item.Name,
                            StudentId = item.StudentId,
                            StudentName = studentName,
                            EDate = item.EDate,
                            Status = item.Status,
                            Resolve = item.Resolve
                        };
                        result.Add(educationPlanCustom);
                    }
                    total = _context.EducationPlans.Where(s => s.StudentId == student_id).Count();

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
