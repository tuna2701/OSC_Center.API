using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class CommissionRepository : ICommissionRepository
    {
        private osc_centerContext _context;

        public CommissionRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Payment(Commission model)
        {
            try
            {
                var _model = _context.Commissions.FirstOrDefault(c => c.Id == model.Id);
                _model.Id = model.Id;
                _model.StudentId = model.StudentId;
                _model.CourseId = model.CourseId;
                _model.Amount = model.Amount;
                _model.EndDate = model.EndDate;
                _model.Content = model.Content;
                _model.Status = model.Status;

                Income income = new Income
                {
                    StudentId = model.StudentId,
                    DatePayment = DateTime.Now,
                    PaymentMethods = "Trực tuyến",
                    Amount = model.Amount,
                    Note = model.Content,
                    Status = "Thu"
                };
                _context.Incomes.Add(income);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Commission> Search(int pageIndex, int pageSize, out long total, int student_id)
        {
            total = 0;
            try
            {
                var result = _context.Commissions.
                    Where(c => c.StudentId == student_id).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();
                total = _context.Posts.Count();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
