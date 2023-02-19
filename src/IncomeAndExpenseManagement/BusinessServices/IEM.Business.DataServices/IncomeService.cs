using AutoMapper;
using IEM.Business.Interfaces;
using IEM.Business.Models;
using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Business.DataServices
{
    public class IncomeService : GenericService<IncomeModel, Income>, IIncomeService
    {
        private readonly IRepository<Income> _repository;
        public IncomeService(IRepository<Income> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
        public List<IncomeModel> IncomeForUser(int userID)
        {
            var incomeQueryable = _repository.Get(x => x.UserID == userID);
            var incomeModels = incomeQueryable.Select(x => new IncomeModel
            {
                IncomeID = x.Id,
                Amount = x.Amount,
                UserID = x.UserID
            }).ToList();
            return incomeModels;
        }
    }
}
