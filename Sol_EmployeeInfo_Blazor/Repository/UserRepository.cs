using Sol_EmployeeInfo_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_EmployeeInfo_Blazor.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUserDetails();

        Task<IEnumerable<UserModel>> GetUserDetails(string searchData);

        Task<UserModel> GetSingleUserDetails(int id);
    }

    public class UserRepository : IUserRepository
    {
        async Task<UserModel> IUserRepository.GetSingleUserDetails(int id)
        {
            try
            {
                var singleUserData = await ((IUserRepository)this).GetUserDetails();

                return singleUserData
                    ?.AsEnumerable()
                    ?.FirstOrDefault((leUserModel) => leUserModel.Id == id);
            }
            catch
            {
                throw;
            }
        }

        async Task<IEnumerable<UserModel>> IUserRepository.GetUserDetails()
        {
            return await Task.Run(() =>
            {
                var userList = new List<UserModel>();

                userList.Add(new UserModel()
                {
                    Id = 1,
                    FirstName = "Kishor",
                    LastName = "Naik",
                    Designation = "Solution Architect",
                    Department = "IT",
                    Age = 35,
                    Address = "Thane",
                    ImageURL = "/Images/KishorImages.jpg"
                });
                userList.Add(new UserModel()
                {
                    Id = 2,
                    FirstName = "Sonali",
                    LastName = "Joshi",
                    Designation = "Web Developer",
                    Department = "IT",
                    Age = 31,
                    Address = "Thane",
                    ImageURL = "/Images/sonali.jpg"
                });
                userList.Add(new UserModel()
                {
                    Id = 3,
                    FirstName = "Ashwini",
                    LastName = "Bhangale",
                    Designation = "Web Developer",
                    Department = "IT",
                    Age = 27,
                    Address = "Dombivali",
                    ImageURL = "/Images/Ashwini.jpg"
                });
                userList.Add(new UserModel()
                {
                    Id = 4,
                    FirstName = "Swati",
                    LastName = "Mane",
                    Designation = "Web Developer",
                    Department = "IT",
                    Age = 29,
                    Address = "Panvel",
                    ImageURL = "/Images/Swati.jpg"
                });
                userList.Add(new UserModel()
                {
                    Id = 5,
                    FirstName = "Rajashree",
                    LastName = "Mhatre",
                    Designation = "Web Developer",
                    Department = "IT",
                    Age = 30,
                    Address = "Thane",
                    ImageURL = "/Images/Rajashree.jpg"
                });
                userList.Add(new UserModel()
                {
                    Id = 6,
                    FirstName = "Bhushan",
                    LastName = "Pawar",
                    Designation = "Senior Manager",
                    Department = "Management",
                    Age = 35,
                    Address = "Thane",
                    ImageURL = "http://cliparts101.com/files/367/63BA654AECB7FD26A32D08915C923030/avatar_nick.png"
                });
                userList.Add(new UserModel()
                {
                    Id = 7,
                    FirstName = "Manisha",
                    LastName = "Giri",
                    Designation = "Senior Admin",
                    Department = "Management",
                    Age = 35,
                    Address = "Dombivali",
                    ImageURL = "/Images/Image1.jpg"
                });
                userList.Add(new UserModel()
                {
                    Id = 8,
                    FirstName = "Yogita",
                    LastName = "Shinde",
                    Designation = "Marketing Head",
                    Department = "Marketing",
                    Age = 28,
                    Address = "Dombivali",
                    ImageURL = "/Images/sonali1.jpg"
                }); ;
                return userList;
            });
        }

        async Task<IEnumerable<UserModel>> IUserRepository.GetUserDetails(string searchData)
        {
            try
            {
                var data = await ((IUserRepository)this).GetUserDetails();

                return !string.IsNullOrEmpty(searchData) ? data
                    ?.AsEnumerable()
                    ?.Where((leUserModel) => leUserModel.FirstName.Equals(searchData, StringComparison.OrdinalIgnoreCase) ||
                    leUserModel.LastName.Equals(searchData, StringComparison.OrdinalIgnoreCase) || leUserModel.Department.Equals(searchData, StringComparison.OrdinalIgnoreCase)
                    || leUserModel.Designation.Equals(searchData, StringComparison.OrdinalIgnoreCase)) : data;
            }
            catch
            {
                throw;
            }
        }
    }
}