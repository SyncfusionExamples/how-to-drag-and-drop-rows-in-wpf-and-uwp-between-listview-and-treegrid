using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drag_Drop_between_TreeGrid_and_ListView
{
    /// <summary>
    /// Denotes the ViewModel class
    /// </summary>
    public class ViewModel
    {
        #region Private Variables
        private ObservableCollection<EmployeeInfo> _employees;
        private ObservableCollection<EmployeeInfo> _employee;
        #endregion

        #region ctr

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.Employees = GetEmployeesDetails();
            this.Employee = GetEmployees();
        }

        #endregion

        #region Public properties
        /// <summary>
        /// Contains the details of Employees
        /// </summary>
        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;

            }
        }
        /// <summary>
        /// Contains the details of Employee
        /// </summary>
        public ObservableCollection<EmployeeInfo> Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;

            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the Employee details 
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<EmployeeInfo> GetEmployeesDetails()
        {
            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando", LastName = "Joseph", Title = "Management", Salary = 2000000, ReportsTo = -1, ID = 2 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John", LastName = "Adams", Title = "Accounts", Salary = 2000000, ReportsTo = -1, ID = 3 });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando1", LastName = "Joseph1", Title = "Management1", Salary = 20000000, ReportsTo = -1, ID = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John1", LastName = "Adams1", Title = "Accounts1", Salary = 20000000, ReportsTo = -1, ID = 5 });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando2", LastName = "Joseph2", Title = "Management2", Salary = 20000001, ReportsTo = -1, ID = 6 });
           

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", ID = 9, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", ID = 10, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", ID = 11, Salary = 900000, ReportsTo = 2, Title = "Manager" });

            // Accounts
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", ID = 12, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ID = 13, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ID = 14, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", ID = 15, Salary = 650000, ReportsTo = 3, Title = "Accountant" });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy1", LastName = "Davolio1", ID = 16, Salary = 850000, ReportsTo = 4, Title = "Accounts Manager1" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret1", LastName = "Peacock1", ID = 17, Salary = 700000, ReportsTo = 4, Title = "Accountant1" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael1", LastName = "Suyama1", ID = 18, Salary = 700000, ReportsTo = 4, Title = "Accountant1" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert1", LastName = "King1", ID = 19, Salary = 650000, ReportsTo = 5, Title = "Accountant1" });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy2", LastName = "Davolio2", ID = 20, Salary = 850000, ReportsTo = 5, Title = "Accounts Manager2" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret2", LastName = "Peacock2", ID = 21, Salary = 700000, ReportsTo = 5, Title = "Accountant2" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael2", LastName = "Suyama2", ID = 22, Salary = 700000, ReportsTo = 5, Title = "Accountant2" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert2", LastName = "King2", ID = 23, Salary = 650000, ReportsTo = 5, Title = "Accountant2" });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy3", LastName = "Davolio3", ID = 24, Salary = 850000, ReportsTo = 6, Title = "Accounts Manager3" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret3", LastName = "Peacock3", ID = 25, Salary = 700000, ReportsTo = 6, Title = "Accountant3" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael3", LastName = "Suyama3", ID = 26, Salary = 700000, ReportsTo = 6, Title = "Accountant3" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert3", LastName = "King3", ID = 27, Salary = 650000, ReportsTo = 6, Title = "Accountant3" });
            return employeeDetails;
        }

        /// <summary>
        /// Get the Employees details 
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<EmployeeInfo> GetEmployees()
        {
            ObservableCollection<EmployeeInfo> employeeDet = new ObservableCollection<EmployeeInfo>();
            employeeDet.Add(new EmployeeInfo() { FirstName = "Susmi", LastName = "Joseph", Title = "Management", Salary = 2000000, ReportsTo = -1, ID = 8000 });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Ramya", LastName = "Fuller", ID = 100, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Priya", LastName = "Leverling", ID = 200, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Vicky", LastName = "Buchanan", ID = 300, Salary = 900000, ReportsTo = 8, Title = "Manager" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", ID = 400, Salary = 850000, ReportsTo = 4, Title = "Accounts Manager" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ID = 500, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ID = 600, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", ID = 700, Salary = 650000, ReportsTo = 7, Title = "Accountant" });

            employeeDet.Add(new EmployeeInfo() { FirstName = "Susmi1", LastName = "Joseph1", Title = "Management1", Salary = 2000000, ReportsTo = -1, ID = 9000 });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Ramya1", LastName = "Fuller1", ID = 800, Salary = 1300000, ReportsTo = 2, Title = "Vice President1" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Priya1", LastName = "Leverling1", ID = 900, Salary = 10000000, ReportsTo = 2, Title = "GM1" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Vicky1", LastName = "Buchanan1", ID = 1000, Salary = 9000000, ReportsTo = 8, Title = "Manager1" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Nancy1", LastName = "Davolio1", ID = 1100, Salary = 860000, ReportsTo = 4, Title = "Accounts Manager1" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Margaret1", LastName = "Peacock1", ID = 1200, Salary = 710000, ReportsTo = 3, Title = "Accountant1" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Michael1", LastName = "Suyama1", ID = 1300, Salary = 780000, ReportsTo = 3, Title = "Accountant1" });
            employeeDet.Add(new EmployeeInfo() { FirstName = "Robert1", LastName = "King1", ID = 1400, Salary = 6500000, ReportsTo = 7, Title = "Accountant1" });
            return employeeDet;
        }
        #endregion
    }
}
