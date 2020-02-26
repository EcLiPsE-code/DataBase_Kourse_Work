using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel.SortDepartamentFact
{
    public class IndexDepartamentViewModel
    {
        public IEnumerable<DepartamentValuationFact> DepartamentValuationFacts { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterDepartamentFactViewModel FilterDepartamentFactViewModel { get; set; }
        
    }
}
