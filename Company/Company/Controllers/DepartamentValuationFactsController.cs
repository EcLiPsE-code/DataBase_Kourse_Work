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
using CompanyASP.ViewModel.SortDepartamentFact;

namespace CompanyASP.Controllers
{
    public class DepartamentValuationFactsController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public DepartamentValuationFactsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: DepartamentValuationFacts
        public async Task<IActionResult> Index(int? quarter, int? year, int? nameDepartament, int page = 1)
        {
            IQueryable<DepartamentValuationFact> companyContext = _context.DepartamentValuationFacts
                                                     .Include(d => d.Departament);

            if (quarter != null && quarter != 0)
            {
                companyContext = companyContext.Where(d => d.Quarter == quarter);
            }
            if (year != null && year != 0)
            {
                companyContext = companyContext.Where(d => d.Year == year);
            }
            if (nameDepartament != null && nameDepartament != 0)
            {
                companyContext = companyContext.Where(d => d.Departament.Id == nameDepartament);
            }
            //разбиение на страницы
            var count = await companyContext.CountAsync();
            var departamentValuationFacts = await companyContext.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var departaments = await companyContext.Select(ef => ef.Departament).ToListAsync();

            //формирование представления
            IndexDepartamentViewModel departament = new IndexDepartamentViewModel
            {
                DepartamentValuationFacts = departamentValuationFacts,
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterDepartamentFactViewModel = new FilterDepartamentFactViewModel(departaments, quarter, year, nameDepartament)
            };
            return View(departament);
        }

        // GET: DepartamentValuationFacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentValuationFact = await _context.DepartamentValuationFacts
                .Include(d => d.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentValuationFact == null)
            {
                return NotFound();
            }

            return View(departamentValuationFact);
        }

        // GET: DepartamentValuationFacts/Create
        public IActionResult Create()
        {
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName");
            return View();
        }

        // POST: DepartamentValuationFacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quarter,Year,PerfomanceYear,PerfomanceQuarter,DepartamentId")] DepartamentValuationFact departamentValuationFact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentValuationFact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", departamentValuationFact.DepartamentId);
            return View(departamentValuationFact);
        }

        // GET: DepartamentValuationFacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentValuationFact = await _context.DepartamentValuationFacts.FindAsync(id);
            if (departamentValuationFact == null)
            {
                return NotFound();
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", departamentValuationFact.DepartamentId);
            return View(departamentValuationFact);
        }

        // POST: DepartamentValuationFacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quarter,Year,PerfomanceYear,PerfomanceQuarter,DepartamentId")] DepartamentValuationFact departamentValuationFact)
        {
            if (id != departamentValuationFact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentValuationFact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentValuationFactExists(departamentValuationFact.Id))
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
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FulName", departamentValuationFact.DepartamentId);
            return View(departamentValuationFact);
        }

        // GET: DepartamentValuationFacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentValuationFact = await _context.DepartamentValuationFacts
                .Include(d => d.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentValuationFact == null)
            {
                return NotFound();
            }

            return View(departamentValuationFact);
        }

        // POST: DepartamentValuationFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentValuationFact = await _context.DepartamentValuationFacts.FindAsync(id);
            _context.DepartamentValuationFacts.Remove(departamentValuationFact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentValuationFactExists(int id)
        {
            return _context.DepartamentValuationFacts.Any(e => e.Id == id);
        }
    }
}
