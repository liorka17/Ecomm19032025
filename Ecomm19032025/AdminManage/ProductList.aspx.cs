using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace Ecomm19032025.AdminManage
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Product> lst = Product.GetAll();
                RptProds.DataSource = lst;//מקשרת את רשימת המוצרים לריפיטר
                RptProds.DataBind();//ממלאת את הריפיטר

            }
        }
    }
}