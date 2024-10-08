using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Repository
{
    public class UserRepository
    {
        public static Database1Entities2 db = new Database1Entities2();

        public static User GetUserByID(int id)
        {
            User user = db.Users.Find(id);
            return user;
        }

        public static List<User> GetAllCustomer()
        {
            return (from x in db.Users where x.UserRole.Equals("customer") select x).ToList();
        }

        public static User GetUserByName(string name)
        {
            User user = db.Users.Where(i => i.Username == name).FirstOrDefault();
            return user;
        }

        public static User GetLastUser()
        {
            User user = db.Users.ToList().LastOrDefault();
            return user;
        }

        public static void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static void UpdateProfile(User user, string name, string email, DateTime DOB, string gender)
        {
            user.Username = name;
            user.UserEmail = email;
            user.UserDOB = DOB;
            user.UserGender = gender;
            db.SaveChanges();
            return;
        }

        public static void UpdatePassword(User user, string newpass)
        {
            user.UserPassword = newpass;
            db.SaveChanges();
            return;
        }
    }
}