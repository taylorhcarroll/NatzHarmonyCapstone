SELECT * FROM UserMentor um
LEFT JOIN [Messages] m ON m.RecipientId = um.UserId
WHERE um.UserId = '00000000-ffff-ffff-ffff-ffffffffffff'

SELECT u.FirstName, u.LastName, u.Id, um.MentorId
FROM AspNetUsers u
LEFT JOIN UserMentor um ON um.UserId = u.Id
WHERE um.UserId = '00000000-ffff-ffff-ffff-ffffffffffff'

SELECT m.MessagesId, m.SenderId, m.RecipientId, m.Content, m.[TimeStamp], m.IsRead,
u.FirstName, u.LastName
FROM [Messages] m
LEFT JOIN [AspNetUsers] u ON m.RecipientId = u.Id
LEFT JOIN [AspNetUsers] ON m.SenderId = u.Id 
WHERE m.SenderId = '00000000-ffff-ffff-ffff-ffffffffffff' or m.RecipientId = '00000000-ffff-ffff-ffff-ffffffffffff'
GROUP BY m.SenderId, m.RecipientId, m.IsRead, m.[TimeStamp], m.Content, m.MessagesId, u.FirstName, u.LastName





--get a list of users related to user
--if they have conversations include them
--conversations must have a senderId or receiverId that are the user's Id