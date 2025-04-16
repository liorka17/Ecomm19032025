using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DATA
{
    public class DbContext
    {
        public string Connstr { get; set; }//מכילה את מחרוזת החיבור

        public SqlConnection Conn { get; set; }//מכילה את החיבור למסד הנתונים

        public DbContext()
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30";//מחרוזת התחברות
            SqlConnection Conn = new SqlConnection(ConnStr);//אובייקט קונקשן שמקבל את מחרוזת ההתחברות לבסיס הנתונים
            Conn.Open();//פתיחת הקונקשן לבסיס הנתונים

        }
        public void Close()//סגירת החיבור
        {
            Conn.Close();//סגירת החיבור לבסיס הנתונים
        }

        public int ExecuteNonQuery(string sql)//מבצעת שאילתא שאינה מחזירה ערך
        {
            SqlCommand Cmd = new SqlCommand(sql, Conn);//אובייקט פקודה שמקבל את המשפט ואת הקונקשן
            return Cmd.ExecuteNonQuery();//מחזירה מספר שורות שהוסרו מהמסד נתונים
        }

        public DataTable Execute(string sql)//מבצעת שאילתא שמחזירה ערך
        {
            SqlCommand Cmd = new SqlCommand(sql, Conn);//אובייקט פקודה שמקבל את המשפט ואת הקונקשן
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);//אובייקט דאטה אדפטר שמקבל את הפקודה
            DataTable Dt = new DataTable();//יצירת דאטה טבלה
            Da.SelectCommand = Cmd;//מגדירים את הפקודה של האדפטר
            Da.Fill(Dt);//ממלאים את הטבלה בדאטה
            return Dt;//מחזירים את הדאטה טבלה
        }

        public int ExecuteScalar(string sql)//מבצעת שאילתא שמחזירה ערך בודד
        {
            SqlCommand Cmd = new SqlCommand(sql, Conn);//אובייקט פקודה שמקבל את המשפט ואת הקונקשן
            return (int)Cmd.ExecuteScalar();//מחזירה את הערך הבודד
        }
    }
}