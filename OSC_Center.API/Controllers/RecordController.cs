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
    [Route("api/record")]
    [ApiController]

    public class RecordController : ControllerBase
    {
        private IRecordBusiness _itemBUS;

        public RecordController(IRecordBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Record model)
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
        public IActionResult Update([FromBody] Record model)
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

        //[Route("search")]
        //[HttpPost]
        //public async Task<IActionResult> Search([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {

        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        var Record_name = formData.Keys.Contains("Record_name") ? Convert.ToString(formData["Record_name"]) : "";
        //        var cccd = formData.Keys.Contains("Record_cccd") ? Convert.ToString(formData["Record_cccd"]) : "";
        //        long total = 0;
        //        var data = await Task.FromResult(_itemBUS.Search(page, pageSize, out total, Record_name, cccd));
        //        return Ok(new { data, total});

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    //return Ok();
        //}


    }
}
