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
using CompanyASP.ViewModel.SortedEmployeeFact;

namespace CompanyASP.Controllers
{
    public class EmployeeFactsController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public EmployeeFactsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeeFacts

        public async Task<IActionResult> Index(int? quarter, int? year, int? employeeFacts, int page = 1)
        {
            IQueryable<EmployeeFact> companyContext = _context.EmployeeFacts
                                                      .Include(d => d.Employee);

            //фильтрация
            if (quarter != null && quarter != 0)
            {
                companyContext = companyContext.Where(d => d.Quarter == quarter);
            }
            if (year != null && year != 0)
            {
                companyContext = companyContext.Where(d => d.Year == year);
            }
            if (employeeFacts != null && employeeFacts != 0)
            {
                companyContext = companyContext.Where(d => d.Employee.Id == employeeFacts);
            }
            
            var count = await companyContext.CountAsync();
            var employeesFacts = await companyContext.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var employees = await companyContext.Select(ef => ef.Employee).ToListAsync();
            //формирование представления
            IndexFactEmployeeViewModel viewEmployeeFact = new IndexFactEmployeeViewModel
            {
                EmployeeFacts = employeesFacts,
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterFactEmployeeViewModel = new FilterFactEmployeeViewModel(employees,
                                                                            quarter, year, employeeFacts)
            };
            return View(viewEmployeeFact);
        }

        // GET: EmployeeFacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFact = await _context.EmployeeFacts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeFact == null)
            {
                return NotFound();
            }

            return View(employeeFact);
        }

        // GET: EmployeeFacts/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: EmployeeFacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quarter,Year,PerfomanceQuarter,PerfomanceYear,EmployeeId")] EmployeeFact employeeFact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeFact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", employeeFact.EmployeeId);
            return View(employeeFact);
        }

        // GET: EmployeeFacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFact = await _context.EmployeeFacts.FindAsync(id);
            if (employeeFact == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", employeeFact.EmployeeId);
            return View(employeeFact);
        }

        // POST: EmployeeFacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quarter,Year,PerfomanceQuarter,PerfomanceYear,EmployeeId")] EmployeeFact employeeFact)
        {
            if (id != employeeFact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeFact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeFactExists(employeeFact.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", employeeFact.EmployeeId);
            return View(employeeFact);
        }

        // GET: EmployeeFacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFact = await _context.EmployeeFacts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeFact == null)
            {
                return NotFound();
            }

            return View(employeeFact);
        }

        // POST: EmployeeFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeFact = await _context.EmployeeFacts.FindAsync(id);
            _context.EmployeeFacts.Remove(employeeFact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeFactExists(int id)
        {
            return _context.EmployeeFacts.Any(e => e.Id == id);
        }
    }
}
