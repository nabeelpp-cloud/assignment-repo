using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoDotNet
{
    public class Class1
    {

        private readonly string _connectionString = "Data Source=localhost,1433;Initial Catalog=adoTesting;User ID=sa;Password=123456789aA;Trust Server Certificate=True";

        public void CreateTableEmployee()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string createCommand = "CREATE TABLE Employeee (Id INT IDENTITY(1,1),Name VARCHAR(25), Salary DECIMAL(7,2))";
                SqlCommand command = new SqlCommand(createCommand, connection);
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table Created Successfully\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void InsertToEmployee()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string insertCommand = "INSERT INTO Employeee (Name,Salary) VALUES('NABEEL',10000)";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                int resp = command.ExecuteNonQuery();
                if (resp > 0)
                {
                    Console.WriteLine("Data inserted Successfully");
                    Console.WriteLine($"{resp} rows inserted");

                }

            }
        }
        public void UpdateEmployee()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string updateCommad = "UPDATE Employeee SET Salary=20000 WHERE Id=1";
                SqlCommand command = new SqlCommand(updateCommad, connection);
                int resp = command.ExecuteNonQuery();
                if (resp > 0)
                {
                    Console.WriteLine("Data updated Successfully");
                    Console.WriteLine($"{resp} rows updated");
                }
                else
                {
                    Console.WriteLine("Error Inserting Data");
                }
            }
        }
        public void DeleteEmployee()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Employeee WHERE Id=2";
                SqlCommand command = new SqlCommand(deleteCommand, connection);
                int resp = command.ExecuteNonQuery();
                if (resp > 0)
                {
                    Console.WriteLine("Data deleted Successfully");
                    Console.WriteLine($"{resp} rows deleted");
                }
                else
                {
                    Console.WriteLine("Error Deleting Data");
                }
            }
        }
        public void DisplayAllEmployee()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectCommand = "SELECT * FROM Employeee";
                SqlCommand command = new SqlCommand(selectCommand, conn);
                SqlDataReader resp = command.ExecuteReader();
                while (resp.Read())
                {
                    Console.WriteLine($"Name : {resp["Name"]} \nSalary : {resp["Salary"]}\n");
                }
            }
        }
        public void TotalEmployee()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string totalEmployeeCommand = "SELECT COUNT(*) FROM Employeee";
                SqlCommand command = new SqlCommand(totalEmployeeCommand, conn);
                var resp = command.ExecuteScalar();
                Console.WriteLine($"Total no of Employee = {resp}");
            }
        }

        public void SelectAllEmployeeDisconnected()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string selectionQuery = "SELECT * FROM Employeee";
                SqlDataAdapter adapter = new SqlDataAdapter(selectionQuery, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var row = dataSet.Tables[0].Rows[i];
                    Console.WriteLine($"Id : {row["Id"]} \nName : {row["Name"]}  \nSalary : {row["Salary"]}\n");
                }
            }
        }
    }
}
