using System;
using Microsoft.Data.SqlClient;

namespace AdoDotNet
{
    class Demo
    {

        private static void ReadData(string connectionString)
        {
            const string querystring = @"SELECT * FROM Customer Where CustomerID > @greater";


            const int parameter = 5;

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(querystring, connection);
                command.Parameters.AddWithValue("@greater", parameter);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"CustomerID: {reader[0]}\nCustomer Name: {reader[1]}\nEmail: {reader[2]}\nContact No: {reader[3]}\nPost Code: {reader[4]}\n");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        private static void InsertData(string connectionString,Customer[] customers)
        {
            const string insertquery = @"Insert INTO Customer(CustomerID,Name,Email,ContactNO,PostCode) Values (@CustomerID,@Name,@Email,@ContactNO,@PostCode)";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new(insertquery, connection);

                foreach(var customer in customers)
                {
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@ContactNo", customer.ContactNo);
                    command.Parameters.AddWithValue("@PostCode", customer.PostCode);
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Rocord Inserted Successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inserting {customer.Name}: {ex.Message}");
                    }
                    command.Parameters.Clear();
                }
                connection.Close();
            
            }
        }

        private static void DeleteData(string connectionstring)
        {
            const string Updatequery = @"Update Customer SET PostCode = @postcode Where CustomerID > @id";
            using (SqlConnection connection = new(connectionstring))
            {
                connection.Open();

                SqlCommand command = new(Updatequery, connection);
                command.Parameters.AddWithValue("@postcode", 32300);
                command.Parameters.AddWithValue("@id", 10);
                int row = command.ExecuteNonQuery();
                if (row>0)
                {
                    Console.WriteLine("Update Successfullly!");
                }
                connection.Close();

            }
        }

        private static void UpdateData(string connectionstring)
        {
            const string Updatequery = @"Delete Customer Where CustomerID = @id";
            using (SqlConnection connection = new(connectionstring))
            {
                connection.Open();

                SqlCommand command = new(Updatequery, connection);
                command.Parameters.AddWithValue("@id", 5);
                int row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("Record Delete Successfullly!\n\n");
                }
                connection.Close();

            }
        }

        static void Main(string[] args)
        {
            Customer[] customers = new Customer[]
            {
                new Customer { CustomerID = 16, Name = "Jessica Davis", Email = "jessica@gmail.com", ContactNo = "032000327", PostCode = 32203 },
                new Customer { CustomerID = 17, Name = "John Doe", Email = "john@gmail.com", ContactNo = "032000328", PostCode = 32204 },
                new Customer { CustomerID = 18, Name = "Emily Johnson", Email = "emily@gmail.com", ContactNo = "032000329", PostCode = 32205 },
                new Customer { CustomerID = 19, Name = "Michael Brown", Email = "michael@gmail.com", ContactNo = "032000330", PostCode = 32206 }
            }; 
            
            const string ConnectionString = @"Data Source=DESKTOP-Q6T8H7G;Initial Catalog=TestDB;Integrated Security=true;TrustServerCertificate=true";
 
            try
            {
                InsertData(ConnectionString,customers);
                //UpdateData(ConnectionString);
                //DeleteData(ConnectionString);
                ReadData(ConnectionString);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            
        }

    }
}
