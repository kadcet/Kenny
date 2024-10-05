using Kennysfintech.Model.Abstract;
using Kennysfintech.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Model.Entity
{
    public class Truva:BaseEntity
    {
        public string CompanyName { get; set; }

        public IOC IOC { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string InvoiceNumber { get; set; }

        public DC DC { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal Payment { get; set; }

        public decimal Balance { get; set; }
    }
}
