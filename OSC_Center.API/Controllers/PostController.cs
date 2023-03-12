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
    [Route("api/post")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private IPostBusiness _itemBUS;

        public PostController(IPostBusiness itemBUS, osc_centerContext context)
        {
            _itemBUS = itemBUS;
        }


        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {

                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total));
                return Ok(new { data, total});

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
