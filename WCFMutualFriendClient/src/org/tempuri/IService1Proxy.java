package org.tempuri;

public class IService1Proxy implements org.tempuri.IService1 {
  private String _endpoint = null;
  private org.tempuri.IService1 iService1 = null;
  
  public IService1Proxy() {
    _initIService1Proxy();
  }
  
  public IService1Proxy(String endpoint) {
    _endpoint = endpoint;
    _initIService1Proxy();
  }
  
  private void _initIService1Proxy() {
    try {
      iService1 = (new org.tempuri.Service1Locator()).getBasicHttpBinding_IService1();
      if (iService1 != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)iService1)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)iService1)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (iService1 != null)
      ((javax.xml.rpc.Stub)iService1)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public org.tempuri.IService1 getIService1() {
    if (iService1 == null)
      _initIService1Proxy();
    return iService1;
  }
  
  public java.lang.Integer checkUser(java.lang.String email, java.lang.String passsword) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.checkUser(email, passsword);
  }
  
  public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User getUserByEmail(java.lang.String email) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getUserByEmail(email);
  }
  
  public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User getUserByFirstName(java.lang.String firstname) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getUserByFirstName(firstname);
  }
  
  public java.lang.String addUser(java.lang.String firstName, java.lang.String lastName, java.lang.String email, java.lang.String password) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.addUser(firstName, lastName, email, password);
  }
  
  public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User[] getUsers() throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getUsers();
  }
  
  public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User[] getMutualFriends(java.lang.Integer userId, java.lang.Integer friendId) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getMutualFriends(userId, friendId);
  }
  
  public java.lang.Integer getMutualFriendsCount(java.lang.Integer userId, java.lang.Integer friendId) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getMutualFriendsCount(userId, friendId);
  }
  
  public java.lang.Integer addFriend(java.lang.Integer userID, java.lang.Integer friendID) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.addFriend(userID, friendID);
  }
  
  public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.UserWithCount[] getNonFriendsFromQueryString(java.lang.Integer userID, java.lang.String pattern) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getNonFriendsFromQueryString(userID, pattern);
  }
  
  public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.UserWithCount[] getFriendsFromQueryString(java.lang.Integer userID, java.lang.String pattern) throws java.rmi.RemoteException{
    if (iService1 == null)
      _initIService1Proxy();
    return iService1.getFriendsFromQueryString(userID, pattern);
  }
  
  
}