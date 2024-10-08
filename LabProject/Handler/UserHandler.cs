using LabProject.Factory;
using LabProject.Model;
using LabProject.Modules;
using LabProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Handler
{
    public class UserHandler
    {
        public static User GetUserByID(int id)
        {
            return UserRepository.GetUserByID(id);
        }

        public static List<User> GetAllCustomer()
        {
            return UserRepository.GetAllCustomer();
        }

        public static User GetUserByName(string name)
        {
            return UserRepository.GetUserByName(name);
        }

        public static Response<User> Login(string name, string password)
        {
            User user = UserRepository.GetUserByName(name);

            if (user == null)
            {
                return new Response<User>()
                {
                    Message = "User not found",
                    IsSuccess = false,
                    Payload = null
                };
            }
            if (!password.Equals(user.UserPassword))
            {
                return new Response<User>()
                {
                    Message = "Incorrect Password",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<User>()
            {
                Message = "Success",
                IsSuccess = true,
                Payload = user
            };
        }

        public static HttpCookie addCookie(int id)
        {
            HttpCookie cookie = new HttpCookie("user-cred");
            cookie.Value = Convert.ToString(id);
            cookie.Expires = DateTime.Now.AddHours(1);

            return cookie;
        }

        public static int GenerateUserId()
        {
            User user = UserRepository.GetLastUser();
            if (user == null)
            {
                return 1;
            }
            int lastId = user.UserID;
            lastId++;
            return lastId;
        }

        public static Response<User> Register(string name, string email, DateTime DOB, string gender, string password)
        {
            User user = UserFactory.Create(GenerateUserId(), name, email, DOB, gender, "customer", password);
            UserRepository.CreateUser(user);
            return new Response<User>()
            {
                Message = "Success",
                IsSuccess = true,
                Payload = user
            };
        }

        public static Response<User> UpdateProfile(User user, string name, string email, DateTime DOB, string gender)
        {
            UserRepository.UpdateProfile(user, name, email, DOB, gender);
            return new Response<User>()
            {
                Message = "Successfully update profile",
                IsSuccess = true,
                Payload = user
            };
        }

        public static Response<User> UpdatePassword(User user, string newpass)
        {
            UserRepository.UpdatePassword(user, newpass);
            return new Response<User>()
            {
                Message = "Successfully update password",
                IsSuccess = true,
                Payload = user
            };
        }
    }
}