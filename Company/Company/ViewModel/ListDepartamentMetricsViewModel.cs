using CompanyASP.Models;
using CompanyASP.Models.Indicators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class ListDepartamentMetricsViewModel
    {
        public IEnumerable<ListDepartamentMetrics> ListDepartamentMetrics { get; set; }

        [Display(Name = "Код")]
        public int Id { get; set; }
        [Display(Name = "Квартал")]
        public int Quarter { get; set; }
        [Display(Name = "Год")]
        public int Year { get; set; }
        [Display(Name = "Годовая оценка деятельности")]
        public int MarkYear { get; set; }
        [Display(Name = "Квартальная оценка деятельности")]
        public int MarkQuarter { get; set; }
        [Display(Name = "Отдел")]
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
