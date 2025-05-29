using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.Data;
using BL.Api;
using DAL.Models;
using iText.StyledXmlParser.Jsoup.Parser;
using BL.Models;


namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IBL _context;

        public UsersController(IBL context)
        {
            _context = context;
        }
        private JwtSecurityToken GetToken(BLUser user)
        {

            var claims = new List<Claim>
                  {
                    new Claim(ClaimTypes.Email , user.Email ),
                    new Claim(ClaimTypes.Name , user.Password)
                };

            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
            //foreach (var role in user..Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.Name?.Trim() ?? ""));
            //}

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKeyThatIsAtLeast128BitsLong!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "jwt-app",
                audience: "jwt-users",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return token;   

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            try
            {
                var user =  _context.User.Login(request.Email, request.Password).Result ;

                if (user == null)
                     return Unauthorized("User not found or ID number incorrect");

               var token=GetToken(user);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
           
        }



        //[HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.User.FindAsync(id);
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
        #region "jwt"

        //[HttpPost]
        //public async Task<IActionResult> CreateUser(string username, int id)
        //{
            //var existingUser = await _context.Users.FindAsync(id);
            //if (existingUser != null)
            //{
            //    return Conflict("User with this ID already exists.");
            //}

            //var user = new User { Id = id, Username = username };
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();
            //return Ok(user);
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
        #endregion 
    }

}
