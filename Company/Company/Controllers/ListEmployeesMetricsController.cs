using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyASP.Data;
using CompanyASP.Models.Indicators;
using CompanyASP.ViewModel;

namespace CompanyASP.Controllers
{
    public class ListEmployeesMetricsController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public ListEmployeesMetricsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: ListEmployeesMetrics

        public IActionResult Index(int page = 1)
        {
            IQueryable<ListEmployeesMetrics> companyContext = _context.ListEmployeesMetrics
                                                                .Include(d => d.Employee);

            //разбиение на страницы
            var count = companyContext.Count();
            companyContext = companyContext.Skip((page - 1) * pageSize).Take(pageSize);
                                                                       

            //формирование представления
            ListEmployeesMetrcisViewModel listEmployees = new ListEmployeesMetrcisViewModel
            {
                ListEmployeesMetrics = companyContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };
            return View(listEmployees);
        }

        // GET: ListEmployeesMetrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listEmployeesMetrics = await _context.ListEmployeesMetrics
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listEmployeesMetrics == null)
            {
                return NotFound();
            }

            return View(listEmployeesMetrics);
        }

        // GET: ListEmployeesMetrics/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: ListEmployeesMetrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quarter,Year,MarkQuarter,MarkYear,EmployeeId")] ListEmployeesMetrics listEmployeesMetrics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listEmployeesMetrics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", listEmployeesMetrics.EmployeeId);
            return View(listEmployeesMetrics);
        }

        // GET: ListEmployeesMetrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listEmployeesMetrics = await _context.ListEmployeesMetrics.FindAsync(id);
            if (listEmployeesMetrics == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", listEmployeesMetrics.EmployeeId);
            return View(listEmployeesMetrics);
        }

        // POST: ListEmployeesMetrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quarter,Year,MarkQuarter,MarkYear,EmployeeId")] ListEmployeesMetrics listEmployeesMetrics)
        {
            if (id != listEmployeesMetrics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listEmployeesMetrics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListEmployeesMetricsExists(listEmployeesMetrics.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", listEmployeesMetrics.EmployeeId);
            return View(listEmployeesMetrics);
        }

        // GET: ListEmployeesMetrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listEmployeesMetrics = await _context.ListEmployeesMetrics
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listEmployeesMetrics == null)
            {
                return NotFound();
            }

            return View(listEmployeesMetrics);
        }

        // POST: ListEmployeesMetrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listEmployeesMetrics = await _context.ListEmployeesMetrics.FindAsync(id);
            _context.ListEmployeesMetrics.Remove(listEmployeesMetrics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListEmployeesMetricsExists(int id)
        {
            return _context.ListEmployeesMetrics.Any(e => e.Id == id);
        }
    }
}
