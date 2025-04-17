using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Contexts;
using WebApplication1.Entities;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(AppDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Retrieve the user from the database based on the provided email
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return Unauthorized(new { IsSuccess = false, Message = "Invalid email or password" });
        }

        // Verify the hashed password
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new { IsSuccess = false, Message = "Invalid email or password" });
        }

        // Generate a mock token or implement JWT here
        var token = "mock-jwt-token"; // Replace with actual JWT generation logic

        return Ok(new
        {
            IsSuccess = true,
            Message = "Login successful",
            UserId = user.UserId,
            UserName = user.Name,
            UserEmail = user.Email,
            UserNationalId = user.National_Id,
            UserPhone = user.Phone,
            Token = token
        });
    }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
