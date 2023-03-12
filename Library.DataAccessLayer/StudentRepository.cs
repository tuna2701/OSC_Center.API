using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Security.Cryptography;

namespace Library.DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private osc_centerContext _context;

        public StudentRepository(osc_centerContext context)
        {
            _context = context;
        }

        public bool Create(StudentAddCustom student)
        {
            student.ActiveFlag = 1;

            try
            {
                Guid user_id = Guid.NewGuid();
                UserSystem _user = new UserSystem
                {
                    Id = user_id,
                    FullName = student.StudentName,
                    UserName = student.UserName.ToString(),
                    Password = "202cb962ac59075b964b07152d234b70",
                    Role = "Student",
                    Token = null
                };

                Student _student = new Student
                {
                    StudentName = student.StudentName,
                    StudentDob = student.StudentDob,
                    StudentPhone = student.StudentPhone,
                    StudentAddress = student.StudentAddress,
                    StudentSource = student.StudentSource,
                    StudentCccd = student.StudentCccd,
                    StudentNote = student.StudentNote,
                    ActiveFlag = student.ActiveFlag,
                    UserId = user_id
                };

                

                _context.Students.Add(_student);

                _context.UserSystems.Add(_user);

                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(StudentAddCustom student)
        {
            student.ActiveFlag = 1;
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = mD5.ComputeHash(encoder.GetBytes(student.Password));
            var md5_pass = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            try
            {
                Student _student = _context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                _student.StudentName = student.StudentName;
                _student.StudentDob = student.StudentDob;
                _student.StudentPhone = student.StudentPhone;
                _student.StudentAddress = student.StudentAddress;
                _student.StudentSource = student.StudentSource;
                _student.StudentCccd = student.StudentCccd;
                _student.StudentNote = student.StudentNote;
                _student.ActiveFlag = student.ActiveFlag;
                _student.UserId = student.UserId;

                UserSystem _user = _context.UserSystems.FirstOrDefault(u => u.Id == _student.UserId);
                _user.FullName = student.StudentName;
                _user.UserName = student.UserName;
                _user.Password = md5_pass;
                _user.Role = student.Role;
                _user.Token = null;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentAddCustom GetCStudentByID(int id)
        {
            try
            {
                Student student = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
                UserSystem user = _context.UserSystems.Where(s => s.Id == student.UserId).FirstOrDefault();
                StudentAddCustom _student = new StudentAddCustom
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentDob = student.StudentDob,
                    StudentPhone = student.StudentPhone,
                    StudentAddress = student.StudentAddress,
                    StudentSource = student.StudentSource,
                    StudentCccd = student.StudentCccd,
                    StudentNote = student.StudentNote,
                    ActiveFlag = student.ActiveFlag,
                    UserId = student.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Role = user.Role
                };
                
                return _student;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
        public List<Student> Search(int pageIndex, int pageSize, out long total, string student_name, string cccd)
        {
            total = 0;
            try
            {
                
                var result = _context.Students.
                    Where(s => s.StudentName.Contains(student_name) && s.StudentCccd.Contains(cccd) && s.ActiveFlag == 1).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();
                total = result.Count() == 0 ? result.Where(s => s.ActiveFlag == 1).Count() : _context.Students.Where(s => s.ActiveFlag == 1).Count();
                //if (result.Count == 0)
                //{
                //    total = result.Where(s => s.ActiveFlag == 1).Count();
                //} else
                //{
                //    total = _context.Students.Where(s => s.ActiveFlag == 1).Count();
                //}
                //var result = _context.Students.FromSqlRaw($"exec student_search {pageIndex}, {pageSize}, N'{student_name}', '{cccd}'").ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
