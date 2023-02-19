using AutoMapper;
using IEM.Business.Interfaces;
using IEM.Business.Models;
using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Business.DataServices
{
    public class UserService : GenericService<UserModel, User>, IUserService
    {
        //private readonly IRepository<User> _dbContext;
        public UserService(IRepository<User> repository, IMapper mapper) : base(repository, mapper)
        { }
    }
}