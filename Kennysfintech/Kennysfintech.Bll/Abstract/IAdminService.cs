using Kennysfintech.Model.KennysfintechModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Abstract
{
    public interface IAdminService
    {
        public IResult MigrateDatabase();
    }
}
