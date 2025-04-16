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
        public static Product GetById(int Pid)
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"SELECT * FROM T_Product Where Pid={Pid}";//משפט השאילתא
            DataTable Dt = Db.Execute(sql);//מחזירה את המוצר לפי קוד המוצר
            Product Tmp = null;//יצירת מסתנה ייחוס מסוג מוצר מאותחל בנאל
            if (Dt.Rows.Count > 0)
            {

                Tmp = new Product()//יצירת אובייקט מסוג מוצר ומילוי השדות שלו עם הערכים שנשלפו ממסד הנתונים
                {
                    Pid = (int)Dt.Rows[0]["Pid"],//השמת ערך בשדה
                    Pname = (string)Dt.Rows[0]["Pname"],//השמת ערך בשדה
                    Pdesc = (string)Dt.Rows[0]["Pdesc"],//השמת ערך בשדה
                    Price = (float)Dt.Rows[0]["Price"],//השמת ערך בשדה
                    Cid = (int)Dt.Rows[0]["Cid"]//השמת ערך בשדה
                };
                Db.Close();//סגירת החיבור לבסיס הנתונים
                return Tmp;//מחזירה את המוצר
            }
            return new Product();//מחזירה מוצר חדש
        }


        public static List <Product> GetAll()
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"SELECET * FROM T_Product";//משפט השאילתא
            DataTable Dt = Db.Execute(sql);//מחזירה את כל המוצרים
            

            List<Product> lst = new List<Product>();//יצירת מסתנה ייחוס מסוג מוצר מאותחל בנאל

            for(int i = 0; i < Dt.Rows.Count; i++)
                        
            {
                Product Tmp = new Product();//יצירת אובייקט מסוג מוצר

                Tmp = new Product()//יצירת אובייקט מסוג מוצר ומילוי השדות שלו עם הערכים שנשלפו ממסד הנתונים
                {
                    Pid = (int)Dt.Rows[i]["Pid"],//השמת ערך בשדה
                    Pname = (string)Dt.Rows[i]["Pname"],//השמת ערך בשדה
                    Pdesc = (string)Dt.Rows[i]["Pdesc"],//השמת ערך בשדה
                    Price = (float)Dt.Rows[i]["Price"],//השמת ערך בשדה
                    Cid = (int)Dt.Rows[i]["Cid"]//השמת ערך בשדה
                };

                lst.Add(Tmp);//הוספת המוצר לרשימה
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return lst;//מחזירה את כל רשימת כל המוצרים
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
