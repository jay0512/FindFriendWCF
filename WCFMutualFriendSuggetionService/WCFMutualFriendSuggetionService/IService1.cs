using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFMutualFriendSuggetionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int CheckUser(string email, string passsword);

        [OperationContract]
        User getUserByEmail(string email);

        [OperationContract]
        int addFriend(int UserID, int FriendID);

        [OperationContract]
        int removeFriend(int UserID, int FriendID);

        [OperationContract]
        User getUserByFirstName(string firstname);

        [OperationContract]
        User getUserByUserID(int UserID);

        [OperationContract]
        string AddUser(string FirstName, string LastName, string Email, string Password);

        [OperationContract]
        string removeUser(int UserID);

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        List<UserWithCount> GetNonFriendsFromQueryString(int UserID,string pattern);

        [OperationContract]
        List<UserWithCount> GetFriendsFromQueryString(int UserID, string pattern);

        [OperationContract]
        List<User> GetMutualFriends(int UserId, int FriendId);

        [OperationContract]
        int GetMutualFriendsCount(int UserId, int FriendId);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFMutualFriendSuggetionService.ContractType".
    
}
