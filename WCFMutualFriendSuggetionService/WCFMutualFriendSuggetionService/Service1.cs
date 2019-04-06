using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFMutualFriendSuggetionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string AddUser(string FirstName, string LastName ,string Email ,string Password)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("insert into [User](FirstName, LastName, Email, Password) values(@FirstName, @LastName, @Email, @Password)", con);
            cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
            cmd.Parameters.Add(new SqlParameter("@Email", Email));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));
            con.Open();

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "successfully";
            }
            else
            {
                Message = "unsuccessfully";
            }
            con.Close();
            return Message;
        }

        public int CheckUser(string email, string password)
        {
            int status;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("Select * from [User] where Email=@email and Password=@password", con);
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                status=1;
            }
            else
            {
                status=0;
            }
            con.Close();
            return status;
        }

        public User getUserByEmail(string email)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("Select * from [User] where Email=@Email", con);
            cmd.Parameters.Add(new SqlParameter("@Email", email));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            User usr = new User();
            while (rd.Read())
            {
                usr.UserID = rd.GetInt32(0);
                usr.FirstName = rd.GetString(1);
                usr.LastName = rd.GetString(2);
                usr.Email = rd.GetString(3);
                usr.Password = rd.GetString(4);
            }
            rd.Close();
            con.Close();
            return usr;
        }

        public User getUserByFirstName(string firstname)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("Select * from [User] where FirstName=@firstname", con);
            cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            User usr = new User();
            while (rd.Read())
            {
                usr.UserID = rd.GetInt32(0);
                usr.FirstName = rd.GetString(1);
                usr.LastName = rd.GetString(2);
                usr.Email = rd.GetString(3);
                usr.Password = rd.GetString(4);
            }
            rd.Close();
            con.Close();
            return usr;
        }

        public List<User> GetMutualFriends(int UserId,int FriendId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("SELECT P1.UserID,P1.FirstName,P1.LastName FROM Friend AS F1 JOIN [User] AS P1 ON P1.UserID = F1.FriendID WHERE F1.UserID = @UserID AND F1.FriendID IN(SELECT F2.FriendID FROM Friend AS F2 WHERE F2.UserID = @FriendID)", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserId));
            cmd.Parameters.Add(new SqlParameter("@FriendID", FriendId));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            List<User> mutualFriendList = new List<User>();
            while (rd.Read())
            {
                User usr = new User();
                usr.UserID = rd.GetInt32(0);
                usr.FirstName = rd.GetString(1);
                usr.LastName = rd.GetString(2);
                mutualFriendList.Add(usr);
            }
            rd.Close();
            con.Close();
            return mutualFriendList;
        }

        public int GetMutualFriendsCount(int UserId, int FriendId)
        {
            List<User> mutualFriendList = this.GetMutualFriends(UserId,FriendId);
            return mutualFriendList.Count;
        }
        
        public List<User> GetUsers()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("Select * from [User]", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            DataSet ds = new DataSet();
            adpt.Fill(ds, "Users");
            
            List<User> usrlist = new List<User>();
            foreach(DataTable x in ds.Tables)
            {
                foreach(DataRow y in x.Rows)
                {
                    User usr = new User();
                    usr.UserID = int.Parse(y["UserID"].ToString());
                    usr.FirstName = y["FirstName"].ToString();
                    usr.LastName = y["LastName"].ToString();
                    usrlist.Add(usr);
                }
            }
            return usrlist;
        }

        public int addFriend(int UserID,int FriendID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("insert into [Friend](UserID,FriendID) values(@UserID, @FriendID)", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            cmd.Parameters.Add(new SqlParameter("@FriendID", FriendID));
            con.Open();

            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<UserWithCount> GetNonFriendsFromQueryString(int UserID, string pattern)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE UserID NOT IN(SELECT FriendID from [Friend] where UserID=@UserID)  AND UserID != @UserID and ( FirstName Like '" + pattern+ "%' or LastName Like '"+pattern+"%')", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            //cmd.Parameters.Add(new SqlParameter("@pattern", pattern));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            List<UserWithCount> NonFriendsList = new List<UserWithCount>();
            while (rd.Read())
            {
                User usr = new User();
                int count=GetMutualFriendsCount(UserID, rd.GetInt32(0));
                usr.UserID = rd.GetInt32(0);
                usr.FirstName = rd.GetString(1);
                usr.LastName = rd.GetString(2);
                usr.Email = rd.GetString(3);
                UserWithCount usrcnt = new UserWithCount();
                usrcnt.UserObj = usr;
                usrcnt.Count = count;
                NonFriendsList.Add(usrcnt);
            }
            NonFriendsList.OrderByDescending(val1 => val1.Count);
            rd.Close();
            con.Close();
            return NonFriendsList;
        }

        public List<UserWithCount> GetFriendsFromQueryString(int UserID, string pattern)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("SELECT P1.UserID,P1.FirstName,P1.LastName,P1.Email FROM Friend AS F1 JOIN[User] AS P1 ON P1.UserID = F1.FriendID WHERE F1.UserID = @UserID AND ( P1.FirstName Like '" + pattern + "%' or P1.LastName Like '" + pattern + "%')", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            //cmd.Parameters.Add(new SqlParameter("@pattern", pattern));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            List<UserWithCount> FriendList = new List<UserWithCount>();
            while (rd.Read())
            {
                User usr = new User();
                int count = GetMutualFriendsCount(UserID, rd.GetInt32(0));
                usr.UserID = rd.GetInt32(0);
                usr.FirstName = rd.GetString(1);
                usr.LastName = rd.GetString(2);
                usr.Email = rd.GetString(3);
                UserWithCount usrcnt = new UserWithCount();
                usrcnt.UserObj = usr;
                usrcnt.Count = count;
                FriendList.Add(usrcnt);
            }
            FriendList.OrderByDescending(val1 => val1.Count);
            rd.Close();
            con.Close();
            return FriendList;
        }

        public int removeFriend(int UserID, int FriendID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("delete from [Friend] where UserID=@UserID and FriendID=@FriendID", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            cmd.Parameters.Add(new SqlParameter("@FriendID", FriendID));
            con.Open();

            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public string removeUser(int UserID)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("delete from [User] where UserID=@UserID ", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            con.Open();

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "successfully";
            }
            else
            {
                Message = "unsuccessfully";
            }
            con.Close();
            return Message;
        }

        public User getUserByUserID(int UserID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hinka\Documents\UserDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("Select * from [User] where UserID=@UserID", con);
            cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            User usr = new User();
            while (rd.Read())
            {
                usr.UserID = rd.GetInt32(0);
                usr.FirstName = rd.GetString(1);
                usr.LastName = rd.GetString(2);
                usr.Email = rd.GetString(3);
                usr.Password = rd.GetString(4);
            }
            rd.Close();
            con.Close();
            return usr;
        }
    }
}
