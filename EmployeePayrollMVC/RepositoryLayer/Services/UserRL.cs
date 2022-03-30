using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration Configuration;

        public UserRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        //Add Employee        
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                    cmd.Parameters.AddWithValue("@profileImage", employeeModel.profileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@notes", employeeModel.notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Delete Employee
        public void DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("sPDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId",id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Update Employee
        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                    cmd.Parameters.AddWithValue("@profileImage", employeeModel.profileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@notes", employeeModel.notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //GetEmployeeData
        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    string sqlQuery = "SELECT * FROM EmployeeTable WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employeeModel.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                        employeeModel.EmpName = rdr["EmpName"].ToString();
                        employeeModel.profileImage = rdr["profileImage"].ToString();
                        employeeModel.Gender = rdr["Gender"].ToString();
                        employeeModel.Department = rdr["Department"].ToString();
                        employeeModel.Salary = Convert.ToInt32(rdr["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        employeeModel.notes = rdr["notes"].ToString();
                    }
                    con.Close();
                }
                return employeeModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //list Employee 
        public List<EmployeeModel> EmployeeList()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand cmd = new SqlCommand("sPGetALLEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel()
                        {
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmpName = dr["EmpName"].ToString(),
                            profileImage = dr["profileImage"].ToString(),
                            Gender = dr["Gender"].ToString(),
                            Department = dr["Department"].ToString(),
                            Salary = Convert.ToInt32(dr["Salary"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            notes = dr["notes"].ToString()
                        };
                        employees.Add(employeeModel);
                    }
                    con.Close();
                }
                return employees;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
    