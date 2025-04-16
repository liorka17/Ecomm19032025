using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Ecomm19032025.AdminManage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] == null)//במידה ואין משתמש מחובר נעביר אותו לעמוד ההתחברות
            {
                Response.Redirect("~/login.aspx");//העברת המשתמש לעמוד ההתחברות

                Users us = (Users)Session["login"];//המרת המשתמש מסוג אובייקט למשתנה מסוג משתמש
                LtMsg.Text = "שלום " + us.FullName;//הצגת הודעה למשתמש
            }
        }
    }
}