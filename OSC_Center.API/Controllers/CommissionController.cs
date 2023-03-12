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
    [Route("api/commission")]
    [ApiController]

    public class CommissionController : ControllerBase
    {
        private ICommissionBusiness _itemBUS;

        public CommissionController(ICommissionBusiness itemBUS, osc_centerContext context)
        {
            _itemBUS = itemBUS;
        }

        [Route("payment")]
        [HttpPost]
        public IActionResult Payment([FromBody] Commission model)
        {
            try
            {
                _itemBUS.Payment(model);
                return Ok();
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
                var student_id = int.Parse(formData["student_id"].ToString());
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, student_id));
                return Ok(new { data, total});

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
