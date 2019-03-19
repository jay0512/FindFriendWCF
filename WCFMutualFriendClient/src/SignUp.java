

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User;
import org.tempuri.IService1Proxy;

/**
 * Servlet implementation class SignUp
 */
@WebServlet("/SignUp")
public class SignUp extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public SignUp() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub		
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		String email=request.getParameter("email");
		String fnm=request.getParameter("firstName");
		String lnm=request.getParameter("LastName");
		String pass=request.getParameter("password");
		String status="";
		int flag=0;
		
		IService1Proxy proxy =new IService1Proxy();
		User usr= proxy.getUserByEmail(email);
		if(!(usr.getEmail().equals("")))
		{
			request.setAttribute("errorMessage", "Username is taken");
			flag=1;
            RequestDispatcher rd = request.getRequestDispatcher("/signup.jsp");
            rd.forward(request, response);
            return;
		}
		if(flag==1 && email.equals("") || fnm.equals("") || lnm.equals("") || pass.equals(""))
		{
			request.setAttribute("errorMessage", "Fill the details");
            RequestDispatcher rd = request.getRequestDispatcher("/signup.jsp");
            rd.forward(request, response);
		}
		else
			status =proxy.addUser(fnm, lnm, email, pass);
		
		
		if(status.equals("successfully"))
		{
			response.sendRedirect("/login.jsp");
		}
		else
		{
			request.setAttribute("errorMessage", "Something went wrong");
            RequestDispatcher rd = request.getRequestDispatcher("/signup.jsp");
            rd.forward(request, response);
		}
		
	}

}
