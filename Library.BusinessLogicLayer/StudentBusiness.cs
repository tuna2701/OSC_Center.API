using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class StudentBusiness : IStudentBusiness
    {
        private IStudentRepository _res;

        public StudentBusiness(IStudentRepository res)
        {
            _res = res;
        }
        public bool Update(StudentAddCustom student)
        {
            return _res.Update(student);
        }


        public bool Create(StudentAddCustom student)
        {
            return _res.Create(student);
        }

        public StudentAddCustom GetCStudentByID(int id)
        {
            return _res.GetCStudentByID(id);
        }
        public List<Student> Search(int pageIndex, int pageSize, out long total, string student_name, string cccd)
        {
            return _res.Search(pageIndex, pageSize, out total, student_name, cccd);
        }
    }
}
