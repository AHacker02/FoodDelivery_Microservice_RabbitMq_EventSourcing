using DataAccess.Abstractions;
using OMF.Common.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OMF.CustomerManagementService.Query.Application.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private INoSqlDataAccess _database;
        public AuthRepository(INoSqlDataAccess database)
        {
            _database = database;
        }
        public async Task<User> Login(string email, string password)
        {
            var user = (await _database.All<User>()).FirstOrDefault(x => x.Email.Equals(email));
            if (user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

    }
}
