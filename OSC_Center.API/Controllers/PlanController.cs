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
    [Route("api/plan")]
    [ApiController]

    public class PlanController : ControllerBase
    {
        private IPlanBusiness _itemBUS;

        public PlanController(IPlanBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] EducationPlan model)
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
        public IActionResult Update([FromBody] EducationPlan model)
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

        [Route("complete")]
        [HttpPost]
        public IActionResult Complete([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var id = int.Parse(formData["id"].ToString());
                var status = Convert.ToString(formData["status"]);
                _itemBUS.Complete(id, status);
                return Ok();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return Ok();
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
                var status = formData.Keys.Contains("status") ? Convert.ToString(formData["status"]) : "";
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, student_id, status));
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
