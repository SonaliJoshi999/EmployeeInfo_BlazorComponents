using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_EmployeeInfo_Blazor.Models;
using Sol_EmployeeInfo_Blazor.Repository;
using Sol_EmployeeInfo_Blazor.ViewModel;

namespace Sol_EmployeeInfo_Blazor.Controllers
{
    public class UsersController : Controller
    {
        #region Declaration
        private readonly IUserRepository userRepository = null;
        #endregion

        #region Property
        [BindProperty]
        public UserViewModel UserVM { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        #endregion

        #region Constructor
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.UserVM = new UserViewModel();
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            UserVM.UsersList = (await this.userRepository?.GetUserDetails()).ToList();
            TempData["UserList"] = JsonConvert.SerializeObject(UserVM.UsersList);
            TempData.Keep();

            return View(UserVM);
        }

        [HttpGet]
        public IActionResult Details()
        {
            var userList = JsonConvert.DeserializeObject<List<UserModel>>(TempData["UserList"] as String);
            TempData.Keep();

            UserVM.SingleUserDetails =
                    userList
                    ?.AsEnumerable()
                    ?.FirstOrDefault((leUserModel) => leUserModel.Id == Id);

            return View(UserVM);
        }

        [HttpGet]
        public async Task<IActionResult> OnSearch()
        {
            UserVM.UsersList = (await this.userRepository?.GetUserDetails(this.SearchQuery)).ToList();
            UserVM.SearchQuery = this.SearchQuery;
            ViewBag.JavascriptFunction = string.Format("ShowSearchMessage('{0}');", UserVM.UsersList?.Count() == 0 ? 1 : 0);
            return View("Index", UserVM);
        }
    }
}