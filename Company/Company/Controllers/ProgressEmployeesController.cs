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

namespace CompanyASP.Controllers
{
    public class ProgressEmployeesController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public ProgressEmployeesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: ProgressEmployees

        public IActionResult Index(int page = 1)
        {
            IQueryable<ProgressEmployee> companyContext = _context.ProgressEmployees
                                                          .Include(d => d.Employee);

            //разбиение на страницы
            var count = companyContext.Count();
            companyContext = companyContext.Skip((page - 1) * pageSize).Take(pageSize);

            //формирование представления
            ProgressEmployeeViewModel progress = new ProgressEmployeeViewModel
            {
                ProgressEmployees = companyContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };
            return View(progress);
        }

        // GET: ProgressEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progressEmployee = await _context.ProgressEmployees
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progressEmployee == null)
            {
                return NotFound();
            }

            return View(progressEmployee);
        }

        // GET: ProgressEmployees/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: ProgressEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Progress,EmployeeID")] ProgressEmployee progressEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(progressEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FullName", progressEmployee.EmployeeID);
            return View(progressEmployee);
        }

        // GET: ProgressEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progressEmployee = await _context.ProgressEmployees.FindAsync(id);
            if (progressEmployee == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FullName", progressEmployee.EmployeeID);
            return View(progressEmployee);
        }

        // POST: ProgressEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Progress,EmployeeID")] ProgressEmployee progressEmployee)
        {
            if (id != progressEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progressEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgressEmployeeExists(progressEmployee.Id))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "Id", "FullName", progressEmployee.EmployeeID);
            return View(progressEmployee);
        }

        // GET: ProgressEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progressEmployee = await _context.ProgressEmployees
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progressEmployee == null)
            {
                return NotFound();
            }

            return View(progressEmployee);
        }

        // POST: ProgressEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progressEmployee = await _context.ProgressEmployees.FindAsync(id);
            _context.ProgressEmployees.Remove(progressEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgressEmployeeExists(int id)
        {
            return _context.ProgressEmployees.Any(e => e.Id == id);
        }
    }
}
