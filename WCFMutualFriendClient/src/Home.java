

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User;
import org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.UserWithCount;
import org.tempuri.IService1Proxy;

import com.microsoft.schemas._2003._10.Serialization.Arrays.ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T;

/**
 * Servlet implementation class Home
 */
@WebServlet("/Home")
public class Home extends HttpServlet {
	private static final long serialVersionUID = 1L;

    /**
     * Default constructor. 
     */
    public Home() {
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		HttpSession session = request.getSession(false);

		String userEmail=session.getAttribute("username").toString();
		
		IService1Proxy proxy =new IService1Proxy();
		User usr=proxy.getUserByEmail(userEmail);
		UserWithCount[] usrcnt = proxy.getNonFriendsFromQueryString(usr.getUserID(), "r");
		UserWithCount[] frndcnt = proxy.getFriendsFromQueryString(usr.getUserID(), "r");
		
		request.setAttribute("nonFriendList", usrcnt);
		request.setAttribute("FriendList", frndcnt);
		
		RequestDispatcher rd = request.getRequestDispatcher("/findFriend.jsp");
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
