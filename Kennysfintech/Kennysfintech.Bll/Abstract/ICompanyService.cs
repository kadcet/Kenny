using Kennysfintech.Model.Dto;
using Kennysfintech.Model.Entity;
using Kennysfintech.Model.KennysfintechModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Abstract
{
    public interface ICompanyService
    {
        public IDataResult<List<CompanyCodeAndNameDto>> GetAllCompany();

        public IDataResult<List<Truva>> GetByIdInvoice(int code);
    }
}
