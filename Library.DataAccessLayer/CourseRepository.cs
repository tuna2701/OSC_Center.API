using Library.DataModel;
using Library.DataModel.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private osc_centerContext _context;

        public CourseRepository(osc_centerContext context)
        {
            _context = context;
        }

        //public bool RegisterCourse(int course_id)
        //{
        //    try
        //    {
        //        Course _model = _context.Courses.FirstOrDefault(p => p.CourseId == course_id);
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
        public bool RegistedCourse(int course_id, int student_id)
        {
            try
            {
                var reCourse = _context.RegisterCourses.FirstOrDefault(s => s.CourseId == course_id && s.StudentId == student_id);
                var courseInfo = _context.Courses.FirstOrDefault(s => s.CourseId == course_id);
                if(reCourse == null)
                {
                    RegisterCourse registerCourse = new RegisterCourse
                    {
                        CourseId = course_id,
                        StudentId = student_id,
                        RegisterDay = DateTime.Now
                    };
                    _context.RegisterCourses.Add(registerCourse);
                    Commission commission = new Commission {
                        StudentId = student_id,
                        CourseId = course_id,
                        Amount = courseInfo.Price,
                        EndDate = DateTime.Now.AddMonths(4),
                        Content = "Học phí khóa học " + courseInfo.Name,
                        Status = 0 //0: Chưa thanh toán
                    };
                    _context.Commissions.Add(commission);
                    _context.SaveChanges();
                }
                else
                {
                    var commissionInfo = _context.Commissions.FirstOrDefault(s => s.StudentId == student_id && s.CourseId == course_id);
                    _context.Commissions.Remove(commissionInfo);
                    _context.RegisterCourses.Remove(reCourse);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckRegisted(int course_id, int student_id)
        {
            try
            {
                var result = _context.RegisterCourses.FirstOrDefault(s => s.StudentId == student_id && s.CourseId == course_id);
                if(result != null) 
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentClassCustom> GetStudentByClassID(int pageIndex, int pageSize, out long total, int course_id)
        {
            total = 0;
            try
            {
                List<StudentClassCustom> studentClasses = new List<StudentClassCustom>();
                var studentRegistedID = _context.RegisterCourses.Where(s => s.CourseId == course_id)
                    .Skip(pageSize * (pageIndex - 1)).Take(pageSize)
                    .ToList();
                foreach(var item in studentRegistedID)
                {
                    var studentInfo = _context.Students.FirstOrDefault(s => s.StudentId == item.StudentId);
                    var courseName = _context.Courses.FirstOrDefault(c => c.CourseId == course_id).Name;
                    var email = _context.Records.FirstOrDefault(r => r.StudentId == studentInfo.StudentId).Email1;
                    StudentClassCustom studentClassCustom = new StudentClassCustom
                    {
                        StudentID = studentInfo.StudentId,
                        StudentName = studentInfo.StudentName,
                        StudentDoB = studentInfo.StudentDob,
                        ClassID = course_id,
                        ClassName = courseName,
                        Phone = studentInfo.StudentPhone,
                        Email = email,
                        TeacherName = null
                    };
                    studentClasses.Add(studentClassCustom);
                }
                total = _context.RegisterCourses.Where(s => s.CourseId == course_id).Count();
                return studentClasses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CourseCustom> Search(int pageIndex, int pageSize, out long total, string course_name, int student_id)
        {
            total = 0;
            try
            {
                List<CourseCustom> courseCustoms = new List<CourseCustom>();
                var result = _context.Courses.
                    Where(s => s.Name.Contains(course_name) && s.ActiveFlag == 1).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();
                foreach(var item in result)
                {
                    CourseCustom courseCustom = new CourseCustom
                    {
                        CourseId = item.CourseId,
                        Name = item.Name,
                        Content = item.Content,
                        Price = item.Price,
                        NumberOfSession = item.NumberOfSession,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        DayToStudy = item.DayToStudy,
                        OpeningDay = item.OpeningDay,
                        IsRegisted = CheckRegisted(item.CourseId, student_id) == true ? true : false,
                        StudentID = student_id,
                        ActiveFlag = item.ActiveFlag
                    };
                    courseCustoms.Add(courseCustom);
                }
                total = result.Count();

                return courseCustoms;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Course> SearchRegistedCourse(int pageIndex, int pageSize, out long total, string course_name, int student_id)
        {
            total = 0;
            try
            {
                List<Course> courses = new List<Course>();
                var result = _context.Courses.
                    Where(s => s.Name.Contains(course_name) && s.ActiveFlag == 1).
                    Skip(pageSize * (pageIndex - 1)).Take(pageSize).
                    ToList();
                foreach (var item in result)
                {
                    if(CheckRegisted(item.CourseId, student_id))
                    {
                        Course course = new Course();
                        course = item;
                        courses.Add(course);
                    }
                }
                total = result.Count();

                return courses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
