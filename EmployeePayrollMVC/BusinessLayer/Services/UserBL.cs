using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL :IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.userRL.AddEmployee(employeeModel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void DeleteEmployee(int? id)
        {
            try
            {
                this.userRL.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.userRL.UpdateEmployee(employeeModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return this.userRL.GetEmployeeData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<EmployeeModel> EmployeeList()
        {
            try
            {
              return this.userRL.EmployeeList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteEmployee(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }
    }
}
