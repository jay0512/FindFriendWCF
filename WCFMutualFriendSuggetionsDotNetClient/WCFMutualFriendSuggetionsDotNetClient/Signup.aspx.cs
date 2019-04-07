using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFMutualFriendSuggetionsDotNetClient.ServiceReference1;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = TextBox3.Text;
            String fnm = TextBox1.Text;
            String lnm = TextBox2.Text;
            String pass = TextBox4.Text;
            String status = "";
            int flag = 0;

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            User usr = proxy.getUserByEmail(email);
            if (!(usr.Email!=""))
            {
                Label1.Text="Username is taken";
                flag = 1;
                return;
            }
            if (flag == 1 && email=="" || fnm == "" || lnm == "" || pass == "")
            {
                Label1.Text = "Fill the details";
                return;
            }
            else
                status = proxy.AddUser(fnm, lnm, email, pass);


            if (status=="successfully")
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                Label1.Text = "Something went wrong";
            }
        }
    }
}