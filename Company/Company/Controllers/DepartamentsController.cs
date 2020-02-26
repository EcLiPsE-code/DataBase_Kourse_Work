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
    public class DepartamentsController : Controller
    {
        private readonly CompanyContext _context;
        private int pageSize = 10;

        public DepartamentsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: Departaments
        public IActionResult Index(int page = 1)
        {
            IQueryable<Departament> companyContext = _context.Departaments;

            //разбиение на страницы
            var count = companyContext.Count();
            companyContext = companyContext.Skip((page - 1) * pageSize).Take(pageSize);

            //формирование представления
            DepartamentViewModel departament = new DepartamentViewModel
            {
                Departaments = companyContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
            };
            return View(departament);
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,CountEmployee")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,CountEmployee")] Departament departament)
        {
            if (id != departament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentExists(departament.Id))
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
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departament = await _context.Departaments.FindAsync(id);
            _context.Departaments.Remove(departament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentExists(int id)
        {
            return _context.Departaments.Any(e => e.Id == id);
        }
    }
}
