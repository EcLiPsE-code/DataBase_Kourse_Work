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
    public class EmployeePlansController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;
        public EmployeePlansController(CompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeePlans

        public IActionResult Index(int page = 1)
        {
            IQueryable<EmployeePlan> companyContext = _context.EmployeePlans
                                                       .Include(d => d.Employee);

            var count = companyContext.Count();
            companyContext = companyContext.Skip((page - 1) * pageSize).Take(pageSize);
                                                                       

            //формирование представления
            EmployeePlanViewModel employee = new EmployeePlanViewModel
            {
                EmployeePlans = companyContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };
            return View(employee);
        }

        // GET: EmployeePlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePlan = await _context.EmployeePlans
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeePlan == null)
            {
                return NotFound();
            }

            return View(employeePlan);
        }

        // GET: EmployeePlans/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: EmployeePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quarter,Year,PerfomanceQuarter,PerfomanceYear,EmployeeId")] EmployeePlan employeePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", employeePlan.EmployeeId);
            return View(employeePlan);
        }

        // GET: EmployeePlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePlan = await _context.EmployeePlans.FindAsync(id);
            if (employeePlan == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", employeePlan.EmployeeId);
            return View(employeePlan);
        }

        // POST: EmployeePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quarter,Year,PerfomanceQuarter,PerfomanceYear,EmployeeId")] EmployeePlan employeePlan)
        {
            if (id != employeePlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePlanExists(employeePlan.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", employeePlan.EmployeeId);
            return View(employeePlan);
        }

        // GET: EmployeePlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePlan = await _context.EmployeePlans
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeePlan == null)
            {
                return NotFound();
            }

            return View(employeePlan);
        }

        // POST: EmployeePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeePlan = await _context.EmployeePlans.FindAsync(id);
            _context.EmployeePlans.Remove(employeePlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePlanExists(int id)
        {
            return _context.EmployeePlans.Any(e => e.Id == id);
        }
    }
}
