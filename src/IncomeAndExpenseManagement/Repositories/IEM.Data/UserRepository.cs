using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Data
{
    public class UserRepository : Respository<User>, IUserRepository
    {
        public UserRepository(IEM_DbContext context) : base(context)
        { }
    }
}
