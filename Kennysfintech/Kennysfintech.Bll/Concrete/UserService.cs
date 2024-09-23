using Kennysfintech.Bll.Abstract;
using Kennysfintech.Bll.Utilities.Abstract;
using Kennysfintech.Dal.Abstract;
using Kennysfintech.Model.Dto;
using Kennysfintech.Model.Entity;
using Kennysfintech.Model.KennysfintechModel.Abstract;
using Kennysfintech.Model.KennysfintechModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ITokenService _tokenService;

        public UserService(IRepositoryService repositoryService, ITokenService tokenService)
        {
            _repositoryService = repositoryService;
            _tokenService = tokenService;
        }

        public IDataResult<UserDto> Login(LoginDto val)
        {
            try
            {
                var sql = $"select Id,NameSurname,UserName,BirthDate,EMail from [User] where Username=@Username and Password=@Password";
                var usr = _repositoryService.GetFirstOrDefault<User>(sql, val);
                if (usr == null) return new ErrorDataResult<UserDto>("Geçersiz Kullanıcı Adı Yada Şifre");
                //if (usr == null) return new UnauthorizedAccessException("Geçersiz Kullanıcı Adı Yada Şifre");


                var userDto = new UserDto();

                userDto.Id = usr.Id;
                userDto.UserName = usr.UserName;
                userDto.NameSurname = usr.NameSurname;
                userDto.BirthDate = usr.BirthDate;
                userDto.EMail = usr.EMail;
                // JWT tokeni üretiyoruz
                var token = _tokenService.GenerateToken(userDto);
                userDto.Token = token;


                return new SuccessDataResult<UserDto>(userDto);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserDto>(ex.ToString());
            }


        }
    }
}
