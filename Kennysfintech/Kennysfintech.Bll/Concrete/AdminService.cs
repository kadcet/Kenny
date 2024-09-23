using Kennysfintech.Bll.Abstract;
using Kennysfintech.Dal.Helper;
using Kennysfintech.Model.KennysfintechModel.Abstract;
using Kennysfintech.Model.KennysfintechModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Concrete
{
    public class AdminService : IAdminService
    {
        public IResult MigrateDatabase()
        {
            try
            {
                var mgr = new MigrationHelper();
                mgr.MigrateDB();

                return new SuccessResult("Tablolar Oluşturuldu Foreign keyler bağlandı");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.ToString());
            }
        }

       
    }
}
