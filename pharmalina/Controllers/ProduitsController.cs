using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharmalina.Models;

namespace pharmalina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly PharmalinaContext _context;

        public ProduitsController(PharmalinaContext context)
        {
            _context = context;
        }

        // GET: api/Produits
        [HttpGet]
        public IEnumerable<Produit> GetProduit()
        {
            return _context.Produit;
        }

        // GET: api/Produits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produit = await _context.Produit.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return Ok(produit);
        }

        // PUT: api/Produits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit([FromRoute] int id, [FromBody] Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produit.Cleproduit)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produits
        [HttpPost]
        public async Task<IActionResult> PostProduit([FromBody] Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produit.Add(produit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduitExists(produit.Cleproduit))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduit", new { id = produit.Cleproduit }, produit);
        }

        // DELETE: api/Produits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produit = await _context.Produit.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            _context.Produit.Remove(produit);
            await _context.SaveChangesAsync();

            return Ok(produit);
        }

        private bool ProduitExists(int id)
        {
            return _context.Produit.Any(e => e.Cleproduit == id);
        }
    }
}