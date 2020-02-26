using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel.SortedEmployee
{
    public class IndexEmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortEmployeeViewModel SortEmployeeViewModel { get; set; }
        public FilterEmployeeViewModel FilterEmployeeViewModel { get; set; }
    }
}
