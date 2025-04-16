using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLL;
using DATA;

namespace DAL
{
    public class OrdersDAL
    {

        public static Orders GetById(int OrderID)
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql = $"SELECT * FROM T_Orders Where OrderID={OrderID}";
            DataTable Dt = Db.Execute(sql);
            Orders Tmp = null;
            if (Dt.Rows.Count > 0)
            {

                Tmp = new Orders()
                {
                    OrderId = (int)Dt.Rows[0]["OrderId"],
                    Uid = (int)Dt.Rows[0]["Uid"],
                    TotalPrice = (float)Dt.Rows[0]["TotalPrice"],
                    TotalAmount = (float)Dt.Rows[0]["TotalAmount"],
                    Status = (string)Dt.Rows[0]["Status"]

                };
                Db.Close();//סגירת החיבור לבסיס הנתונים
                return Tmp;
            }
            return new Orders();
        }

        public static List<Orders> GetAll()//מחזירה את כל ההזמנות
        {
            DbContext Db = new DbContext();
            string sql = $"SELECET * FROM T_Orders";
            DataTable Dt = Db.Execute(sql);
            List<Orders> lst = new List<Orders>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Orders Tmp = new Orders();
                Tmp = new Orders()
                {
                    OrderId = (int)Dt.Rows[i]["OrderId"],
                    Uid = (int)Dt.Rows[i]["Uid"],
                    TotalPrice = (float)Dt.Rows[i]["TotalPrice"],
                    TotalAmount = (float)Dt.Rows[i]["TotalAmount"],
                    Status = (string)Dt.Rows[i]["Status"]
                };
                lst.Add(Tmp);
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return lst;
        }

        public static int Save(Orders Tmp)//שומר את ההזמנה
        {
            DbContext Db = new DbContext();//יצירת אובייקט מסוג דאטה בייס
            string sql;
            if (Tmp.OrderId == -1)//אם קוד ההזמנה שווה ל-1 כלומר הזמנה חדשה
            {
                sql = $"INSERT INTO T_Orders(Uid, TotalPrice, TotalAmount, Status)";
                sql += $" VALUES(N'{Tmp.Uid}',,N'{Tmp.TotalPrice}',,N'{Tmp.TotalAmount}',,'{Tmp.Status}')";
            }
            else
            {
                sql = $"UPDATE T_Orders SET";
                sql += $"Uid=N'{Tmp.Uid}',";
                sql += $"TotalPrice=N'{Tmp.TotalPrice}',";
                sql += $"TotalAmount=N'{Tmp.TotalAmount}',";
                sql += $"Status=N'{Tmp.Status}'";
                sql += $" WHERE OrderId={Tmp.OrderId}";
            }
            int i = Db.ExecuteNonQuery(sql);//מחזירה מספר שורות שהוסרו מהמסד נתונים
            if (Tmp.OrderId == -1)//אם קוד ההזמנה שווה ל-1 כלומר הזמנה חדשה
            {
                sql = $"SELECT Max(OrderId) FROM T_Orders Where OrderId='{Tmp.OrderId}'";
                Tmp.OrderId = (int)Db.ExecuteScalar(sql);//מחזירה את ההזמנה שנשמרה
            }
            Db.Close();//סגירת החיבור לבסיס הנתונים
            return i;//מחזירה את ההזמנה שנשמרה
        }

        public static int DeleteById(int OrderId)//מוחקת את ההזמנה לפי קוד
        {
            DbContext Db = new DbContext();
            string sql = $"DELETE FROM T_Orders Where OrderId={OrderId}";
            int i = Db.ExecuteNonQuery(sql);
            Db.Close();
            return i;
        }
    }
}