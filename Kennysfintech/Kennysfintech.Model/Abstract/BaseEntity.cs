using Kennysfintech.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Model.Abstract
{
    public class BaseEntity
    {
        [CustomColumn(IsPrimaryKey = true, AllowNull = false)]
        public int Id { get; set; }
    }
}
