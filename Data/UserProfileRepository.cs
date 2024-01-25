using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EasyXNoteDataAccessAPI.Models;
using System.Configuration;
using EasyXNoteDataAccessAPI.Data;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Data
{
    public class UserProfileRepository
    {
        private readonly string connectionString;

        public UserProfileRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyAzureSqlConnection"].ConnectionString;
        }

        public object GetAllUserProfiles()
        {
            try
            {
                List<UserProfile> userProfiles = new List<UserProfile>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [EasyXNote].[User]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userProfiles.Add(new UserProfile
                            {
                                UserID = (int)reader["UserID"],
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                CreatedDate = (DateTime)reader["CreatedDate"]
                            });
                        }
                    }
                }

                return new { success = true, data = userProfiles };
            }
            catch (SqlException ex)
            {
                // 处理数据库连接异常
                Console.WriteLine($"Database connection error: {ex.Message}");
                // 可以记录日志、发送通知等其他操作
                return new { success = false, error = new { code = 500, message = "Internal Server Error" } };
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine($"An error occurred: {ex.Message}");
                // 可以记录日志、发送通知等其他操作
                return new { success = false, error = new { code = 500, message = "Internal Server Error" } };
            }
        }
    }
}