using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Model.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }


        public DateTime BirthDate { get; set; }


        public string EMail { get; set; }

        public string Token { get; set; }


    }
}
