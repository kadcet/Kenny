using Kennysfintech.Bll.Abstract;
using Kennysfintech.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kennysfintech.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }





        [HttpPost(Name = "Login")] // Kullanıcıdan bir model obje alacak isek post,put,patch kullanılır
        public ActionResult Login(LoginDto val)
        {
            var res = _userService.Login(val);
            //if (res.Success) return Ok(res);
            if (res.Success)
            {
                return Ok(res);
                //Ok(new
                //{
                //    User = res.Data,

                //});
            }


            return Unauthorized(res.Message);
            //return BadRequest(res);


        }


    }
}
