using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_EmployeeInfo_Blazor.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
    }
}
