using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class UserFactory
    {
        public static User Create(int userID, string username, string userEmail, DateTime userDOB, string userGender, string userRole, string userPassword)
        {
            User user = new User() 
            {
                UserID = userID,
                Username = username,
                UserEmail = userEmail,
                UserGender = userGender,
                UserRole = userRole,
                UserDOB = userDOB,
                UserPassword = userPassword
            };

            return user;
        }
    }
}