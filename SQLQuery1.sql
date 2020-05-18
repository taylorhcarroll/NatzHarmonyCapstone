SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
ul.LanguageId, l.[Name],
+ COUNT(CASE WHEN u.[Availability] = 'Midday' THEN 1 END)
+ COUNT(CASE WHEN u.Gender = 'Male' THEN 1 END)
+ COUNT(CASE WHEN u.CountryId = 2 THEN 1 END)
+ COUNT(CASE WHEN ul.LanguageId = 4 THEN 1 END)  
AS CriteriaRank
FROM AspNetUsers u
LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
LEFT JOIN[Language] l ON l.LanguageId = ul.LanguageId
GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
HAVING u.Mentor = 1
ORDER BY CriteriaRank DESC, u.LastName DESC 