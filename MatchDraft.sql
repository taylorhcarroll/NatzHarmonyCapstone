SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
ul.LanguageId, l.[Name],
+ COUNT(CASE WHEN ul.LanguageId = 1 THEN 1 END)
+ COUNT(CASE WHEN u.CountryId = 1 THEN 1 END)  
+ COUNT(CASE WHEN u.[Availability] = 'Mornings' THEN 1 END) 
+ COUNT(CASE WHEN u.Gender = 'Female' THEN 1 END) AS CriteriaRank
FROM AspNetUsers u
LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
LEFT JOIN [Language] l ON l.LanguageId = ul.LanguageId
GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
HAVING u.Mentor = 1
ORDER BY CriteriaRank DESC, u.LastName DESC
--Language must match user
--Gender must match user
--Country must match user
--else return top 3 alphabetical order

SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability],
ul.LanguageId, l.[Name]
FROM AspNetUsers u
LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
LEFT JOIN [Language] l ON l.LanguageId = ul.LanguageId
GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name]
ORDER BY u.LastName DESC


SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
ul.LanguageId, l.[Name],
+ COUNT(CASE WHEN ul.LanguageId = 1 OR ul.LanguageId = 2 THEN 1 END)
+ COUNT(CASE WHEN u.CountryId = 1 THEN 1 END)  
+ COUNT(CASE WHEN u.[Availability] = 'Mornings' THEN 1 END) 
+ COUNT(CASE WHEN u.Gender = 'Female' THEN 1 END) AS CriteriaRank
FROM AspNetUsers u
LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
LEFT JOIN [Language] l ON l.LanguageId = ul.LanguageId
GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
HAVING u.Mentor = 1
ORDER BY CriteriaRank DESC, u.LastName DESC