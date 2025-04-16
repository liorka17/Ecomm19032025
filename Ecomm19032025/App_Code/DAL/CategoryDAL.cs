using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class CategoryDAL
    {

        public static Category GetById(int Cid)
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"SELECT * FROM T_Category Where Cid={Cid}";//משפט השאילתא
            DataTable Dt = Db.Execute(sql);
            Category Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Category()
                {
                    Cid = (int)Dt.Rows[0]["Cid"],//השמת ערך בשדה
                    Cname = (string)Dt.Rows[0]["Cname"]//השמת ערך בשדה
                };
                Db.Close();//סגירת החיבור לבסיס הנתונים
                return Tmp;
            }
            return new Category();
        }

        public static List<Category> GetAll()//מחזירה את כל הקטגוריות
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"SELECT * FROM T_Category";
            DataTable Dt = Db.Execute(sql);//מחזירה את כל הקטגוריות
            List<Category> lst = new List<Category>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Category Tmp = new Category();
                Tmp = new Category()
                {
                    Cid = (int)Dt.Rows[i]["Cid"],//השמת ערך בשדה
                    Cname = (string)Dt.Rows[i]["Cname"]//השמת ערך בשדה
                };
                lst.Add(Tmp);
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return lst;//מחזירה את הקטגוריה שנמחקה
        }

        public static int Save(Category Tmp)
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql;

            if (Tmp.Cid == -1)
            {
                sql = $"INSERT INTO T_Category (Cname) VALUES (N'{Tmp.Cname}')";
            }
            else
            {
                sql = $"UPDATE T_Category SET";
                sql += $"Cname=N'{Tmp.Cname}'";
                sql += $" WHERE Cid={Tmp.Cid}";
            }

            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            if (Tmp.Cid == -1)
            {
                sql = $"SELECT Max(Cid) FROM T_Category Where Cname='{Tmp.Cname}'";
                Tmp.Cid = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;
        }

        public static int DeleteById(int Cid)//מוחקת את הקטגוריה לפי קוד
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"DELETE FROM T_Category Where Cid={Cid}";//משפט השאילתא
            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;
        }
    }
}