

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User;
import org.tempuri.IService1Proxy;

/**
 * Servlet implementation class Profile
 */
@WebServlet("/Profile")
public class Profile extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Profile() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		HttpSession session = request.getSession(false);

		if(session.getAttribute("username")==null)
		{
			request.setAttribute("errorMessage", "Login First");
            RequestDispatcher rd = request.getRequestDispatcher("/login.jsp");
            rd.forward(request, response);
		}

		String userEmail=session.getAttribute("username").toString();

		int FriendID = Integer.parseInt(request.getParameter("id"));
		IService1Proxy proxy =new IService1Proxy();
		User usr=proxy.getUserByEmail(userEmail);
		User friend = proxy.getUserByUserID(FriendID);
		boolean isFriend = proxy.isFriend(usr.getUserID(),FriendID);
		request.setAttribute("FriendProfile", friend);
		if(isFriend)
			request.setAttribute("isFriend", isFriend);
		else
			request.setAttribute("isFriend", null);
		RequestDispatcher rd = request.getRequestDispatcher("/profile.jsp");
        rd.forward(request, response);
		
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
