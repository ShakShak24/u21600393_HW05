using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using u21600393_HW05.Models;

namespace u21600393_HW05.Models
{
    public class DataServiceClass
    {
        private String ConnectionString;
        private static DataServiceClass instance;

        public static DataServiceClass getInstance()
        {
            if (instance == null)
            {
                instance = new DataServiceClass();
            }
            return instance;
        }

        public DataServiceClass()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Books> GetBooks()
        {
            List<Books> books = new List<Books>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from Books", con))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()){
                            Books bk = new Books
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                Name = Convert.ToString(reader["name"]),
                                pageCount = Convert.ToInt32(reader["pagecount"]),
                                Point = Convert.ToInt32(reader["point"]),
                                AuthorID = Convert.ToInt32(reader["authorId"]),
                                typeID = Convert.ToInt32(reader["typeId"])
                            };
                            books.Add(bk);
                        }
                    }
                }
                con.Close();
            }
            return books;
        }

        public List<Authors> GetAuthors()
        {
            List<Authors> authors = new List<Authors>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from Authors", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Authors au = new Authors
                            {
                                authorId = Convert.ToInt32(reader["authorId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["Surname"]),
                                
                            };
                            authors.Add(au);
                        }
                    }
                }
                con.Close();
            }
            return authors;
        }

        public List<Types> GetTypes()
        {
            List<Types> Type = new List<Types>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from types", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Types ty = new Types
                            {
                                typeID = Convert.ToInt32(reader["typeId"]),
                                Name = Convert.ToString(reader["name"]),

                            };
                            Type.Add(ty);
                        }
                    }
                }
                con.Close();
            }
            return Type;
        }

        public List<Students> GetStudents()
        {
            List<Students> Student = new List<Students>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from students", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Students stu = new Students
                            {
                                StudentID = Convert.ToInt32(reader["studentId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"]),
                                Birthdate = Convert.ToDateTime(reader["birthdate"]),
                                Gender = Convert.ToString(reader["gender"]),
                                Class = Convert.ToString(reader["class"]),
                                Point = Convert.ToInt32(reader["point"])

                            };
                            Student.Add(stu);
                        }
                    }
                }
                con.Close();
            }
            return Student;
        }

        public List<Borrows> GetBorrows()
        {
            List<Borrows> Borrows = new List<Borrows>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from borrows", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Borrows bor = new Borrows
                            {
                                borrowID = Convert.ToInt32(reader["borrowId"]),
                                StudentID = Convert.ToInt32(reader["studentId"]),
                                BookID = Convert.ToInt32(reader["bookId"]),
                                takenDate = Convert.ToDateTime(reader["takenDate"]),
                                broughtDate = Convert.ToDateTime(reader["broughtDate"]),
                                

                            };
                            Borrows.Add(bor);
                        }
                    }
                }
                con.Close();
            }
            return Borrows;
        }
    }
}