using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdoDotNet
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
    }
    class LibrarySystemwithAdoDotNet
    {
        private static int RecordCheck(string connectionstring)
        {
            const string recordcheckquery = @"Select Count(*) From Book";
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(recordcheckquery, connection);
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }
        private static void InsertData(string connectionString, List<Book> Books)
        {
            const string insertquery = @"Insert INTO Book(Title,Author,Genre,PublishedYear) Values (@Title,@Author,@Genre,@PublishedYear)";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new(insertquery, connection);

                foreach (var book in Books)
                {
                    command.Parameters.AddWithValue("@Title",book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author );
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear );
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Rocord Inserted Successfully!!!\n\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inserting {book.Title}: {ex.Message}");
                    }
                    command.Parameters.Clear();
                }
                connection.Close();

            }
        }

        private static void ReadData(string connectionstring)
        {
            // Read Query
            const string readquery = @"Select * From Book";
            // Creating SQL Connection using |ConnectionString|
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                // 
                SqlCommand cmd = new SqlCommand(readquery, connection);

                try
                {
                    // Open Connection
                    connection.Open();
                    // Executing query 
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Book ID: " + reader[0] + " Title: " + reader[1] + " Author: " + reader[2] + " Genre: " + reader[3] + " PublishedYear: " + reader[4]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }

        private static void UpdateData(string connectionstring, int bookid)
        {
            const string updatequery = @"Update Book Set Title = @Title,Author = @Author,Genre = @Genre,PublishedYear = @PublishedYear";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(updatequery, connection);
                    Console.Write("Enter Book Title: ");
                    command.Parameters.AddWithValue(@"Title", Console.ReadLine());
                    Console.Write("Enter Author: ");
                    command.Parameters.AddWithValue(@"Author", Console.ReadLine());
                    Console.Write("Enter Genre: ");
                    command.Parameters.AddWithValue(@"Genre", Console.ReadLine());
                    Console.Write("Enter Published Year: ");
                    command.Parameters.AddWithValue(@"PublishedYear", Console.ReadLine());
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                        Console.WriteLine("Record is Updated Successfully!!!\n\n");
                    connection.Close();
                    ReadData(connectionstring);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void DeleteData(string connectionstring,int record)
        {
            const string deletequery = @"Delete From Book Where BookID = @BookID";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(deletequery, connection);
                    command.Parameters.AddWithValue(@"BookID", record);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                        Console.WriteLine("Record is deleted successfully!!!\n\n");
                    connection.Close();
                    ReadData(connectionstring);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static void Main(string[] args)
        {
            const string ConnectionString = @"Data Source = DESKTOP-Q6T8H7G;Initial Catalog=LibraryDB;Integrated Security=true;TrustServerCertificate=true";

            List<Book> Books = new List<Book>();
            Book books = new Book();
            Console.Write( "Library Management System\n\n\nSelect one option at a time\n\n1.Insert Data into Table\n2.Read Data from Table\n3.Update Record\n4.Delete Record\n\n");
            int action = int.Parse(Console.ReadLine());
            int bookid = 0;
            switch(action)
            {

                case 1:
                    Console.WriteLine("How many Books you want to insert? ");
                    int records = int.Parse(Console.ReadLine());
                    int i = 1;
                    while (i <= records)
                    {
                        Console.Write("Title: ");
                        books.Title = Console.ReadLine();
                        Console.Write("Author: ");
                        books.Author = Console.ReadLine();
                        Console.WriteLine("Genre: ");
                        books.Genre = Console.ReadLine();
                        Console.WriteLine("Publish Year: ");
                        books.PublishedYear = int.Parse(Console.ReadLine());
                        Books.Add(books);
                        i++;
                    }
                    InsertData(ConnectionString, Books);
                    Console.WriteLine();
                    break;

                case 2:
                    ReadData(ConnectionString);
                    break;

                case 3:
                    if (RecordCheck(ConnectionString) > 0)
                    {
                        Console.Write("Enter BookID to update its record: ");
                        bookid = int.Parse(Console.ReadLine());
                        UpdateData(ConnectionString, bookid);
                        break;
                    }
                    else
                        Console.WriteLine("There is no record to update!!!\n\n");
                    break;

                case 4:
                    if (RecordCheck(ConnectionString) > 0)
                    {
                        Console.Write("Enter BookId to delete its record: ");
                        bookid = int.Parse(Console.ReadLine());
                        DeleteData(ConnectionString, bookid);
                        break;
                    }
                    else
                        Console.WriteLine("There is no record to delete!!!\n\n");
                    break;


                default:
                    Console.WriteLine("Please Enter Valid Number!!");
                    break;
            }



        }

    }



}
