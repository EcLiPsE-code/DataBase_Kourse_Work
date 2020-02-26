using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class ProgressEmployeeViewModel
    {
        public IEnumerable<ProgressEmployee> ProgressEmployees { get; set; }

        [Display(Name = "Код прогресса")]
        public int Id { get; set; }
        [Display(Name = "Прогресс")]
        public string Progress { get; set; }
        [Display(Name = "Сотрудник")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
