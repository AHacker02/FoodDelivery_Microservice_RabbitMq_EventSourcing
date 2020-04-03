using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OMF.CustomerManagementService.Query.Application.Models;
using OMF.CustomerManagementService.Query.Application.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using OMF.Common.Helpers;

namespace OMF.CustomerManagementService.Query.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        public async Task<UserAuthToken> Login(string email, string password)
        {
            var user = await _authRepository.Login(email.ToLower(), password);

            if (user != null)
            {
                

                return new UserAuthToken
                {
                    Token = user.GenerateJwtToken(_configuration.GetSection("Token").Value),
                    User = user
                };
            }

            return null;
        }
    }
}
