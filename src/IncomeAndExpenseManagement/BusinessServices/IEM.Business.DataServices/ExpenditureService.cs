using AutoMapper;
using IEM.Business.Interfaces;
using IEM.Business.Models;
using IEM.Data.Interfaces;
using IEM.Data.Models;

namespace IEM.Business.DataServices
{
    public class ExpenditureService : GenericService<ExpenditureModel, Expenditure>, IExpenditureService
    {
        private readonly IRepository<Expenditure> _repository;

        public ExpenditureService(IRepository<Expenditure> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
        public List<ExpenditureModel> ExpenditureForUser(int userID)
        {
            var expenditureQueryable = _repository.Get(x => x.UserID == userID);
            var expenditureModels = expenditureQueryable.Select(x => new ExpenditureModel
            {
                ExpID = x.Id,
                Name = x.Name,
                Category = x.Category,
                Amount = x.Amount,
                UserID = x.UserID
            }).ToList();
            return expenditureModels;
        }
    }
}
