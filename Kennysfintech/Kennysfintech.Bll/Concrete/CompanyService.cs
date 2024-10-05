using Kennysfintech.Bll.Abstract;
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
    public class CompanyService : ICompanyService
    {

        private readonly IRepositoryService _repo;

        public CompanyService(IRepositoryService repo)
        {
            _repo = repo;
        }

        public IDataResult<List<CompanyCodeAndNameDto>> GetAllCompany()
        {
            var sql = $@"select CompCode,CompanyName from Truva group by CompCode,CompanyName";

            var data = _repo.Get<CompanyCodeAndNameDto>(sql);
            return new SuccessDataResult<List<CompanyCodeAndNameDto>>(data);
        }

       

        public IDataResult<List<Truva>> GetByIdInvoice(int code)
        {
            var sql = $@"select * from Truva where CompCode=@companyCode";

            var data = _repo.Get<Truva>(sql,new {companyCode=code});
            return new SuccessDataResult<List<Truva>>(data);
        }

        
    }
}
