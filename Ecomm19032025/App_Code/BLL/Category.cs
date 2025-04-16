using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Category
    {
        public int Cid { get; set; }

        public string Cname { get; set; }//שם הקטגוריה

        public int Status { get; set; }//שדה סטטוס 


        public static Category GetById(int Cid)//מחזירה אובייקט קטגוריה לפי קוד
        {
            return CategoryDAL.GetById(Cid);//מחזירה את הפונקציה שמחזירה את הקטגוריה לפי הקוד
        }

        public static List<Category> GetAll()//מחזירה את כל הקטגוריות
        {
            return new List<Category>();//מחזירה רשימה חדשה של קטגוריות
        }

        public int Save()//שומר את הקטגוריה
        {
            return CategoryDAL.Save(this);//מחזירה את הפונקציה ששומרת את המוצר
        }

        public static int DeleteById(int Cid)//מוחקת את הקטגוריה לפי קוד
        {
            return CategoryDAL.DeleteById(Cid);//מחזירה את הפונקציה שמוחקת את הקטגוריה לפי הקוד
        }
    }
}