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


       public List<Borrowed> GetBorroweds(int bookId)
        {
            List<Borrowed> Borrowed = new List<Borrowed>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select borrowiD, takenDate, broughtDate, students.name + ' ' + students.surname AS 'Borrowed By', books.name From BORROWS INNER JOIN STUDENTS ON BORROWS.STUDENTID = STUDENTS.STUDENTID INNER JOIN books on borrows.bookId = books.bookId WHERE BORROWS.BOOKID = " + bookId, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Borrowed brd = new Borrowed
                            {
                                borrowId = Convert.ToInt32(reader["borrowId"]),
                                borrowedBy = Convert.ToString(reader["Borrowed By"]),
                                takenDate = Convert.ToDateTime(reader["takenDate"]),
                                broughtDate = Convert.ToDateTime(reader["broughtDate"]),
                                Name = Convert.ToString(reader["NAME"])

                            };
                            Borrowed.Add(brd);
                        }
                    }
                }
                con.Close();
            }
            return Borrowed;
        }

        //public List<Borrowed> getCount(int ID)
        //{

        //}

        //public Books searchbook(int bookId)
        //{
        //    List<Books> name = new List<Books>();
        //    return name.Where(x => x.BookID = bookId).FirsthOrDefault();

        //}

        //public List<Books> SearchByName(string name)
        //{
        //    List<Books> SBooks = new List<Books>();
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("Select * from books where name like '%" + name + "%", con))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Books sb = new Books
        //                    {
        //                        BookID = Convert.ToInt32(reader["bookId"]),
        //                        Name = Convert.ToString(reader["name"]),
        //                        pageCount = Convert.ToInt32(reader["pagecount"]),
        //                        Point = Convert.ToInt32(reader["point"]),
        //                        AuthorID = Convert.ToInt32(reader["authorId"]),
        //                        typeID = Convert.ToInt32(reader["typeId"])

        //                    };
        //                    SBooks.Add(sb);
        //                }
        //            }
        //        }
        //        con.Close();
        //    }
        //    return SBooks;
        //}

        //public List<Books> searchBooks(string bookName)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        List<Books> books = new List<Books>();
        //        try
        //        {
        //            con.Open();
        //            SqlCommand command = new SqlCommand("select " + "books.bookId, " + "books.name, " + "authors.surname, " + "types.name AS typename, " + "books.pagecount, " +
        //            "books.point " + "from books " + "Join authors " + "on books.authorId = authors.authorId " + "join types " + "on books.typeId = types.typeId where books.name like '"
        //            + bookName + "%';", con);
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Books libraryBooks = new Books();

        //                libraryBooks.BookID = (int)reader["bookId"];
        //                libraryBooks.Name = (string)reader["name"];
        //                libraryBooks.AuthorID = (int)reader["authorId"];
        //                libraryBooks.typeID = (int)reader["typename"];
        //                libraryBooks.pageCount = (int)reader["pagecount"];
        //                libraryBooks.Point = (int)reader["point"];

        //                books.Add(libraryBooks);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //        return books;


        //    }
        
        
    }
}