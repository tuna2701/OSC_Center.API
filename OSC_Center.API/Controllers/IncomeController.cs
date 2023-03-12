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
    [Route("api/income")]
    [ApiController]

    public class IncomeController : ControllerBase
    {
        private IIncomeBusiness _itemBUS;

        public IncomeController(IIncomeBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Income model)
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
                var payment_type = formData.Keys.Contains("payment_type") ? Convert.ToString(formData["payment_type"]) : "";
                DateTime date_payment = formData.Keys.Contains("date_payment") ? Convert.ToDateTime(formData["date_payment"].ToString()) : DateTime.Now;
                var payment_method = formData.Keys.Contains("payment_method") ? Convert.ToString(formData["payment_method"]) : "";
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, student_id, payment_type, date_payment, payment_method));
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
