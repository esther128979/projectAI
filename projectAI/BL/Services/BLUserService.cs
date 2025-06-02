using BL.Api;
using DAL.Api;
using DAL.Models;
using BL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace BL.Services
{
    public class BLUserService : IBLUser
    {
        private readonly IDAL _dal;
        private readonly IMapper _mapper;

        public BLUserService(IDAL dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public Task<List<BLUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BLUser?> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<BLUser> Register(RegisterRequest request)
        {
            try
            {
                var allUsers = await _dal.User.GetAll();

                if (allUsers.Any(u => u.Email == request.Email))
                    throw new Exception("Email already exists");

                var newUser = new User
                {
                    Email = request.Email,
                    Password = HashPassword(request.Password),
                    RoleId = 2,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    Customer = new Customer
                    {
                        FullName = request.Username,
                        Phone = request.Phone,
                        Gender = request.Gender ? "M" : "F",
                        AgeGroup = (int?)request.AgeGroup,
                        ProfilePicture = request.ProfilePicture
                    }
                };

                var createdUser = await _dal.User.Create(newUser);

                var blUser = _mapper.Map<BLUser>(createdUser);
                return blUser;
            }
            catch (Exception ex) { 
                throw new Exception(ex.ToString());
            }
          
        }

        private string HashPassword(string password)
        {
            return password; // לשדרוג בהמשך להצפנה אמיתית
        }

    }


}
