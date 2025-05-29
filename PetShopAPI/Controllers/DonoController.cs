using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.Data;
using PetShopAPI.Models;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        private PetShopContext db;

        public DonoController(PetShopContext context)
        {
            db = context;
        }

        [HttpGet]
        public List<Dono> GetDonos()
        {
            return db.Donos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Dono> GetDono(int id)
        {
            var dono = db.Donos
                .Include(d => d.Animais)
                .FirstOrDefault(d => d.Id == id);

            if (dono == null)
                return NotFound();

            return dono;
        }

        [HttpPost]
        public async Task<ActionResult<Dono>> PostDono(Dono dono)
        {
            if (dono.Nome == null || dono.CPF == null)
                return BadRequest("Nome e CPF são obrigatórios");

            db.Donos.Add(dono);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetDono", new { id = dono.Id }, dono);
        }

        [HttpPut("{id}")]
        public ActionResult PutDono(int id, Dono dono)
        {
            if (id != dono.Id)
                return BadRequest();

            db.Entry(dono).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (!db.Donos.Any(e => e.Id == id))
                    return NotFound();
                
                return StatusCode(500, "Erro ao atualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDono(int id)
        {
            var dono = db.Donos.Find(id);
            
            if (dono == null)
                return NotFound();

            try {
                db.Donos.Remove(dono);
                db.SaveChanges();
                return Ok();
            }
            catch {
                return StatusCode(500, "Não foi possível excluir o dono");
            }
        }
    }
} 