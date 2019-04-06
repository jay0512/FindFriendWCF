/**
 * IService1.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package org.tempuri;

public interface IService1 extends java.rmi.Remote {
    public java.lang.Integer checkUser(java.lang.String email, java.lang.String passsword) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User getUserByEmail(java.lang.String email) throws java.rmi.RemoteException;
    public java.lang.Integer addFriend(java.lang.Integer userID, java.lang.Integer friendID) throws java.rmi.RemoteException;
    public java.lang.Integer removeFriend(java.lang.Integer userID, java.lang.Integer friendID) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User getUserByFirstName(java.lang.String firstname) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User getUserByUserID(java.lang.Integer userID) throws java.rmi.RemoteException;
    public java.lang.String addUser(java.lang.String firstName, java.lang.String lastName, java.lang.String email, java.lang.String password) throws java.rmi.RemoteException;
    public java.lang.String removeUser(java.lang.Integer userID) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User[] getUsers() throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.UserWithCount[] getNonFriendsFromQueryString(java.lang.Integer userID, java.lang.String pattern) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.UserWithCount[] getFriendsFromQueryString(java.lang.Integer userID, java.lang.String pattern) throws java.rmi.RemoteException;
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User[] getMutualFriends(java.lang.Integer userId, java.lang.Integer friendId) throws java.rmi.RemoteException;
    public java.lang.Integer getMutualFriendsCount(java.lang.Integer userId, java.lang.Integer friendId) throws java.rmi.RemoteException;
}
