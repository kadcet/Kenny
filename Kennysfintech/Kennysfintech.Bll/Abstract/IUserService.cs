using Kennysfintech.Model.Dto;
using Kennysfintech.Model.KennysfintechModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Abstract
{
    public interface IUserService
    {
        public IDataResult<UserDto> Login(LoginDto val);
    }
}
