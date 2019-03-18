<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@ page import="org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.UserWithCount,org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
   <table style="border: 1px solid;">
   <!--get the collection from the attribute from appropriate scope (here, request) -->
   <% UserWithCount[] users = (UserWithCount[])request.getAttribute("nonFriendList"); 
   for (int i = 0; i < users.length; i++) { 
       String userName = users[i].getUserObj().getFirstName();
       int count = users[i].getCount(); %>  
       <tr>
       <td><% out.print(userName); %></td>
       <td><% out.print(count); %></td>
       </tr>
   <% } %>
   <% UserWithCount[] users1 = (UserWithCount[])request.getAttribute("FriendList"); 
   for (int i = 0; i < users1.length; i++) { 
       String userName = users1[i].getUserObj().getFirstName();
       int count = users1[i].getCount(); %>  
       <tr>
       <td><% out.print(userName); %></td>
       <td><% out.print(count); %></td>
       </tr>
   <% } %>
   </table>
</body>
</html>