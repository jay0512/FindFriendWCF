using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = TextBox1.Text;
            String pass = TextBox2.Text;

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            int check = proxy.CheckUser(email, pass);

            if (check == 1)
            {
                Session["username"] = Request.Form["email"];
                Response.Redirect("SearchFriend.aspx");
            }
            else
            {
                /*Request["errorMessage"]= "Invalid user or password";
                RequestDispatcher rd = request.getRequestDispatcher("/login.jsp");
                rd.forward(request, response);*/
            }
        }
    }
}