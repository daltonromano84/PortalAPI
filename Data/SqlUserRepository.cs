using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortalAPI.Dtos;
using PortalAPI.Models;

namespace PortalAPI.Data
{
    public class SqlUserRepository : IUserRepository
    {

        private UserManager<IdentityUser> _userManager;

        private IConfiguration _configuration;

        public SqlUserRepository(UserManager<IdentityUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

        }

        public async Task<UserResponseReadDto> LoginUserAsync(UserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user==null){

                return new UserResponseReadDto
                {
                    Message = "There is no user with that Email address"

                };
            }

            var result = await _userManager.CheckPasswordAsync(user,model.Password);

            if(!result)
            {
                return new UserResponseReadDto
                {

                  Message = "Invalid password",
                  IsSuccess = false
                };
            }

         var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "Manager")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserResponseReadDto
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }

        public async Task<UserResponseReadDto> RegisterUserAsync(UserRegisterCreateDto model)
        {
            if(model==null)
             throw new NullReferenceException("Register model is null");


           if(model.Password != model.ConfirmPassword)
             return new UserResponseReadDto
             {
                 Message="Confirm password doesn't match the password",
                 IsSuccess = false
             };            
           

                var identityUser = new IdentityUser
                {
                       Email = model.Email,
                       UserName = model.Email 

                };

                var result = await _userManager.CreateAsync(identityUser,model.Password);

                if (result.Succeeded)
                {

                return new UserResponseReadDto
                {

                    Message = "User created successfully!",
                    IsSuccess = true,
                  
                };
                    
                }

                return new UserResponseReadDto
                {

                    Message = "User did not create",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e=>e.Description)
                };


           
        }
    }



}