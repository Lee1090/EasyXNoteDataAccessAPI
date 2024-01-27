using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EasyXNoteDataAccessAPI.Models;
using System.Configuration;
using EasyXNoteDataAccessAPI.Data;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Data
{
    public class NoteBookRepository
    {
        private readonly string connectionString;

        public NoteBookRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyAzureSqlConnection"].ConnectionString;
        }

        public object GetAllNoteBooks()
        {
            try
            {
                List<NoteBook> noteBooks = new List<NoteBook>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [EasyXNote].[NoteBook]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            noteBooks.Add(new NoteBook
                            {
                                NoteBookID = (int)reader["NoteBookID"],
                                UserID = (int)reader["UserID"],
                                NoteBookName = reader["NoteBookName"].ToString(),
                                IsDefault = (bool)reader["IsDefault"],
                                SortOrder = reader["SortOrder"] != DBNull.Value ? (int)reader["SortOrder"] : 0
                            });
                        }
                    }
                }

                return new { success = true, data = noteBooks };
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