using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Registration_Project.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Registration_Project.DAL
{
    public class Registrationdal
    {
        string sqlcon = ConfigurationManager.ConnectionStrings["myconn"].ToString();


        public void InsertEmployee(EmployeeModel obj1)
        {
            //Create connection by using sqlconnection class
            SqlConnection con = new SqlConnection(sqlcon);
            //Open Connection
            con.Open();
            //Pass query to database by using sqlcommand class
            string Query = "spEmployeeInsert";
            SqlCommand cmd = new SqlCommand(Query, con);
            //Inform that we are using stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //Add value to stored procedure
            cmd.Parameters.AddWithValue("@EmpName", obj1.EmpName);
            cmd.Parameters.AddWithValue("@EmailId", obj1.EmailId);
            cmd.Parameters.AddWithValue("@Phone", obj1.Phone);
            cmd.Parameters.AddWithValue("@Address", obj1.Address);
            cmd.Parameters.AddWithValue("@Gender", obj1.Gender);
            cmd.Parameters.AddWithValue("@Designation", obj1.Designation);
            cmd.Parameters.AddWithValue("@DOJ", obj1.DOJ);
            cmd.Parameters.AddWithValue("@Salary", obj1.Salary);
            cmd.Parameters.AddWithValue("@IsActive", obj1.ISactive);
            cmd.Parameters.AddWithValue("@DepartmentId", obj1.DepartmentId);
            cmd.Parameters.AddWithValue("@Password", obj1.Password);
            cmd.Parameters.AddWithValue("@Age", obj1.Age);
            cmd.Parameters.AddWithValue("@BloodGroup", obj1.BloodGroup);
            //Execute Query by using ExecuteNonQuery
            cmd.ExecuteNonQuery();
            //Close connection
            con.Close();

        }
        public void UpdateEmployee(EmployeeModel obj1)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            con.Open();
            //string Query = "Update Employees_ set EmpName=@p1,EmailId=@p2,Phone=@p3,Address=@p4,Gender=@p5,Designation=@p6,DOJ=@p7,Salary=@p8,DepartmentId=@p10,Password=@p11,Age=@p12,BloodGroup=@p13 where EmployeeId=@p14";
            string Query = "spEmployeeUpdate";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", obj1.EmployeeId);
            cmd.Parameters.AddWithValue("@EmpName", obj1.EmpName);
            //  cmd.Parameters.AddWithValue("@EmailId", obj1.EmailId);
            cmd.Parameters.AddWithValue("@Phone", obj1.Phone);
            cmd.Parameters.AddWithValue("@Address", obj1.Address);
            cmd.Parameters.AddWithValue("@Gender", obj1.Gender);
            cmd.Parameters.AddWithValue("@Designation", obj1.Designation);
            cmd.Parameters.AddWithValue("@DOJ", obj1.DOJ);
            cmd.Parameters.AddWithValue("@Salary", obj1.Salary);
            cmd.Parameters.AddWithValue("@IsActive", obj1.ISactive);
            cmd.Parameters.AddWithValue("@DepartmentId", obj1.DepartmentId);
            cmd.Parameters.AddWithValue("@Password", obj1.Password);
            cmd.Parameters.AddWithValue("@Age", obj1.Age);
            cmd.Parameters.AddWithValue("@BloodGroup", obj1.BloodGroup);


            cmd.ExecuteNonQuery();

            con.Close();


        }
        public List<EmployeeModel> DisplayEmployee(int? id = null)
        {
            SqlConnection conObj = new SqlConnection(sqlcon);
            conObj.Open();
            List<EmployeeModel> empList = new List<EmployeeModel>();
            string Query = "";
            if (id == null)
                Query = "SELECT* FROM EMPLOYEES_ INNER JOIN DEPARTMENT_ ON EMPLOYEES_.DEPARTMENTID = DEPARTMENT_.DEPARTMENTID and IsActive=1";
            else
                Query = "SELECT* FROM EMPLOYEES_ INNER JOIN DEPARTMENT_ ON EMPLOYEES_.DEPARTMENTID = DEPARTMENT_.DEPARTMENTID";
            SqlCommand commandobject = new SqlCommand(Query, conObj);
            SqlDataReader datareaderobj = commandobject.ExecuteReader();
            while (datareaderobj.Read())
            {
                EmployeeModel E = new EmployeeModel();

                E.EmployeeId = Convert.ToInt32(datareaderobj[0]);
                E.EmpName = Convert.ToString(datareaderobj[1]);
                E.EmailId = Convert.ToString(datareaderobj[2]);
                E.Phone = Convert.ToString(datareaderobj[3]);
                E.Address = Convert.ToString(datareaderobj[4]);
                E.Gender = Convert.ToString(datareaderobj[5]);
                E.Designation = Convert.ToString(datareaderobj[6]);
                // E.DOJ = Convert.ToDateTime(datareaderobj[7]);
                E.DOJ = Convert.ToDateTime(datareaderobj["DOJ"].ToString()).ToString("dd-MM-yyyy");
                E.Salary = Convert.ToDecimal(datareaderobj[8]);
                E.ISactive = Convert.ToBoolean(datareaderobj[9]);
                E.DepartmentId = Convert.ToInt32(datareaderobj[10]);
                E.Password = datareaderobj[11] != DBNull.Value ? Convert.ToString(datareaderobj[11]) : "--";
                // E.Age = Convert.ToInt32(datareaderobj[12]);
                E.Age = datareaderobj[12] != DBNull.Value ? Convert.ToInt32(datareaderobj[12]) : 0;
                E.BloodGroup = datareaderobj[13] != DBNull.Value ? Convert.ToString(datareaderobj[13]) : "--";
                E.EmpId = datareaderobj[14] != DBNull.Value ? Convert.ToString(datareaderobj[14]) : "--";
                E.DepartmentName = Convert.ToString(datareaderobj[16]);

                empList.Add(E);

            }
            return empList;

        }
        public List<EmployeeModel> DisplayEmployee(int? AtiveResult = null, int? txtSearchResult = null)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            List<EmployeeModel> EmpList = new List<EmployeeModel>();
            string Query = "";
            if (AtiveResult == null || AtiveResult == 1 && !(txtSearchResult.HasValue))
                Query = "SELECT* FROM EMPLOYEES_ INNER JOIN DEPARTMENT_ ON EMPLOYEES_.DEPARTMENTID = DEPARTMENT_.DEPARTMENTID and ISACTIVE=1";
            else if (txtSearchResult.HasValue)
                Query = "SELECT * FROM EMPLOYEES_ INNER JOIN DEPARTMENT_ ON EMPLOYEES_.DEPARTMENTID = DEPARTMENT_.DEPARTMENTID AND EmployeeId LIKE @EmployeeId";
            else
                Query = "SELECT* FROM EMPLOYEES_ INNER JOIN DEPARTMENT_ ON EMPLOYEES_.DEPARTMENTID = DEPARTMENT_.DEPARTMENTID AND ISACTIVE=0";


            SqlCommand commandobject = new SqlCommand(Query, con);
            con.Open();

            commandobject.Parameters.AddWithValue("@EmployeeId", txtSearchResult + "%");
            SqlDataReader datareaderobj = commandobject.ExecuteReader();
            while (datareaderobj.Read())
            {
                EmployeeModel E = new EmployeeModel();

                E.EmployeeId = Convert.ToInt32(datareaderobj[0]);
                E.EmpName = Convert.ToString(datareaderobj[1]);
                E.EmailId = Convert.ToString(datareaderobj[2]);
                E.Phone = Convert.ToString(datareaderobj[3]);
                E.Address = Convert.ToString(datareaderobj[4]);
                E.Gender = Convert.ToString(datareaderobj[5]);
                E.Designation = Convert.ToString(datareaderobj[6]);
                // E.DOJ = Convert.ToDateTime(datareaderobj[7]);
                E.DOJ = Convert.ToDateTime(datareaderobj["DOJ"].ToString()).ToString("dd-MM-yyyy");
                E.Salary = Convert.ToDecimal(datareaderobj[8]);
                E.ISactive = Convert.ToBoolean(datareaderobj[9]);
                E.DepartmentId = Convert.ToInt32(datareaderobj[10]);
                E.Password = datareaderobj[11] != DBNull.Value ? Convert.ToString(datareaderobj[11]) : "--";
                //E.Age = Convert.ToInt32(datareaderobj[12]);
                E.Age = datareaderobj[12] != DBNull.Value ? Convert.ToInt32(datareaderobj[12]) : 0;
                E.BloodGroup = datareaderobj[13] != DBNull.Value ? Convert.ToString(datareaderobj[13]) : "--";
                E.EmpId = datareaderobj[14] != DBNull.Value ? Convert.ToString(datareaderobj[14]) : "--";
                E.DepartmentName = Convert.ToString(datareaderobj[16]);

                EmpList.Add(E);

            }
            return EmpList;

        }

        public EmployeeModel GetEmployee(int id)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            EmployeeModel E = new EmployeeModel();
            string Query = "Select * from Employees_ where EmployeeId = @p1";
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@p1", id);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {

                E.EmployeeId = Convert.ToInt32(DR[0]);
                E.EmpName = Convert.ToString(DR[1]);
                E.EmailId = Convert.ToString(DR[2]);
                E.Phone = Convert.ToString(DR[3]);
                E.Address = Convert.ToString(DR[4]);
                E.Gender = Convert.ToString(DR[5]);
                E.Designation = Convert.ToString(DR[6]);
                //E.DOJ = Convert.ToDateTime(DR[7]);
                E.DOJ = Convert.ToDateTime(DR["DOJ"].ToString()).ToString("dd-MM-yyyy");

                E.Salary = Convert.ToDecimal(DR[8]);
                E.ISactive = Convert.ToBoolean(DR[9]);
                E.DepartmentId = Convert.ToInt32(DR[10]);
                E.Password = DR[11] != DBNull.Value ? Convert.ToString(DR[11]) : "--";
                //E.Age = Convert.ToInt32(DR[12]);
                E.Age = DR[12] != DBNull.Value ? Convert.ToInt32(DR[12]) : 0;
                E.BloodGroup = DR[13] != DBNull.Value ? Convert.ToString(DR[13]) : "--";
            }

            return E;
        }
        public void DeleteEmp(EmployeeModel obj)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            con.Open();
            //string str = "Update  Employees_ set IsActive=@isactive where EmployeeId=@empid";
            string Query = "spEmployeeDelete";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
            cmd.Parameters.AddWithValue("@IsActive", obj.ISactive);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool CheckEmail(string email)
        {
            // Connection string to your database
            SqlConnection con = new SqlConnection(sqlcon);
            con.Open();
            bool flag = false;
            // SQL query to check if email exists
            string query = "SELECT COUNT(*) FROM Employees_ WHERE EmailId = @EmailId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@EmailId", email);
            flag = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            return flag;

        }
    }
}