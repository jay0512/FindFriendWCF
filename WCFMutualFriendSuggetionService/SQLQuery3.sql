SELECT P1.FirstName
FROM Friend AS F1
JOIN [User] AS P1 ON P1.UserID = F1.FriendID
WHERE F1.UserID = 1 AND
      F1.FriendID IN (SELECT F2.FriendID
                      FROM Friend AS F2
                      WHERE F2.UserID = 2)