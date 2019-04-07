using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.StatusCode == 401)
                Label1.Text = "Login First";
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = TextBox1.Text;
            String pass = TextBox2.Text;

            ServiceReference1.IService1 proxy = new ServiceReference1.Service1Client();
            int check = proxy.CheckUser(email, pass);

            if (check == 1)
            {
                Session["username"] = TextBox1.Text;
                Response.Redirect("SearchFriend.aspx");
            }
            else
            {
                Label1.Text = "Invalid Credential";
            }
        }
    }
}