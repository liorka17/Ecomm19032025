using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class UsersDAL
    {

        public static Users GetById(int Uid)
        {
            DbContext Db = new DbContext();
            string sql = $"SELECT * FROM T_Users Where Uid={Uid}";
            DataTable Dt = Db.Execute(sql);
            Users Tmp = null;
            if (Dt.Rows.Count > 0)
            {
                Tmp = new Users()
                {
                    Uid = (int)Dt.Rows[0]["Uid"],
                    FullName = (string)Dt.Rows[0]["FullName"],
                    Pass = (string)Dt.Rows[0]["Pass"],
                    Email = (string)Dt.Rows[0]["Email"],
                    Phone = (string)Dt.Rows[0]["Phone"],
                    Address = (string)Dt.Rows[0]["Address"]
                };

                Db.Close();//סגירת החיבור לבסיס הנתונים
                return Tmp;
            }
            return new Users();
        }

        public static List<Users> GetAll()//מחזירה את כל היוזרים
        {
            DbContext Db = new DbContext();
            string sql = $"SELECT * FROM T_Users";
            DataTable Dt = Db.Execute(sql);//מחזירה את כל היוזרים
            List<Users> lst = new List<Users>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Users Tmp = new Users();//יצירת אובייקט מסוג יוזר
                Tmp = new Users()//יצירת אובייקט מסוג יוזר ומילוי השדות שלו עם הערכים שנשלפו ממסד הנתונים
                {
                    Uid = (int)Dt.Rows[i]["Uid"],
                    FullName = (string)Dt.Rows[i]["FullName"],
                    Pass = (string)Dt.Rows[i]["Pass"],
                    Email = (string)Dt.Rows[i]["Email"],
                    Phone = (string)Dt.Rows[i]["Phone"],
                    Address = (string)Dt.Rows[i]["Address"]
                };
                lst.Add(Tmp);//הוספת היוזר לרשימה
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return lst;//מחזירה את היוזרים
        }

        public static int Save(Users Tmp)//שומר את היוזר
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql;
            if (Tmp.Uid == -1)//אם קוד היוזר שווה ל-1 כלומר יוזר חדש
            {
                sql = $"INSERT INTO T_Users(FullName, Pass, Email, Phone, Address)";
                sql += $" VALUES(N'{Tmp.FullName}',N'{Tmp.Pass}',N'{Tmp.Email}',N'{Tmp.Phone}',N'{Tmp.Address}')";
            }

            else

            {
                sql = $"UPDATE T_Users SET";
                sql += $"FullName=N'{Tmp.FullName}',";
                sql += $"Pass=N'{Tmp.Pass}',";
                sql += $"Email=N'{Tmp.Email}',";
                sql += $"Phone=N'{Tmp.Phone}',";
                sql += $"Address=N'{Tmp.Address}'";
                sql += $" WHERE Uid={Tmp.Uid}";
            }
            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            if (Tmp.Uid == -1)//אם קוד היוזר שווה ל-1 כלומר יוזר חדש
            {
                sql = $"SELECT Max(Uid) FROM T_Users Where FullName='{Tmp.FullName}'";
                Tmp.Uid = (int)Db.ExecuteScalar(sql);//מחזירה את היוזר שנשמר
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;//מחזירה את היוזר שנשמר
        }

        public static int DeleteById(int Uid)//מוחקת את היוזר לפי קוד
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"DELETE FROM T_Users WHERE Uid={Uid}";
            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;//מחזירה את היוזר שנמחק
        }
    }
}