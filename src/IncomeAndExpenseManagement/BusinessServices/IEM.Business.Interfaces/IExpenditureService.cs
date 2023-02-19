using IEM.Business.Models;

namespace IEM.Business.Interfaces
{
    public interface IExpenditureService : IGenericService<ExpenditureModel>
    {
        public List<ExpenditureModel> ExpenditureForUser(int userID);
    }
}
