using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatzHarmonyCapstone.Controllers
{
    public class Class
    {
//         using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    if (user.GenderPref == false && user.CountryPref == false && user.LanguagePref == false)
//                    {
//                        cmd.CommandText = @"SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
//                                            ul.LanguageId, l.[Name]
//                                            FROM AspNetUsers u
//                                            LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
//                                            LEFT JOIN [Language] l ON l.LanguageId = ul.LanguageId
//                                            GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
//                                            HAVING u.Mentor = 1
//                                            ORDER BY u.LastName DESC";
                        
//                        var reader = cmd.ExecuteReader();
//    var matches = new List<ApplicationUser>();

//                        while (reader.Read())
//                        {
//                            var match = new ApplicationUser()
//                            {
//                                Id = reader.GetString(reader.GetOrdinal("Id")),
//                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                                //AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl")),
//                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
//                                Availability = reader.GetString(reader.GetOrdinal("Availability")),
//                                CountryId = reader.GetInt32(reader.GetOrdinal("CountryId"))

//                            };
//                            //checks against db to return nullable AvatarUrl 
//                            if (!reader.IsDBNull(reader.GetOrdinal("AvatarUrl")))
//                            {
//                                match.AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl"));
//                            }

//matches.Add(match);
//                        }
//                        reader.Close();
//                        return matches;
//                    }
//                    else if (user.LanguagePref == true)
//                    {
                        
//                    }
//                    else
//                    {

//                    }
//                    //else if (user.LanguagePref == true)
//                    //{
                       
//                    //    {
//                    //        foreach (UserLanguage lang in user.Languages)
//                    //        {
//                    //            cmd.CommandText = @"SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
//                    //                    ul.LanguageId, l.[Name],
//                    //                    + COUNT(CASE WHEN u.[Availability] = '@Availability' THEN 1 END) ";

//                    //            cmd.Parameters.Add(new SqlParameter("@Availability", user.Availability));

//                    //            if (user.GenderPref == true)
//                    //            {
//                    //                cmd.CommandText += " + COUNT(CASE WHEN u.Gender = '@Gender' THEN 1 END) ";
//                    //                cmd.Parameters.Add(new SqlParameter("@Gender", user.Gender));
//                    //            }

//                    //            if (user.CountryPref == true)
//                    //            {
//                    //                cmd.CommandText += "  + COUNT(CASE WHEN u.CountryId = @Country THEN 1 END) ";
//                    //                cmd.Parameters.Add(new SqlParameter("@Country", user.CountryId));
//                    //            }


//                    //            cmd.CommandText += " + COUNT(CASE WHEN ul.LanguageId = @Lang THEN 1 END)  ";
//                    //            cmd.Parameters.Add(new SqlParameter("@Lang", lang.Language.LanguageId));


//                    //            cmd.CommandText += @" AS CriteriaRank
//                    //                        FROM AspNetUsers u
//                    //                        LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
//                    //                        LEFT JOIN[Language] l ON l.LanguageId = ul.LanguageId
//                    //                        GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
//                    //                        HAVING u.Mentor = 1
//                    //                        ORDER BY CriteriaRank DESC, u.LastName DESC ";

//                    //        }
//                    //        var reader = cmd.ExecuteReader();
//                    //        var matches = new List<ApplicationUser>();

//                    //        while (reader.Read())
//                    //        {
//                    //            var match = new ApplicationUser()
//                    //            {
//                    //                Id = reader.GetString(reader.GetOrdinal("Id")),
//                    //                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                    //                LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                    //                //AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl")),
//                    //                Gender = reader.GetString(reader.GetOrdinal("Gender")),
//                    //                Availability = reader.GetString(reader.GetOrdinal("Availability")),
//                    //                CountryId = reader.GetInt32(reader.GetOrdinal("CountryId"))

//                    //            };
//                    //            //checks against db to return nullable AvatarUrl 
//                    //            if (!reader.IsDBNull(reader.GetOrdinal("AvatarUrl")))
//                    //            {
//                    //                match.AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl"));
//                    //            }

//                    //            matches.Add(match);
//                    //        }
//                    //    }
//                    //}
//                    else
//                    {
//                            cmd.CommandText = @"SELECT TOP 3 u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], u.AvatarUrl,
//                                        ul.LanguageId, l.[Name],
//                                        + COUNT(CASE WHEN u.[Availability] = '@Availability' THEN 1 END) ";

//                            cmd.Parameters.Add(new SqlParameter("@Availability", user.Availability));

//                            if (user.GenderPref == true)
//                            {
//                                cmd.CommandText += " + COUNT(CASE WHEN u.Gender = '@Gender' THEN 1 END) ";
//                                cmd.Parameters.Add(new SqlParameter("@Gender", user.Gender));
//                            }

//                            if (user.CountryPref == true)
//                            {
//                                cmd.CommandText += "  + COUNT(CASE WHEN u.CountryId = @Country THEN 1 END) ";
//                                cmd.Parameters.Add(new SqlParameter("@Country", user.CountryId));
//                            }

//                            cmd.CommandText += @" AS CriteriaRank
//                                            FROM AspNetUsers u
//                                            LEFT JOIN UserLanguage ul ON ul.UserId = u.Id
//                                            LEFT JOIN[Language] l ON l.LanguageId = ul.LanguageId
//                                            GROUP BY u.Id, u.FirstName, u.LastName, u.Mentor, u.Gender, u.CountryId, u.[Availability], ul.LanguageId, l.[Name], u.AvatarUrl
//                                            HAVING u.Mentor = 1
//                                            ORDER BY CriteriaRank DESC, u.LastName DESC ";

//                        }
//                        var reader = cmd.ExecuteReader();
//var matches = new List<ApplicationUser>();

//                        while (reader.Read())
//                        {
//                            var match = new ApplicationUser()
//                            {
//                                Id = reader.GetString(reader.GetOrdinal("Id")),
//                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                                //AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl")),
//                                Gender = reader.GetString(reader.GetOrdinal("Gender")),
//                                Availability = reader.GetString(reader.GetOrdinal("Availability")),
//                                CountryId = reader.GetInt32(reader.GetOrdinal("CountryId"))

//                            };
//                            //checks against db to return nullable AvatarUrl 
//                            if (!reader.IsDBNull(reader.GetOrdinal("AvatarUrl")))
//                            {
//                                match.AvatarUrl = reader.GetString(reader.GetOrdinal("AvatarUrl"));
//                            }

//                            matches.Add(match);
//                        }
//                        reader.Close();
//                        return matches;
//                    }
//                    }   
//                }
//            }
    }
}
