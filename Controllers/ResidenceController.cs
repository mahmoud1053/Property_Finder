using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Contexts;
using Azure.Core;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidenceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResidenceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddResidence([FromBody] ResidenceRequest request)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == request.UserId);
            if (!userExists)
            {
                return BadRequest(new { Message = "Invalid UserId. User does not exist." });
            }
            var residence = new Residence
            {
                Num_Of_Rooms = request.Num_Of_Rooms,
                Street = request.Street,
                Building_Num = request.Building_Num,
                Floor_Num = request.Floor_Num,
                Apartment_Num = request.Apartment_Num,
                Type = request.Type,
                Status = request.Status,
                Rent_Fee = request.Rent_Fee,
                UserId = request.UserId,
                Pictures = request.PictureUrls.Select(url => new Residence_Pictures
                {
                   Url = url
                }).ToList()
            };

            _context.Residences.Add(residence);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Residence added successfully!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetResidences()
        {
            var residences = await _context.Residences
                .Include(r => r.Pictures)
                .Select(r => new ResidenceResponse
                {
                    ResidenceId = r.ResidenceId,
                    Num_Of_Rooms = r.Num_Of_Rooms,
                    Street = r.Street,
                    Building_Num = r.Building_Num,
                    Floor_Num = r.Floor_Num,
                    Apartment_Num = r.Apartment_Num,
                    Type = r.Type,
                    Status = r.Status,
                    Rent_Fee = r.Rent_Fee,
                    PictureUrls = r.Pictures.Select(p => p.Url).ToList()
                })
                .ToListAsync();

            return Ok(residences);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidenceById(int id)
        {
            var residence = await _context.Residences
                .Include(r => r.Pictures)
                .Where(r => r.ResidenceId == id)
                .Select(r => new ResidenceResponse
                {
                    ResidenceId = r.ResidenceId,
                    Num_Of_Rooms = r.Num_Of_Rooms,
                    Street = r.Street,
                    Building_Num = r.Building_Num,
                    Floor_Num = r.Floor_Num,
                    Apartment_Num = r.Apartment_Num,
                    Type = r.Type,
                    Status = r.Status,
                    Rent_Fee = r.Rent_Fee,
                    PictureUrls = r.Pictures.Select(p => p.Url).ToList()
                })
                .FirstOrDefaultAsync();

            if (residence == null)
                return NotFound(new { Message = "Residence not found!" });

            return Ok(residence);
        }
    }
}
