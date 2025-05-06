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
            DbContext Db = new DbContext();
            string query = "SELECT * FROM T_Product";
            DataTable dt = Db.Execute(query);
            List<Product> lst = new List<Product>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product tmp = new Product()
                {
                    Pid = Convert.ToInt32(dt.Rows[i]["Pid"]),
                    Pname = dt.Rows[i]["Pname"].ToString(),
                    Pdesc = dt.Rows[i]["Pdesc"].ToString(),
                    Price = Convert.ToSingle(dt.Rows[i]["Price"]),
                    Picname = dt.Rows[i]["Picname"].ToString(),
                    Cid = Convert.ToInt32(dt.Rows[i]["Cid"]),
                };
                lst.Add(tmp);
            }
            Db.Close();
            return lst;
        }



        public static Product GetById(int Pid)
        {
            DbContext Db = new DbContext();
            string query = $"SELECT * FROM T_Product WHERE Pid = {Pid}";
            DataTable dt = Db.Execute(query);
            Product tmp = new Product();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmp = new Product()
                {
                    Pid = Convert.ToInt32(dt.Rows[i]["Pid"]),
                    Pname = dt.Rows[i]["Pname"].ToString(),
                    Pdesc = dt.Rows[i]["Pdesc"].ToString(),
                    Price = Convert.ToSingle(dt.Rows[i]["Price"]),
                    Picname = dt.Rows[i]["Picname"].ToString(),
                    Cid = Convert.ToInt32(dt.Rows[i]["Cid"]),
                };
            }

            Db.Close();
            return tmp;
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
