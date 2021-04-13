using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Model;

namespace Application.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectRepo _context;

        public SubjectController(Data.AppContext context)
        {
            _context = new SubjectRepo(context);
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            return View(await _context.Index());
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Details(id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // GET: Subject/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Subject/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,SubjectName")] SubjectModel subjectModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(subjectModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(subjectModel);
        //}

        // GET: Subject/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subjectModel = await _context.SubjectModel.FindAsync(id);
        //    if (subjectModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(subjectModel);
        //}

        // POST: Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("ID,SubjectName")] SubjectModel subjectModel)
        //{
        //    if (id != subjectModel.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(subjectModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SubjectModelExists(subjectModel.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(subjectModel);
        //}

        // GET: Subject/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subjectModel = await _context.SubjectModel
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (subjectModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(subjectModel);
        //}

        //// POST: Subject/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var subjectModel = await _context.SubjectModel.FindAsync(id);
        //    _context.SubjectModel.Remove(subjectModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SubjectModelExists(string id)
        //{
        //    return _context.SubjectModel.Any(e => e.ID == id);
        //}
    }
}
