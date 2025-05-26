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
    //לעשות כאן MAPPING
    public class BLUserService : IBLUser
    {
        private readonly IDAL _dal;
        private readonly IMapper _mapper;

        public BLUserService(IDAL dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }



        public async Task<List<BLUser>> GetAll()
        {
            throw new NotImplementedException();
            //List<User> list = await dal.Customer.GetAll();
            //return list.Select(c => new BLCustomer()
            //{
            //    CustomerId = c.CustomerId,
            //    CustomerNumber = c.CustomerNumber,
            //    CustomerName = c.CustomerName,
            //    Phone = c.Phone,
            //    Email = c.Email,
            //    Password = c.Password,
            //    Gender = (eGender)Enum.Parse(typeof(eGender), c.Gender),
            //    AgeGroup = c.AgeGroup,
            //    ProfilePicture = c.ProfilePicture,
            //    AgeGroupNavigation = (eAgeGroup)Enum.Parse(typeof(eAgeGroup), c.AgeGroupNavigation.AgeDescrepition)
            //}).ToList();
        }

        public async Task<BLUser> Login(string Email, string Password)
        {


            var user = (await _dal.User.GetAll())
      .FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user == null)
                throw new Exception("User not found or password incorrect");

            return _mapper.Map<BLUser>(user);
        

        }

      
    }


}
