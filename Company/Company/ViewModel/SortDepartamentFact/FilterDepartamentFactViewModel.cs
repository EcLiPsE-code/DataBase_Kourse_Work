using CompanyASP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel.SortDepartamentFact
{
    public class FilterDepartamentFactViewModel
    {
        public SelectList Departaments { get; private set; }
        public int? SelectQuarter { get; private set; }
        public int? SelectYear { get; private set; }
        public int? SelectDepartamentName { get; private set; }

        public FilterDepartamentFactViewModel(List<Departament> departaments, int? quarter, int? year, int? nameDepartament)
        {
            departaments.Insert(0, new Departament() { Id = 0, FullName = "Все" });
            Departaments = new SelectList(departaments, "Id", "FullName", nameDepartament);
            SelectQuarter = quarter;
            SelectYear = year;
        }
    }
}
