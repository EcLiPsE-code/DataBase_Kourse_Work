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
    public class DepartamentValuationPlansController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;
        public DepartamentValuationPlansController(CompanyContext context)
        {
            _context = context;
        }

        // GET: DepartamentValuationPlans
        public IActionResult Index(int page = 1)
        {
            IQueryable<DepartamentValuationPlan> companyContext = _context.DepartamentValuationPlans
                                                                          .Include(d => d.Departament);

            //разбиение на страницы
            var count = companyContext.Count();
            companyContext = companyContext.Skip((page - 1) * pageSize).Take(pageSize);

            //формирование представления
            DepartamentValuationPlanViewModel departament = new DepartamentValuationPlanViewModel
            {
                DepartamentValuationPlans = companyContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };
            return View(departament);
        }

        // GET: DepartamentValuationPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentValuationPlan = await _context.DepartamentValuationPlans
                .Include(d => d.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentValuationPlan == null)
            {
                return NotFound();
            }

            return View(departamentValuationPlan);
        }

        // GET: DepartamentValuationPlans/Create
        public IActionResult Create()
        {
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName");
            return View();
        }

        // POST: DepartamentValuationPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quarter,Year,PerfomanceQuarter,PerfomanceYear,DepartamentId")] DepartamentValuationPlan departamentValuationPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentValuationPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", departamentValuationPlan.DepartamentId);
            return View(departamentValuationPlan);
        }

        // GET: DepartamentValuationPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentValuationPlan = await _context.DepartamentValuationPlans.FindAsync(id);
            if (departamentValuationPlan == null)
            {
                return NotFound();
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", departamentValuationPlan.DepartamentId);
            return View(departamentValuationPlan);
        }

        // POST: DepartamentValuationPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quarter,Year,PerfomanceQuarter,PerfomanceYear,DepartamentId")] DepartamentValuationPlan departamentValuationPlan)
        {
            if (id != departamentValuationPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentValuationPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentValuationPlanExists(departamentValuationPlan.Id))
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
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", departamentValuationPlan.DepartamentId);
            return View(departamentValuationPlan);
        }

        // GET: DepartamentValuationPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentValuationPlan = await _context.DepartamentValuationPlans
                .Include(d => d.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentValuationPlan == null)
            {
                return NotFound();
            }

            return View(departamentValuationPlan);
        }

        // POST: DepartamentValuationPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentValuationPlan = await _context.DepartamentValuationPlans.FindAsync(id);
            _context.DepartamentValuationPlans.Remove(departamentValuationPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentValuationPlanExists(int id)
        {
            return _context.DepartamentValuationPlans.Any(e => e.Id == id);
        }
    }
}
