using ClayTestCase.Core.DataAccess.Interfaces;
using ClayTestCase.Core.Dtos;
using ClayTestCase.Core.Enitities;
using ClayTestCase.Core.Helper;
using ClayTestCase.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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

namespace ClayTestCase.Core.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccessRoleRepository _accessRoleRepository;
        private readonly AuthSettings _settings;

        public EmployeeService(IServiceProvider serviceProvider, IOptions<AuthSettings> settings)
        {
            _employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            _accessRoleRepository = serviceProvider.GetRequiredService<IAccessRoleRepository>();
            _settings = settings.Value;
        }

        public async ValueTask<(string, Employee, string)> RegisterUser(RegisterDto model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var userbyEmail = await _employeeRepository.FindUserByEmail(model.Email);
                if (userbyEmail != null) { return (null, null, "user already exists"); }

                string passwordHash = GetHashedValue(model.Password);
                var role = await _accessRoleRepository.Find(model.RoleId);
                if (role == null) return (null, null, "Role Does not exist");
                Employee user = new Employee
                {
                    Email = model.Email,
                    PasswordHash = passwordHash,
                    Role = role.Name,
                    Name = model.Name,
                };
                user.PasswordHash = passwordHash;
                try
                {
                   _employeeRepository.Save(user);

                }
                catch (Exception ex)
                {
                    return (null, null, ex.Message);
                }
                return (await LoginUser(new LoginDto { Email = model.Email, Password = model.Password }));
            }
            return (null, null, "An error Occurred");

        }

        public async ValueTask<(string, Employee, string)> LoginUser(LoginDto model)
        {
            var loginPassword = model.Password;
            var user = await _employeeRepository.FindUserByEmail(model.Email);


            if (user == null) { return (null, null, "no user found"); }

            string incomingHash = GetHashedValue(loginPassword);
            if (incomingHash != user.PasswordHash)
            {
                return (null, null, "Incorrect Password");
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

        public async Task<bool> UpdateUserRole(int userId, int newRoleId)
        {
            var isUserUpdated = false;
            var user = await _employeeRepository.Find(userId);
            var role = await _accessRoleRepository.Find(newRoleId);

            if(user != null && role != null)
            {
                user.Role = role.Name;
                await _employeeRepository.Update(user);
                isUserUpdated = true;
                return isUserUpdated;                               
            }

            return isUserUpdated;
        }
    }
}
