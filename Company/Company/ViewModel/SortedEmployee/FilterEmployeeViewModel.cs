using CompanyASP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel.SortedEmployee
{
    public class FilterEmployeeViewModel
    {
        public SelectList Employees { get; private set; }
        public int? SelectFullName { get; private set; }
        public int? SelectAge { get; private set; }
        public double? SelectSalary { get; private set; }
        public double? SelectRaiting { get; private set; }

        public FilterEmployeeViewModel(List<Employee> employees, int? fullName, int? age, double? salary,
                                       double? raiting)
        {
            employees.Insert(0, new Employee { FullName = "Все", Id = 0 });
            Employees = new SelectList(employees, "Id", "FullName", fullName);
            SelectFullName = fullName;
            SelectAge = age;
            SelectSalary = salary;
            SelectRaiting = raiting;
        }
    }
}
