using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Orders
    {
        public int OrderId { get; set; }//מספר הזמנה

        public int Uid { get; set; }//מספר משתמש

        public float TotalAmount { get; set; }//סכום כולל

        public float TotalPrice { get; set; }//סכום כולל

        public string Status { get; set; }//סטטוס

        public static Orders GetById(int OrderId)//מחזירה אובייקט הזמנה לפי קוד
        {
            return OrdersDAL.GetById(OrderId);//מחזירה את הפונקציה שמחזירה את ההזמנה לפי הקוד
        }

        public static List<Orders> GetAll()//מחזירה את כל ההזמנות
        {
            return new List<Orders>();//מחזירה רשימה חדשה של הזמנות
        }

        public int Save()//שומר את ההזמנה
        {
            return OrdersDAL.Save(this);//מחזירה את הפונקציה ששומרת את המוצר
        }

        public static int DeleteById(int OrderId)//מוחקת את ההזמנה לפי קוד
        {
            return OrdersDAL.DeleteById(OrderId);//מחזירה את הפונקציה שמוחקת את ההזמנה לפי הקוד
        }
    }
}