using CompanyASP.Models;
using CompanyASP.ViewModel.SortedEmployeeFact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel.SortedEmployeeFact
{
    public class IndexFactEmployeeViewModel
    {
        public IEnumerable<EmployeeFact> EmployeeFacts { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterFactEmployeeViewModel FilterFactEmployeeViewModel { get; set; }
    }
}
