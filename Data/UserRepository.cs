using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EasyXNoteDataAccessAPI.Models;
using System.Configuration;
using EasyXNoteDataAccessAPI.Data;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Data
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyAzureSqlConnection"].ConnectionString;
        }

        public object GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [EasyXNote].[User]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = (int)reader["UserID"],
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                PasswordHash = reader["PasswordHash"].ToString(),
                                PasswordSalt = reader["PasswordSalt"].ToString(),
                                CreatedDate = (DateTime)reader["CreatedDate"]
                            });
                            /* for test
                            int userId = (int)reader["UserID"];
                            string userName = reader["UserName"].ToString();
                            //string email = reader["Email"].ToString();
                            string email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null;
                            string passwordHash = reader["PasswordHash"].ToString();
                            string passwordSalt = reader["PasswordSalt"].ToString();
                            DateTime createdDate = (DateTime)reader["CreatedDate"];
                            User newUser = new User
                            {
                                UserID = userId,
                                UserName = userName,
                                Email = email,
                                PasswordHash = passwordHash,
                                PasswordSalt = passwordSalt,
                                CreatedDate = createdDate
                            };
                            users.Add(newUser);
                            */
                        }
                    }
                }

                return new { success = true, data = users };
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
    /*
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository()
        {
             connectionString = ConfigurationManager.ConnectionStrings["MyAzureSqlConnection"].ConnectionString;
        }
        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [EasyXNote].[User]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = (int)reader["UserID"],
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                PasswordHash = reader["PasswordHash"].ToString(),
                                PasswordSalt = reader["PasswordSalt"].ToString(),
                                CreatedDate = (DateTime)reader["CreatedDate"]
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // 处理数据库连接异常
                Console.WriteLine($"Database connection error: {ex.Message}");
                // 可以记录日志、发送通知等其他操作
                // throw; // 重新抛出异常，使调用者能够感知到异常
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine($"An error occurred: {ex.Message}");
                // 可以记录日志、发送通知等其他操作
                // throw; // 重新抛出异常，使调用者能够感知到异常
            }

            return users;
        }
    }
    */
}

/* for test
int userId = (int)reader["UserID"];
string userName = reader["UserName"].ToString();
//string email = reader["Email"].ToString();
string email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null;
string passwordHash = reader["PasswordHash"].ToString();
string passwordSalt = reader["PasswordSalt"].ToString();
DateTime createdDate = (DateTime)reader["CreatedDate"];
User newUser = new User
{
    UserID = userId,
    UserName = userName,
    Email = email,
    PasswordHash = passwordHash,
    PasswordSalt = passwordSalt,
    CreatedDate = createdDate
};
users.Add(newUser);
*/


