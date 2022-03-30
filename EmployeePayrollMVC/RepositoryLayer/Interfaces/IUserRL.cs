using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public void AddEmployee(EmployeeModel employeeModel);
        public void DeleteEmployee(int? id);
        public void UpdateEmployee(EmployeeModel employeeModel);
        public EmployeeModel GetEmployeeData(int? id);
        public List<EmployeeModel> EmployeeList();
    }
}
