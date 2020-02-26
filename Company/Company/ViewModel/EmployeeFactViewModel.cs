using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class EmployeeFactViewModel
    {
        public IEnumerable<EmployeeFact> EmployeeFacts { get; set; }

        [Display(Name = "Код фактических показателей")]
        public int Id { get; set; }
        [Display(Name = "Квартал")]
        public int Quarter { get; set; }
        [Display(Name = "Год")]
        public int Year { get; set; }
        [Display(Name = "Квартальные показатели эффективности(%)")]
        public double PerfomanceQuarter { get; set; }
        [Display(Name = "Годовые показатели эффективности(%)")]
        public double PerfomanceYear { get; set; }
        [Display(Name = "Сотрудник")]
        public double EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public PageViewModel PageViewModel { get; set; } //навигационное свойство для страничной навигации
    }
}
