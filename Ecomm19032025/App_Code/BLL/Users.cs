using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;


namespace BLL//BLL - Business Logic Layer
{
    public class Users//מחלקת משתמשים
    {
        public int Uid { get; set; }//שדה קוד משתמש

        public string FullName { get; set; }//שדה שם מלא

        public string Pass { get; set; }//שדה סיסמא

        public string Email { get; set; }//שדה אימייל

        public string Phone { get; set; }//שדה טלפון

        public string Address { get; set; }//שדה כתובת

        public int Status { get; set; }//שדה סטטוס 

        public static Users GetById(int Uid)//מחזירה אובייקט משתמש לפי קוד
        {
            return UsersDAL.GetById(Uid);//מחזירה אובייקט משתמש
        }

        public static List<Users> GetAll()//מחזירה את כל המשתמשים
        {
            return new List<Users>();//מחזירה רשימה חדשה של משתמשים
        }

        public int Save()//שומר את המשתמש
        {
            return UsersDAL.Save(this);//מחזירה את הפונקציה ששומרת את המשתמש
        }

        public static int DeleteById(int Uid)//מוחקת את המשתמש לפי קוד
        {
            return UsersDAL.DeleteById(Uid);//מחזירה את הפונקציה שמוחקת את המשתמש לפי הקוד
        }
    }
}