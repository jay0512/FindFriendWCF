using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFMutualFriendSuggetionService
{
    [DataContract]
    public class User
    {
        private int userId;
        private string userFname;
        private string userLname;
        private string email;
        private string password;
      [DataMember]
        public int UserID
        {
            get { return userId; }
            set { userId = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return userFname; }
            set { userFname = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return userLname; }
            set { userLname = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
    [DataContract]
    public class UserWithCount
    {
        private int count;
        private User usr;
        [DataMember]
        public User UserObj
        {
            get { return usr; }
            set { usr = value; }
        }
        [DataMember]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}