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
    public class ListDepartamentMetricsController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public ListDepartamentMetricsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: ListDepartamentMetrics

        public IActionResult Index(int page = 1)
        {
            IQueryable<ListDepartamentMetrics> companyContext = _context.ListDepartamentMetrics
                                                                .Include(d => d.Departament);

            var count = companyContext.Count();
            companyContext = companyContext.Skip((page - 1) * pageSize).Take(pageSize);
                                               

            ListDepartamentMetricsViewModel listDepartament = new ListDepartamentMetricsViewModel
            {
                ListDepartamentMetrics = companyContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };
            return View(listDepartament);
        }

        // GET: ListDepartamentMetrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listDepartamentMetrics = await _context.ListDepartamentMetrics
                .Include(l => l.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listDepartamentMetrics == null)
            {
                return NotFound();
            }

            return View(listDepartamentMetrics);
        }

        // GET: ListDepartamentMetrics/Create
        public IActionResult Create()
        {
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName");
            return View();
        }

        // POST: ListDepartamentMetrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quarter,Year,MarkYear,MarkQuarter,DepartamentId")] ListDepartamentMetrics listDepartamentMetrics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listDepartamentMetrics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "fullName", listDepartamentMetrics.DepartamentId);
            return View(listDepartamentMetrics);
        }

        // GET: ListDepartamentMetrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listDepartamentMetrics = await _context.ListDepartamentMetrics.FindAsync(id);
            if (listDepartamentMetrics == null)
            {
                return NotFound();
            }
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", listDepartamentMetrics.DepartamentId);
            return View(listDepartamentMetrics);
        }

        // POST: ListDepartamentMetrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quarter,Year,MarkYear,MarkQuarter,DepartamentId")] ListDepartamentMetrics listDepartamentMetrics)
        {
            if (id != listDepartamentMetrics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listDepartamentMetrics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListDepartamentMetricsExists(listDepartamentMetrics.Id))
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
            ViewData["DepartamentId"] = new SelectList(_context.Departaments, "Id", "FullName", listDepartamentMetrics.DepartamentId);
            return View(listDepartamentMetrics);
        }

        // GET: ListDepartamentMetrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listDepartamentMetrics = await _context.ListDepartamentMetrics
                .Include(l => l.Departament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listDepartamentMetrics == null)
            {
                return NotFound();
            }

            return View(listDepartamentMetrics);
        }

        // POST: ListDepartamentMetrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listDepartamentMetrics = await _context.ListDepartamentMetrics.FindAsync(id);
            _context.ListDepartamentMetrics.Remove(listDepartamentMetrics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListDepartamentMetricsExists(int id)
        {
            return _context.ListDepartamentMetrics.Any(e => e.Id == id);
        }
    }
}
