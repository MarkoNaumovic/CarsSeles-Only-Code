using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SlikaOglasi.Models;

namespace SlikaOglasi.Controllers
{
    public class OglasiController : Controller
    {
        private readonly OglasiContext _context;

        public OglasiController(OglasiContext context)
        {
            _context = context;
        }

        // GET: Oglasi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oglas.ToListAsync());
        }

        // GET: Oglasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasi = await _context.Oglas
                .FirstOrDefaultAsync(m => m.OglasiId == id);
            if (oglasi == null)
            {
                return NotFound();
            }

            return View(oglasi);
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}



        // POST: Oglasi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OglasiId,Naslov,Url,Marka,Model,Godiste,Motor,Snaga_Ks,Gorivo,Karoserija,Opis,Cena")] Oglasi oglasi)
        {
           
            if (ModelState.IsValid)
            {
          
                try
                {
                    _context.Add(oglasi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewBag.Greska = "Greska pri cuvanju podataka";
                }
            }
            return View(oglasi);
        }

        // GET: Oglasi/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasi = await _context.Oglas.FindAsync(id);
            if (oglasi == null)
            {
                return NotFound();
            }
            return View(oglasi);
        }

        // POST: Oglasi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("OglasiId,Naslov,Url,Marka,Model,Godiste,Motor,Snaga_Ks,Gorivo,Karoserija,Opis,Cena")] Oglasi oglasi)
        {

            if (id != oglasi.OglasiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    _context.Update(oglasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OglasiExists(oglasi.OglasiId))
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
            return View(oglasi);
        }

        // GET: Oglasi/Delete/5
        [Authorize]
        
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasi = await _context.Oglas
                .FirstOrDefaultAsync(m => m.OglasiId == id);
            if (oglasi == null)
            {
                return NotFound();
            }

            return View(oglasi);
        }

        // POST: Oglasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oglasi = await _context.Oglas.FindAsync(id);
            _context.Oglas.Remove(oglasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OglasiExists(int id)
        {
            return _context.Oglas.Any(e => e.OglasiId == id);
        }
       
    }
}
