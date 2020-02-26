using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyASP.Models;

namespace CompanyASP.ViewModel.SortedEmployeeFact
{
    public class FilterFactEmployeeViewModel
    {
        public SelectList Employees { get; private set; }
        public int? SelectQuarter { get; private set; }
        public int? SelectYear { get; private set; }
        public int? SelectEmployeeFact { get; private set; }

        public FilterFactEmployeeViewModel(List<Employee> employees, int? quarter, int? year, int? employeeFact)
        {
            employees.Insert(0, new Employee { Id = 0, FullName = "Все" });
            Employees = new SelectList(employees, "Id", "FullName", employeeFact);
            SelectQuarter = quarter;
            SelectYear = year;
            SelectEmployeeFact = employeeFact;
        }
    }
}
