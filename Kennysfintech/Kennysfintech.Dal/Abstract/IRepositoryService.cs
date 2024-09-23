using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Dal.Abstract
{
    public interface IRepositoryService
    {
        public List<T> Get<T>(string sqlcmd, object prm);
        public List<T> Get<T>(string sqlcmd);
        public T GetFirstOrDefault<T>(string sqlcmd, object prm);
        public T GetFirstOrDefault<T>(string sqlcmd);
        public int Insert<T>(T entity);
        public int Update<T>(T entity, string updateOnlyThisFields);
        public int Update<T>(T entity);
        public int Delete<T>(T entity);

    }
}
