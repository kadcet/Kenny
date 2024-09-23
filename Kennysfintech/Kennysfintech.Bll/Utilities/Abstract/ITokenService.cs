using Kennysfintech.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Utilities.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(UserDto user);
    }
}
