using LabProject.Handler;
using LabProject.Model;
using LabProject.Modules;
using LabProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LabProject.Controller
{
    public class UserController
    {
        public static User GetUserByID(int id)
        {
            return UserHandler.GetUserByID(id);
        }

        public static List<User> GetAllCustomer()
        {
            return UserHandler.GetAllCustomer();
        }

        public static Response<User> Login(string username, string password)
        {
            string error = "";
            if (error.Equals(""))
            {
                return UserHandler.Login(username, password);
            }
            return new Response<User>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static HttpCookie addCookie(int id)
        {
            return UserHandler.addCookie(id);
        }

        public static Response<User> Register(string name, string email, DateTime DOB, string gender, string password, string confPass)
        {
            if(name.Length < 5 || name.Length > 15)
            {
                return new Response<User>()
                {
                    Message = "Username Length must be between 5 and 15 alphabet",
                    IsSuccess = false,
                    Payload = null
                };
            }
            
            if(UserHandler.GetUserByName(name) != null)
            {
                return new Response<User>()
                {
                    Message = "Username already exist",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (!email.EndsWith(".com"))
            {
                return new Response<User>()
                {
                    Message = "email must end with.com",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(string.IsNullOrEmpty(gender))
            {
                return new Response<User>()
                {
                    Message = "Please select your gender",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(string.IsNullOrEmpty(password))
            {
                return new Response<User>()
                {
                    Message = "Please input your password",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (!confPass.Equals(password))
            {
                return new Response<User>()
                {
                    Message = "Password is not the same",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(DOB == default)
            {
                return new Response<User>()
                {
                    Message = "Please input your Date of Birth",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(DOB > DateTime.Now)
            {
                return new Response<User>()
                {
                    Message = "Please input a valid date",
                    IsSuccess = false,
                    Payload = null
                };
            }

            String error = "";
            if (error.Equals(""))
            {
                return UserHandler.Register(name, email, DOB, gender, password);
            }
            return new Response<User>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<User> UpdateProfile(User user, string name, string email, DateTime DOB, string gender)
        {
            if (name.Length < 5 || name.Length > 15)
            {
                return new Response<User>()
                {
                    Message = "Username Length must be between 5 and 15 alphabet",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (UserHandler.GetUserByName(name) != null)
            {
                return new Response<User>()
                {
                    Message = "Username already exist",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (!email.EndsWith(".com"))
            {
                return new Response<User>()
                {
                    Message = "email must end with.com",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (string.IsNullOrEmpty(gender))
            {
                return new Response<User>()
                {
                    Message = "Please select your gender",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (DOB == default)
            {
                DOB = user.UserDOB;
            }

            if (DOB > DateTime.Now)
            {
                return new Response<User>()
                {
                    Message = "Please input a valid date",
                    IsSuccess = false,
                    Payload = null
                };
            }

            String error = "";
            if (error.Equals(""))
            {
                return UserHandler.UpdateProfile(user, name, email, DOB, gender);
            }
            return new Response<User>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<User> UpdatePassword(User user, string oldpass, string newpass)
        {

            if (string.IsNullOrEmpty(oldpass))
            {
                return new Response<User>()
                {
                    Message = "Please input your password",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (!oldpass.Equals(user.UserPassword))
            {
                return new Response<User>()
                {
                    Message = "Password is not the same",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (string.IsNullOrEmpty(newpass))
            {
                return new Response<User>()
                {
                    Message = "Please input your password",
                    IsSuccess = false,
                    Payload = null
                };
            }

            String error = "";
            if (error.Equals(""))
            {
                return UserHandler.UpdatePassword(user, newpass);
            }
            return new Response<User>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }
    }
}