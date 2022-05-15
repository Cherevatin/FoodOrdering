using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using AutoMapper;

using FoodOrdering.Application.Dtos.User;
using FoodOrdering.Application.Exception;

using FoodOrdering.Domain.Aggregates.UserAggregate;
using FoodOrdering.Domain.Common;

namespace FoodOrdering.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<IEnumerable<GetAllUsersDto>> GetAll()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var usersDtoList = _mapper.Map<List<GetAllUsersDto>>(users);
            return usersDtoList;
        }
        public async Task<GetUserDto> Get(Guid id)
        {
            var user = await _unitOfWork.Users.Get(id);

            if (user == null)
            {
                throw new ApplicationNotFoundException("User not found");
            }

            var userDto = _mapper.Map<GetUserDto>(user);
            return userDto;
        }
        public async Task AppointAsManager(Guid id)
        {
            var user = await _unitOfWork.Users.Get(id);

            if (user == null)
            {
                throw new ApplicationNotFoundException("User not found");
            }

            user.AppointAsManager();
            await _unitOfWork.Save();
        }
        public async Task AppointAsCook(Guid id)
        {
            var user = await _unitOfWork.Users.Get(id);

            if (user == null)
            {
                throw new ApplicationNotFoundException("User not found");
            }

            user.AppointAsCook();
            await _unitOfWork.Save();
        }
        public async Task AppointAsEmployee(Guid id)
        {
            var user = await _unitOfWork.Users.Get(id);

            if (user == null)
            {
                throw new ApplicationNotFoundException("User not found");
            }

            user.AppointAsEmployee();
            await _unitOfWork.Save();
        }
        public async Task Delete(Guid id)
        {
            var user = await _unitOfWork.Users.Get(id);

            if (user == null)
            {
                throw new ApplicationNotFoundException("User not found");
            }

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.Save();
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _unitOfWork.Users.Get(loginDto.Email);
            if (user == null)
            {
                throw new ApplicationNotFoundException("User not found");
            }

            var verifyPassword = VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!verifyPassword)
            {
                throw new ApplicationValidationException("Wrong password");
            }

            string token = CreateToken(user);

            return token;
        }
        public async Task Register(RegisterDto registerDto)
        {
            CreatePasswordHash(registerDto.Password, out var passwordHash, out var passwordSalt);
            
            User user = new(registerDto.Name,
                registerDto.Surname,
                registerDto.Email,
                passwordHash,
                passwordSalt);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.Save();
        }
    }
}
