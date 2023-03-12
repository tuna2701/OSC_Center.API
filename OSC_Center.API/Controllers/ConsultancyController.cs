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
    [Route("api/consultancy")]
    [ApiController]

    public class ConsultancyController : ControllerBase
    {
        private IConsultancyBusiness _itemBUS;
        public ConsultancyController(IConsultancyBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] ConsultancyCustom model)
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

        //[Route("update")]
        //[HttpPost]
        //public IActionResult Update([FromBody] RecordAddCustom model)
        //{
        //    try
        //    {
        //        var data = _itemBUS.Update(model);
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetByID(int id)
        {
            try
            {
                var data = _itemBUS.GetByID(id);
                return Ok(data);
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
                var student_id = formData.Keys.Contains("student_id") ? int.Parse(formData["student_id"].ToString()) : 0;
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, student_id));
                return Ok(new { data, total });

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return Ok();
        }


    }
}
