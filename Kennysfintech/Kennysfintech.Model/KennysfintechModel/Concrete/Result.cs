using Kennysfintech.Model.KennysfintechModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Model.KennysfintechModel.Concrete
{
    public class Result : IResult
    {
        protected Result(bool success, string message) : this(success)
        {
            Message = message;
        }


        protected Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }

    }
}
