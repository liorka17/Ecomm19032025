using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL//BLL - Business Logic Layer
{
    public class Product//מחלקת מוצרים
    {
        //Pid, Pname, Pdesc, price, Cid, Picname
        public int Pid { get; set; }

        public string Pname { get; set; }//שם המוצר

        public string Pdesc { get; set; }//תיאור המוצר

        public float Price { get; set; }//מחיר המוצר

        public int Cid { get; set; }//קטגוריה

        public string Picname { get; set; }//שם התמונה

        public int Status { get; set; }//סטטוס המוצר    

        public static Product GetById(int Pid)//מקבלת קוד מוצר ומחזירה אובייקט מוצר
        {
            return ProductDAL.GetById(Pid);//מחזירה את הפונקציה שמחזירה את המוצר לפי הקוד
        }

        public static List<Product> GetAll()//מחזירה את כל המוצרים
        {
            return ProductDAL.GetAll();//מחזירה רשימה חדשה של מוצרים
        }

        public int Save( )
        {
            return ProductDAL.Save(this);//מחזירה את הפונקציה ששומרת את המוצר
        }

        public static int DeleteById(int Pid)//מקבלת קוד מוצר ומוחקת את המוצר
        {
            return ProductDAL.DeleteById(Pid);//מחזירה את הפונקציה שמוחקת את המוצר לפי הקוד
        }
    }
}