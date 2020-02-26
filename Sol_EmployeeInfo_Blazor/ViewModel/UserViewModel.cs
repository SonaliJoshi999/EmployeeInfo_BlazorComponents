using Sol_EmployeeInfo_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_EmployeeInfo_Blazor.ViewModel
{
    public class UserViewModel
    {
        public List<UserModel> UsersList { get; set; }

        public UserModel SingleUserDetails { get; set; }
        public string SearchQuery { get; set; }
    }
}
