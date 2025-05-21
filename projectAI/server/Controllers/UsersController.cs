using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;
//using jwt.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.Data;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //private readonly EJwtJwtdataMdfContext _context;

        //public UsersController(EJwtJwtdataMdfContext context)
        //{
        //    _context = context;
        //}
    //    [HttpPost("login")]
    //    public async Task<IActionResult> Login([FromBody] LoginRequest1 request)
    //    {
    //        // Find the user by username and identity number
    //        var user = await _context.Users
    //            .Include(u => u.Roles)
    //            .FirstOrDefaultAsync(u =>
    //                u.Username == request.Username &&
    //                u.Id == request.IdentityNumber);

    //        if (user == null)
    //            return Unauthorized("User not found or ID number incorrect");

    //        var claims = new List<Claim>
    //{
    //    new Claim(ClaimTypes.Name, user.Username)
    //};

    //        foreach (var role in user.Roles)
    //        {
    //            claims.Add(new Claim(ClaimTypes.Role, role.Name?.Trim() ?? ""));
    //        }

    //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKeyThatIsAtLeast128BitsLong!"));
    //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //            issuer: "jwt-app",
    //            audience: "jwt-users",
    //            claims: claims,
    //            expires: DateTime.Now.AddHours(1),
    //            signingCredentials: credentials
    //        );

    //        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    //        return Ok(new { token = tokenString });
    //    }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] string username)
        //{
        //    // משוך את המשתמש כולל התפקידים שלו
        //    var user = await _context.Users
        //        .Include(u => u.Roles)
        //        .FirstOrDefaultAsync(u => u.Username == username);

        //    if (user == null)
        //        return Unauthorized("User not found");

        //    // יצירת ה־Claims
        //    var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.Username)
        //        };

        //    foreach (var role in user.Roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role.Name.Trim()));
        //    }

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKeyThatIsAtLeast128BitsLong!"));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "jwt-app",
        //        audience: "jwt-users",
        //        claims: claims,
        //        expires: DateTime.Now.AddHours(1),
        //        signingCredentials: credentials
        //    );

        //    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        //    return Ok(new { token = tokenString });
        //}


        //[HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // מחיקת כל התפקידים של המשתמש
        //    var userRoles = _context.Roles.Where(ur => ur.Id == id);
        //    _context.Roles.RemoveRange(userRoles);

        //    // מחיקת המשתמש עצמו
        //    _context.Users.Remove(user);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound("לא קיים משתמש עם המזהה שצוין");
        //    }

        //    // מחיקת כל השיוכים של המשתמש לתפקידים
        //    var userRoles = _context.Roles.Where(ur => ur.Id == id);
        //    _context.Roles.RemoveRange(userRoles);

        //    // מחיקת המשתמש עצמו
        //    _context.Users.Remove(user);

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


        //[HttpPost]
        //public async Task<IActionResult> CreateUser(string username, int id)
        //{
        //    var existingUser = await _context.Users.FindAsync(id);
        //    if (existingUser != null)
        //    {
        //        return Conflict("User with this ID already exists.");
        //    }

        //    var user = new User { Id = id, Username = username };
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return Ok(user);
        //}

        //[HttpPost("{userId}/roles/{roleName}")]
        //public async Task<IActionResult> AssignRole(int userId, string roleName)
        //{
        //    var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName)
        //                ?? new Role { Name = roleName }; // אם התפקיד לא קיים, צור אותו

        //    // חפש את המשתמש
        //    var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == userId);
        //    if (user == null) return NotFound("User not found");

        //    // הוסף את התפקיד למשתמש אם הוא לא כבר קיים
        //    if (user.Roles == null) user.Roles = new List<Role>();
        //    if (!user.Roles.Contains(role))
        //    {
        //        user.Roles.Add(role);
        //    }

        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}

        //[HttpGet("{userId}/roles")]
        //public async Task<IActionResult> GetRoles(int userId)
        //{
        //    var roles = await _context.Users
        //        .Where(ur => ur.Id == userId)
        //        .Select(ur => ur.Roles)
        //        .ToListAsync();

        //    return Ok(roles);
        //}
    }

}
