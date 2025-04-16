using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Ecomm19032025
{
	public partial class login : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            List<Users> LstUsers = new List<Users>();//יצירת רשימה של משתמשים		
            Users Tmp;//יצירת משתנה זמני
            Tmp = new Users()
            {
                Uid = 2,
                Email = "liorka17@gmail.com",
                Pass = "123",
                Address = "ashkelon",
                FullName = "lior",
                Phone = "054-1234567",
            };
            LstUsers.Add(Tmp);
            Tmp = new Users()
            {
                Uid = 3,
                Email = "alon@gmail.com",
                Pass = "123",
                Address = "ashkelon",
                FullName = "alon kalandarov",
                Phone = "054-5555557",
            };
            LstUsers.Add(Tmp);
            Tmp = new Users()
            {
                Uid = 4,
                Email = "liel@gmail.com",
                Pass = "123",
                Address = "ashkelon",
                FullName = "liel kalandarov",
                Phone = "054-1222222",
            };
            LstUsers.Add(Tmp);
            Tmp = new Users()
            {
                Uid = 5,
                Email = "aba@gmail.com",
                Pass = "123",
                Address = "ashkelon",
                FullName = "aba kalandarov",
                Phone = "054-1222222",
            };
            LstUsers.Add(Tmp);

            for(int i = 0; i < LstUsers.Count; i++)//לולאה שעוברת על רשימת המשתמשים
            {
                //בדיקה האם האימייל או הסיסמא או השם משתמש תואמים למשתמש שנמצא ברשימה
                if (LstUsers[i].Email == TextEmail.Text && LstUsers[i].Pass == TextPass.Text)
                {
                    //ניצור משתנה מסוג שסן ונשמור בתוכו את האובייקט של המשתמש
                    //נעביר את המשתמש אל עמוד הבית
                    Session["login"] = LstUsers[i];
                    Response.Redirect("/AdminManage");
                }
            }
            LtlMsg.Text = "שם משתמש או סיסמא לא נכונים";
        }
    }
}