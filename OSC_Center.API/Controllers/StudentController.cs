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
    [Route("api/student")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private IStudentBusiness _itemBUS;
        private osc_centerContext _context;

        public StudentController(IStudentBusiness itemBUS, osc_centerContext context)
        {
            _itemBUS = itemBUS;
            _context = context;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] StudentAddCustom model)
        {
            try
            {
                var data = _itemBUS.Create(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("update")]
        [HttpPost]
        public IActionResult Update([FromBody] StudentAddCustom model)
        {
            try
            {
                var data = _itemBUS.Update(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("get-custom-by-id/{id}")]
        [HttpGet]
        public IActionResult GetCStudentByID(int id)
        {
            try
            {
                var data = _itemBUS.GetCStudentByID(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[Route("search")]
        //[HttpPost]
        //public List<Student> Search([FromBody] int pageIndex, int PageSize, string Student_name, string student_cccd)
        //{
        //    try
        //    {
        //        var page = pageIndex;
        //        var pageSize = PageSize;
        //        var student_name = Student_name;
        //        var cccd = student_cccd;
        //        var data = _itemBUS.Search(page, pageSize, student_name, cccd);
        //        return data;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var student_name = formData.Keys.Contains("student_name") ? Convert.ToString(formData["student_name"]) : "";
                var cccd = formData.Keys.Contains("student_cccd") ? Convert.ToString(formData["student_cccd"]) : "";
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, student_name, cccd));
                return Ok(new { data, total});

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return Ok();
        }


    }
}
