using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class DepartamentViewModel
    {
        public IEnumerable<Departament> Departaments { get; set; }

        [Display(Name = "Код отдела")]
        public int Id { get; set; }
        [Display(Name = "Наименование отдела")]
        public string FullName { get; set; }
        [Display(Name = "Кол-во сотрудников")]
        public int CountEmployee { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
