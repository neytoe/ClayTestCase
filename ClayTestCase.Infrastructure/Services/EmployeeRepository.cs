﻿using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Helper;
using ClayTestCase.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Infrastructure.Services
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AuthSettings _settings;
        public EmployeeRepository(AssessmentDataContext dataContext, IOptions<AuthSettings> settings) : base(dataContext)
        {
            _settings = settings.Value;
        }

        public async ValueTask<(string, Employee, string)> RegisterUser(RegisterDto model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                bool hasAccount = await _dataContext.Employees.AnyAsync(u => u.Email.ToLower() == model.Email.ToLower());
                if (hasAccount) { return (null, null, "user already exists"); }

                string passwordHash = GetHashedValue(model.Password);
                Employee user = new Employee
                {
                    Email = model.Email,
                    PasswordHash = passwordHash,
                    Role = model.Role,
                    Name = model.Name,
                };
                user.PasswordHash = passwordHash;
                try
                {
                    _dataContext.Employees.Add(user);
                    var res = await _dataContext.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    return (null, null, ex.Message);
                }
                return (await LoginUser(new LoginDto { Email = model.Email, Password = model.Password }));
            }
            return (null, null, "password must match");

        }

        public async ValueTask<(string, Employee, string)> LoginUser(LoginDto model)
        {
            var loginPassword = model.Password;
            var user = await _dataContext.Employees.FirstOrDefaultAsync(x => x.Email == model.Email);


            if (user == null) { return (null, null, "no such user in the database"); }

            string incomingHash = GetHashedValue(loginPassword);
            if (incomingHash != user.PasswordHash)
            {
                return (null, null, "password do not match");
            }
            return (GetToken(model.Email, user.Role), user, null);
        }

        static string GetHashedValue(string password)
        {
            //using SHA512 to generate the hashing
            using SHA256 hashSvc = SHA256.Create();
            //creating the hash
            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(password));
            //using bitconverter, we convert the hased bits into hex removing the '-'
            string hex = BitConverter.ToString(hash).Replace("-", "");
            return hex;
        }


        public string GetToken(string email, string role)
        {
            //get key
            string key = _settings.Secret;
            //get symmetric key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            //get signin credentials
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            //get claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, email)
            };

            //create web token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMonths(1),
                claims: claims
                );
            //return a writable token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
