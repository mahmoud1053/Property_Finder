using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Contexts;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContractController(AppDbContext context)
        {
            _context = context;
        }

       
       

        // GET: api/Contract/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract(int id)
        {
            var contract = await _context.Contracts
                .Where(c => c.Contract_Id == id)
                .Select(c => new GetContractDto
                {
                    Contract_Id = c.Contract_Id,
                    Terms = c.Terms,
                    Start_Date = c.Start_Date,
                    End_Date = c.End_Date
                })
                .FirstOrDefaultAsync();

            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        // POST: api/Contract
        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractDto contractDto)
        {
            var contract = new Contract
            {
                Terms = contractDto.Terms,
                Start_Date = contractDto.Start_Date,
                End_Date = contractDto.End_Date
            };

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            var response = new GetContractDto
            {
                Contract_Id = contract.Contract_Id,
                Terms = contract.Terms,
                Start_Date = contract.Start_Date,
                End_Date = contract.End_Date
            };
            return CreatedAtAction(nameof(GetContract), new { id = contract.Contract_Id }, contractDto);
        }

        // PUT: api/Contract/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, GetContractDto contractDto)
        {
            if (id != contractDto.Contract_Id)
            {
                return BadRequest();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            contract.Terms = contractDto.Terms;
            contract.Start_Date = contractDto.Start_Date;
            contract.End_Date = contractDto.End_Date;

            _context.Entry(contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
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

        // DELETE: api/Contract/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(c => c.Contract_Id == id);
        }
    }
}
