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
    [Route("api/contract")]
    [ApiController]

    public class ContractController : ControllerBase
    {
        private IContractBusiness _itemBUS;

        public ContractController(IContractBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Contract model)
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
        public IActionResult Update([FromBody] Contract model)
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



    }
}
