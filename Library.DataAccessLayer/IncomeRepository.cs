using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class IncomeRepository : IIncomeRepository
    {
        private osc_centerContext _context;

        public IncomeRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Create(Income model)
        {
            try
            {
                Income _model = new Income
                {
                    StudentId = model.StudentId,
                    DatePayment = model.DatePayment,
                    PaymentMethods = model.PaymentMethods,
                    Amount = model.Amount,
                    Note = model.Note,
                    Status = model.Status
                };
                _context.Incomes.Add(_model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool Update(Income model)
        //{
        //    try
        //    {
        //        Income _model = _context.Incomes.FirstOrDefault(p => p.Id == model.Id);
        //        _model.Name = model.Name;
        //        _model.StudentId = model.StudentId;
        //        _model.EDate = model.EDate;
        //        _model.Resolve = model.Resolve;
        //        _model.Status = model.Status;
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<Income> GetByID(int id)
        {
            try
            {
                List<Income> _plan = _context.Incomes.Where(p => p.StudentId == id).ToList();
                if( _plan == null )
                    return new List<Income>();
                return _plan;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<IncomeCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string payment_type,
            DateTime date_payment, string payment_method)
        {
            total = 0;
            try
            {
                List<Income> result;
                List<IncomeCustom> lstCustom = new List<IncomeCustom>();
                if (student_id == 0)
                {
                    result = _context.Incomes.
                    Where(s => s.DatePayment <= date_payment && s.PaymentMethods.Contains(payment_method) && s.Status.Contains(payment_type)).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).OrderByDescending(s => s.DatePayment).
                    ToList();

                    foreach(var item in result)
                    {
                        IncomeCustom incomeCustom = new IncomeCustom
                        {
                            Id = item.Id,
                            StudentId = item.StudentId,
                            StudentName = _context.Students.FirstOrDefault(s => s.StudentId == item.StudentId).StudentName,
                            DatePayment = item.DatePayment,
                            PaymentMethods = item.PaymentMethods,
                            Amount = item.Amount,
                            Note = item.Note,
                            Status = item.Status
                        };
                        lstCustom.Add(incomeCustom);
                    }
                    total = result.Count() == 0 ? result.Count() : _context.Incomes.Count();
                }
                else
                {
                    result = _context.Incomes.
                    Where(s => s.StudentId == student_id && s.DatePayment <= date_payment && s.PaymentMethods.Contains(payment_method) && s.Status.Contains(payment_type)).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).OrderByDescending(s => s.DatePayment).
                    ToList();

                    foreach (var item in result)
                    {
                        IncomeCustom incomeCustom = new IncomeCustom
                        {
                            Id = item.Id,
                            StudentId = item.StudentId,
                            StudentName = _context.Students.FirstOrDefault(s => s.StudentId == item.StudentId).StudentName,
                            DatePayment = item.DatePayment,
                            PaymentMethods = item.PaymentMethods,
                            Amount = item.Amount,
                            Note = item.Note,
                            Status = item.Status
                        };
                        lstCustom.Add(incomeCustom);
                    }

                    total = result.Count() == 0 ? result.Count() : _context.Incomes.Count();
                }

                //total = _context.Incomes.Count();
                return lstCustom;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
