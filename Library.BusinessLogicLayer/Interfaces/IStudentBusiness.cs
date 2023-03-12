using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IStudentBusiness
    {
        bool Create(StudentAddCustom student);
        bool Update(StudentAddCustom student);

        StudentAddCustom GetCStudentByID(int id);
        List<Student> Search(int pageIndex, int pageSize, out long total, string student_name, string cccd);
    }
}
