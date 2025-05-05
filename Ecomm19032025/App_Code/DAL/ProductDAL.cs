using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;//קישוור לספריית השאילתות והעבודה מול מסד נתונים
using System.Data;//קישור לספריית הנתונים לעבודה מול מבנה נתונים    
using DATA;

namespace DAL
{
    public class ProductDAL
    {

        public static List<Product> GetAll()
        {
            DbContext Db = new DbContext(); // חיבור למסד הנתונים
            string query = "SELECT * FROM T_Product"; // שאילתה לשליפת כל המוצרים
            DataTable dt = Db.Execute(query); // קבלת תוצאות כטבלה
            List<Product> lst = new List<Product>(); // יצירת רשימה ריקה של מוצרים

            for (int i = 0; i < dt.Rows.Count; i++) // מעבר על כל שורה בטבלה
            {
                Product tmp = new Product() // יצירת אובייקט מוצר מהשורה
                {
                    Pid = (int)(dt.Rows[i]["Pid"]),
                    Pname = dt.Rows[i]["Pname"].ToString(),
                    Pdesc = dt.Rows[i]["Pdesc"].ToString(),
                    Price = (float)(dt.Rows[i]["Price"]), // במקום ToSingle
                    Picname = dt.Rows[i]["Picname"].ToString(),
                    Cid = Convert.ToInt32(dt.Rows[i]["Cid"]),
                };
                lst.Add(tmp); // הוספה לרשימה
            }

            Db.Close(); // סגירת החיבור
            return lst; // החזרת הרשימה
        }



        public static Product GetById(int Pid) // פונקציה סטטית שמחזירה מוצר לפי מזהה
        {
            DbContext Db = new DbContext(); // יצירת אובייקט של מחלקת DbContext כדי לעבוד מול בסיס הנתונים

            string query = $"SELECT * FROM T_Product WHERE Pid = {Pid}"; // שאילתת SQL שמביאה מוצר לפי מזהה
            DataTable dt = Db.Execute(query); // הרצת השאילתה וקבלת התוצאה כטבלת DataTable

            Product tmp = new Product(); // יצירת אובייקט ריק מסוג Product שנחזיר בסוף

            for (int i = 0; i < dt.Rows.Count; i++) // לולאה (למרות שתהיה רק שורה אחת אם ה-ID תקין)
            {
                tmp = new Product() // מילוי האובייקט מהשורה שמוחזרת מה-DataTable
                {
                    Pid = (int)(dt.Rows[i]["Pid"]), // המרה ממחרוזת למספר של מזהה המוצר
                    Pname = dt.Rows[i]["Pname"].ToString(),   // שם המוצר
                    Pdesc = dt.Rows[i]["Pdesc"].ToString(),   // תיאור המוצר
                    Price = (float)(dt.Rows[i]["Price"]), // המרת המחיר למספר מסוג float
                    Picname = dt.Rows[i]["Picname"].ToString(), // שם קובץ התמונה
                    Cid = Convert.ToInt32(dt.Rows[i]["Cid"])     // מזהה קטגוריה
                };
            }

            Db.Close(); // סגירת החיבור למסד הנתונים
            return tmp; // החזרת המוצר שמצאנו
        }



        public static int Save(Product Tmp)//שומר את המוצר
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql;

            if (Tmp.Pid == -1)//אם קוד המוצר שווה ל-1 כלומר מוצר חדש
            {
                sql = $"INSERT INTO T_Product(Pname, Pdesc, Price, Cid, PicName, Status)";
                sql += $" VALUES(N'{Tmp.Pname}',,N'{Tmp.Pdesc}',,N'{Tmp.Price}',,N'{Tmp.Cid}',,'{Tmp.Picname}',,'{Tmp.Status}')";//משפט השאילתא
            }
            else//אם לא
            {
                sql = $"UPDATE T_Product SET";
                sql += $"Pname=N'{Tmp.Pname}',";
                sql += $"Pdesc=N'{Tmp.Pdesc}',";
                sql += $"Price=N'{Tmp.Price}',";
                sql += $"Cid=N'{Tmp.Cid}',";
                sql += $"PicName=N'{Tmp.Picname}',";
                sql += $"Status=N'{Tmp.Status}'";
                sql += $" WHERE Pid={Tmp.Pid}";//משפט השאילתא
            }

            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            if (Tmp.Pid == -1)//אם קוד המוצר שווה ל-1 כלומר מוצר חדש
            {
                sql = $"SELECT Max(Pid) FROM T_Product Where Pname='{Tmp.Pname}'";//משפט השאילתא
                Tmp.Pid = (int)Db.ExecuteScalar(sql);//מחזירה את המוצר שנשמר
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;//מחזירה את המוצר שנשמר
        }

        public static int DeleteById(int Pid)//מוחקת את המוצר לפי קוד
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"DELETE FROM T_Product Where Pid={Pid}";//משפט השאילתא
            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;//מחזירה את המוצר שנמחק
        }
    }
}
