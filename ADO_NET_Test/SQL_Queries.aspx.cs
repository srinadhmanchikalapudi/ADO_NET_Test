using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO_NET_Test
{
    public partial class SQL_Queries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["csTOtest"].ConnectionString;



            using (SqlConnection sq = new SqlConnection(CS))
            {
                string createtablequery = @"
            CREATE TABLE Student (
                StudentID INT PRIMARY KEY IDENTITY(1,1),
                FirstName NVARCHAR(50) NOT NULL,
                LastName NVARCHAR(50) NOT NULL,
                Age INT,
                Major NVARCHAR(100),
                EnrollmentDate DATE

            )";

                string insertvaluesquery = @"
                    INSERT INTO Student (FirstName, LastName, Age, Major, EnrollmentDate)
            VALUES 
            ('John', 'Doe', 20, 'Computer Science', '2022-09-01'),
            ('Jane', 'Smith', 22, 'Electrical Engineering', '2021-09-01'),
            ('Mike', 'Johnson', 21, 'Mechanical Engineering', '2022-01-15'),
            ('Sara', 'Williams', 23, 'Business Administration', '2020-09-01'),
            ('David', 'Brown', 19, 'Mathematics', '2023-06-01')

                ";

                string selectquery = @"SELECT * from Student";

                string procedurequery = @"
                    
                    CREATE PROC [dbo].[spAddrows2]
                    @FirstName nvarchar(50),
                    @LastName nvarchar(50),
                    @Age int,
                    @Major nvarchar(100),
                    @EnrollmentDate date
                    AS
                    BEGIN
                    insert into Student (FirstName, LastName, Age, Major, EnrollmentDate) values(@FirstName,@LastName,@Age,@Major,@EnrollmentDate)
                    END
                    
                    
                    SELECT * from Student

GO
                    ";

                string execStatement = @"EXEC spAddrows2 'Sri','m',123456,'CS Engineeering','2023-06-01'";

                SqlCommand cmd = new SqlCommand(execStatement, sq);
                try
                {
                    sq.Open();
                    // cmd.ExecuteNonQuery();  -- for insert and create queries

                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind(); 
                    Console.WriteLine("Student table values inserted successfully");


                }
                catch (Exception ex)
                {

                    Console.WriteLine("Exception:" + ex.Message);
                }
                finally
                {
                    sq.Close();
                }
            }

        }
    }
}