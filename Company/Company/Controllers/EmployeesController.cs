using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyASP.Data;
using CompanyASP.Models;
using CompanyASP.ViewModel;
using CompanyASP.ViewModel.SortedEmployee;

namespace CompanyASP.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public EmployeesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: Employees
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 270)]
        public async Task<IActionResult>  Index(int? fullName, int? age, double? salary, double? raiting,
                                   int page = 1, SortStateEmployee employeeSort = SortStateEmployee.FullNameAsc)
        {
            //фильтрация
            IQueryable<Employee> companyContext = _context.Employees
                                                   .Include(d => d.Departament);
            if (fullName != null && fullName != 0)
            {
                companyContext = companyContext.Where(d => d.Id == fullName);
            }
            if (age != null && age.Value != 0)
            {
                companyContext = companyContext.Where(d => d.Age == age);
            }
            if (salary != null && salary.Value != 0)
            {
                companyContext = companyContext.Where(d => d.Salary == salary);
            }
            if (raiting != null && raiting.Value != 0)
            {
                companyContext = companyContext.Where(d => d.Raiting == raiting);
            }
            //сортировка
            switch (employeeSort)
            {
                case SortStateEmployee.AgeAsc:
                    companyContext = companyContext.OrderBy(d => d.Age);
                    break;
                case SortStateEmployee.AgeDesc:
                    companyContext = companyContext.OrderByDescending(d => d.Age);
                    break;
                case SortStateEmployee.FullNameAsc:
                    companyContext = companyContext.OrderBy(d => d.FullName);
                    break;
                case SortStateEmployee.FullNameDesc:
                    companyContext = companyContext.OrderByDescending(d => d.FullName);
                    break;
                case SortStateEmployee.SalaryAsc:
                    companyContext = companyContext.OrderBy(d => d.Salary);
                    break;
                case SortStateEmployee.SalaryDesc:
                    companyContext = companyContext.OrderByDescending(d => d.Salary);
                    break;
                case SortStateEmployee.RaitingAsc:
                    companyContext = companyContext.OrderBy(d => d.Raiting);
                    break;
                case SortStateEmployee.RaitingDesc:
                    companyContext = companyContext.OrderByDescending(d => d.Raiting);
                    break;
                case SortStateEmployee.DepartamentAsc:
                    companyContext = companyContext.OrderBy(d => d.Departament.FullName);
                    break;
                case SortStateEmployee.DepartamentDesc:
                    companyContext = companyContext.OrderByDescending(d => d.Departament.FullName);
                    break;
                default:
                    companyContext = companyContext.OrderBy(d => d.FullName);
                    break;
            }

            //разбиение на страницы
            var count = await companyContext.CountAsync();
            var companys = await companyContext.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            //формирование представления
            IndexEmployeeViewModel employeesView = new IndexEmployeeViewModel
            {
                Employees = companys,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortEmployeeViewModel = new SortEmployeeViewModel(employeeSort),
                FilterEmployeeViewModel = new FilterEmployeeViewModel(companyContext.ToList(), fullName, age, salary, raiting)
            };
            return View(employeesView);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Salary,Age,Raiting,DepartamentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", employee.DepartamentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", employee.DepartamentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Salary,Age,Raiting,DepartamentId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", employee.DepartamentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
       
    }
}
