using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EasyXNoteDataAccessAPI.Models;
using System.Configuration;
using EasyXNoteDataAccessAPI.Data;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Data
{
    public class NoteRepository
    {
        private readonly string connectionString;

        public NoteRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyAzureSqlConnection"].ConnectionString;
        }

        public object GetAllNotes()
        {
            try
            {
                List<Note> notes = new List<Note>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM [EasyXNote].[Note]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notes.Add(new Note
                            {
                                NoteID = (int)reader["NoteID"],
                                UserID = (int)reader["UserID"],
                                NoteBookID = (int)reader["NoteBookID"],
                                Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : null,
                                Content = reader["Content"] != DBNull.Value ? reader["Content"].ToString() : null,
                                CreatedDate = (DateTime)reader["CreatedDate"],
                                UpdatedDate = (DateTime)reader["UpdatedDate"]
                            });

                        }
                    }
                }

                return new { success = true, data = notes };
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