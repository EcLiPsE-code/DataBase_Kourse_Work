using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class DepartamentValuationPlanViewModel
    {
        public IEnumerable<DepartamentValuationPlan> DepartamentValuationPlans { get; set; }

        [Display(Name = "Код фактических показателей")]
        public int Id { get; set; }
        [Display(Name = "Квартал")]
        public int Quarter { get; set; }
        [Display(Name = "Год")]
        public int Year { get; set; }
        [Display(Name = "Годовые показатели(%)")]
        public double PerfomanceYear { get; set; }
        [Display(Name = "Квартальные показатели(%)")]
        public double PerfomanceQuarter { get; set; }
        [Display(Name = "Отдел")]
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
