using Library.BusinessLogicLayer;
using Library.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Library.DataModel.DTO;

namespace OSC_Center.API.Controllers
{
    [Route("api/course")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private ICourseBusiness _itemBUS;

        public CourseController(ICourseBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var course_id = int.Parse(formData["course_id"].ToString());
                var student_id = int.Parse(formData["student_id"].ToString());
                var data = _itemBUS.RegistedCourse(course_id, student_id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("get-student-by-courseID")]
        [HttpPost]
        public async Task<IActionResult> GetStudentByClassID([FromBody] Dictionary<string, object> formData)
        {
            try
            {

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var course_id = int.Parse(formData["course_id"].ToString());
                long total = 0;
                var data = await Task.FromResult(_itemBUS.GetStudentByClassID(page, pageSize, out total, course_id));
                return Ok(new { data, total });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var course_name = formData.Keys.Contains("course_name") ? Convert.ToString(formData["course_name"]) : "";
                var student_id = int.Parse(formData["student_id"].ToString());
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, course_name, student_id));
                return Ok(new { data, total });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("search-registed-course")]
        [HttpPost]
        public async Task<IActionResult> SearchRegistedCourse([FromBody] Dictionary<string, object> formData)
        {
            try
            {

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var course_name = formData.Keys.Contains("course_name") ? Convert.ToString(formData["course_name"]) : "";
                var student_id = int.Parse(formData["student_id"].ToString());
                long total = 0;
                var data = await Task.FromResult(_itemBUS.SearchRegistedCourse(page, pageSize, out total, course_name, student_id));
                return Ok(new { data, total });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
