using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class ContractRepository : IContractRepository
    {
        private osc_centerContext _context;

        public ContractRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Create(Contract model)
        {
            try
            {
                Contract contract = new Contract
                {
                    StudentId = model.StudentId,
                    CreatedAt = model.CreatedAt,
                    Total = model.Total,
                    AmountPaid = model.AmountPaid,
                    RestPaid = model.RestPaid,
                    Note = model.Note,
                    Image = model.Image
                };
                _context.Contracts.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Contract model)
        {
            try
            {
                Contract _model = _context.Contracts.FirstOrDefault(c => c.ContractId == model.ContractId);
                _model.StudentId = model.StudentId;
                _model.CreatedAt = model.CreatedAt;
                _model.Total = model.Total;
                _model.AmountPaid = model.AmountPaid;
                _model.RestPaid = model.RestPaid;
                _model.Note = model.Note;
                _model.Image = model.Image;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Contract GetByID(int id)
        {
            try
            {
                Contract _con = _context.Contracts.FirstOrDefault(c => c.StudentId == id);
                if (_con == null)
                    _con = new Contract();
                
                return _con;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //public List<Consultancy> Search(int pageIndex, int pageSize, out long total, string Consultancy_name, string cccd)
        //{
        //    total = 0;
        //    try
        //    {
        //        var result = new List<Consultancy>();
        //        //var result = _context.Consultancys.
        //        //    Where(s => s.ConsultancyName.Contains(Consultancy_name) && s.ConsultancyCccd.Contains(cccd)).
        //        //    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
        //        //    ToList();

        //        //total = _context.Consultancys.Count();

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
