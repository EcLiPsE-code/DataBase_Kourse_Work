using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel.SortedEmployee
{
    public enum SortStateEmployee
    {
        FullNameAsc,
        FullNameDesc,
        SalaryAsc,
        SalaryDesc,
        AgeAsc,
        AgeDesc,
        RaitingAsc,
        RaitingDesc,
        DepartamentAsc,
        DepartamentDesc
    }
    public class SortEmployeeViewModel
    {
        public SortStateEmployee FullNameSort { get; set; }
        public SortStateEmployee SalarySort { get; set; }
        public SortStateEmployee AgeSort { get; set; }
        public SortStateEmployee RaitingSort { get; set; }
        public SortStateEmployee DepartamentSort { get; set; }

        public SortStateEmployee CurrentState { get; set; }

        public SortEmployeeViewModel(SortStateEmployee SortStateEmployee)
        {
            FullNameSort = SortStateEmployee == SortStateEmployee.FullNameAsc ? SortStateEmployee.FullNameDesc : SortStateEmployee.FullNameAsc;
            SalarySort = SortStateEmployee == SortStateEmployee.SalaryAsc ? SortStateEmployee.SalaryDesc : SortStateEmployee.SalaryAsc;
            AgeSort = SortStateEmployee == SortStateEmployee.AgeAsc ? SortStateEmployee.AgeDesc : SortStateEmployee.AgeAsc;
            RaitingSort = SortStateEmployee == SortStateEmployee.RaitingAsc ? SortStateEmployee.RaitingDesc : SortStateEmployee.RaitingAsc;
            DepartamentSort = SortStateEmployee == SortStateEmployee.DepartamentAsc ? SortStateEmployee.DepartamentDesc : SortStateEmployee.DepartamentAsc;

            CurrentState = SortStateEmployee;
        }
    }
}
