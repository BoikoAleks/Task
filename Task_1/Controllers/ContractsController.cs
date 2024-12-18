using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Models;

namespace Task_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContractsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Production/Facilities
        [HttpGet("Facilities")]
        public async Task<ActionResult<IEnumerable<ProductionFacility>>> GetFacilities()
        {
            return await _context.ProductionFacilities.ToListAsync();
        }

        // GET: api/Production/EquipmentTypes
        [HttpGet("EquipmentTypes")]
        public async Task<ActionResult<IEnumerable<EquipmentType>>> GetEquipmentTypes()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }

        // POST: api/Production/Contracts
        [HttpPost("Contracts")]
        public async Task<ActionResult<EquipmentPlacementContract>> CreateContract(EquipmentPlacementContract contract)
        {
            if (contract == null)
                return BadRequest("Contract data is invalid.");

            // Додаємо контракт без перевірки на наявність підприємства або типу обладнання
            _context.EquipmentPlacementContracts.Add(contract);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateContract), new { id = contract.Id }, contract);
        }

        // GET: api/Production/Contracts
        [HttpGet("Contracts")]
        public async Task<ActionResult<IEnumerable<object>>> GetContracts()
        {
            var contracts = await _context.EquipmentPlacementContracts
                .Include(c => c.ProductionFacility)
                .Include(c => c.EquipmentType)
                .Select(c => new
                {
                    ProductionFacilityName = c.ProductionFacility.Name,
                    EquipmentTypeName = c.EquipmentType.Name,
                    c.EquipmentQuantity
                })
                .ToListAsync();

            return Ok(contracts);
        }
    }
}
