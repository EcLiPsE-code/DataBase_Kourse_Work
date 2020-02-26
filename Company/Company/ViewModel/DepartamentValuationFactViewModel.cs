using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class DepartamentValuationFactViewModel
    {
        public IEnumerable<DepartamentValuationFact> DepartamentValuationFacts { get; set; }

        [Required]
        [Display(Name = "Код фактических показателей")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Квартал")]
        public int Quarter { get; set; }
        [Required]
        [Display(Name = "Год")]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Годовые показатели(%)")]
        public double PerfomanceYear { get; set; }
        [Required]
        [Display(Name = "Квартальные показатели(%)")]
        public double PerfomanceQuarter { get; set; }
        [Required]
        [Display(Name = "Отдел")]
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
