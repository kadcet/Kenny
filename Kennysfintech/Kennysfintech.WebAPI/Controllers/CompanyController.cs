using Kennysfintech.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kennysfintech.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        
        [HttpGet(Name = "GetAllCompany")]
        public ActionResult GetAllCompany()
        {
            var res = _companyService.GetAllCompany();
            if (res.Success) return Ok(res);

            return BadRequest(res);
        }

        [HttpGet(Name = "GetByIdCompany")]
        public ActionResult GetByIdCompany(int code)
        {
            var res = _companyService.GetByIdInvoice(code);
            if (res.Success) return Ok(res);
            return BadRequest(res);
        }
    }
}
