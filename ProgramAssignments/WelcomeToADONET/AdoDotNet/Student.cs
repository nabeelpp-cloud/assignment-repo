using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    public class Student
    {
        private readonly string _connectionString = "Data Source=localhost,1433;Initial Catalog=adoTesting;User ID=sa;Password=123456789aA;Trust Server Certificate=True";

        public void CreateTableStudent()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string createCommand = "CREATE TABLE Student (Id INT IDENTITY(1,1),Name VARCHAR(25), Class VARCHAR(25))";
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
        public void InsertNewStudnet()
        {
            using (SqlConnection conn  =new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Student",conn);
                DataSet ds =new DataSet();
                da.Fill(ds, "Student");
                DataTable dt = ds.Tables["Student"];
                DataRow dr = dt.NewRow();
                dr["Name"] = "Nabeel";
                dr["Class"] = "Information Technology";
                dt.Rows.Add(dr);

                da.InsertCommand = new SqlCommand("InsertStudent", conn);
                da.InsertCommand.CommandType = CommandType.StoredProcedure;

                da.InsertCommand.Parameters.Add("@Name",SqlDbType.VarChar,25,"Name");
                da.InsertCommand.Parameters.Add("@Class", SqlDbType.VarChar,25, "Class");

                int resp = da.Update(ds,"Student");
                if(resp > 0)
                {
                    Console.WriteLine($"Data Inserted \n{resp} rows effected");
                }
                
            }
        }
        public void GetStudentById()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From student",conn);
                DataSet ds =new DataSet();
                da.SelectCommand = new SqlCommand("GetStudentById", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id", 3);
                da.Fill(ds,"Student");

                DataTable dt = ds.Tables["Student"];
                if (dt.Rows.Count > 0) 
                {
                    foreach (DataRow dr in dt.Rows) 
                    {
                        Console.WriteLine($"Id : {dr["Id"]}\nName : {dr["Name"]} \nClass : {dr["Class"]}\n");
                    }
                }

                else
                {
                    Console.WriteLine("There is no student in that Id");
                }
            }
        }
        public void InsertStudent()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Student", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student");
                DataTable dt = ds.Tables["Student"];
                DataRow dr = dt.NewRow();
                dr["Name"] = "Ihzan";
                dr["Class"] = "Computer Scince";
                dt.Rows.Add(dr);

                da.InsertCommand = new SqlCommand("InsertStudentAndOutId", conn);
                da.InsertCommand.CommandType = CommandType.StoredProcedure;
                da.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 25, "Name");
                da.InsertCommand.Parameters.Add("@Class", SqlDbType.VarChar, 25, "Class");
                SqlParameter idParams= da.InsertCommand.Parameters.Add("@Id", SqlDbType.Int);
                idParams.Direction = ParameterDirection.Output;

                da.Update(ds, "Student");
                Console.WriteLine($"Inserted student in the id {idParams.Value}");
                
            }
        }
        public void DeleteStudent()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Student", conn);
                DataSet ds = new DataSet();
                da.Fill(ds,"Student");
                DataTable dt = ds.Tables["Student"];
                dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };
                DataRow dr = dt.Rows.Find(2);
                if(dr != null)
                {
                    dr.Delete();
                }
                da.DeleteCommand = new SqlCommand("DeleteStudent", conn);
                da.DeleteCommand.CommandType = CommandType.StoredProcedure;
                da.DeleteCommand.Parameters.AddWithValue("@StudentId", 2);
                SqlParameter deleteParams1 = da.DeleteCommand.Parameters.Add("@Name", SqlDbType.VarChar, 25);
                SqlParameter deleteParams2 = da.DeleteCommand.Parameters.Add("@Class", SqlDbType.VarChar, 25);
                deleteParams1.Direction = ParameterDirection.Output;
                deleteParams2.Direction = ParameterDirection.Output;
                var res = da.Update(ds, "Student") ;
                if (res>0)
                {
                    Console.WriteLine($"Deleted Student {deleteParams1.Value} in {deleteParams2.Value}");
                }

            }
        }
        public void UpdateStudent()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Student", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student");

                DataTable dt = ds.Tables["Student"];
                dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };
                DataRow dr = dt.Rows.Find(4);
                if (dr == null)
                {
                    Console.WriteLine("There is no student in this id");
                    return;
                }
                dr["Name"] = "Shashi";
                dr["Class"] = "Business Analytics";
                da.UpdateCommand =new SqlCommand("UpdateStudent", conn);
                da.UpdateCommand.CommandType = CommandType.StoredProcedure;
                da.UpdateCommand.Parameters.Add("@Name",SqlDbType.VarChar, 25,"Name");
                da.UpdateCommand.Parameters.Add("@Class",SqlDbType.VarChar, 25,"Class");
                da.UpdateCommand.Parameters.AddWithValue("@Id",4);
                int res = da.Update(ds, "Student");
                if(res>0)
                {
                    Console.WriteLine("Data Updated");
                }
            }
        }
    }
}
