using CRM.DTO;
using CRM.Models;
using CRM.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrmController : ControllerBase
    {
        private readonly Crm _crm;
        public CrmController(Crm crm)
        {
            _crm = crm;
        }
        [HttpGet("getDate")]
        public ActionResult GetData()
        {
            return Ok(_crm.GetData());
        }
        [HttpPost("postDate")]
        public ActionResult PostData(CrmDto value)
        {
            var data = _crm.PostData(value);
            if (data.Status == "200") return Ok(data);
            return BadRequest(data);
        }
        [HttpPost("insertChildProfile")]
        public ActionResult InsertChildProfile(ICollection<BusinessExecutionStatu> value)
        {
            var data = _crm.InsertChilProfile(value);
            if (data.Status == "200") return Ok(data);
            return BadRequest(data);
        }
    }
}
